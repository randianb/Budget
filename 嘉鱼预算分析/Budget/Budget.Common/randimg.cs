using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.IO;

namespace Common
{
    public class Randimg
    {
        public enum ECodeType
        {
            Digits = 0,
            Alphabet = 1,
            Han,
            Mixed
        }

        // the name (ID) of this image (for identification)
        string _id = String.Empty;
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }


        // how many nosiy lines to be drawn
        private int NOISY_LINES = 20;

        // code type
        private ECodeType _codeType = ECodeType.Mixed;
        public ECodeType CodeType
        {
            get { return _codeType; }
            set { _codeType = value; }
        }


        // the random string
        private string _code;
        public string Code
        {
            get { return _code; }
        }
        // length of the random string
        int _length = 4;
        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }

        // calculated string dimension
        private int iCalculatedWidth = 0, iCalculatedHeight = 0;

        // desired width and height of canvas
        int _width = 80, _height = 26;
        public int ImageWidth
        {
            get { return _width; }
            set { _width = value; }
        }
        public int ImageHeight
        {
            get { return _height; }
            set { _height = value; }
        }

        // the font with which we draw the random string
        private Font _font;
        public Font TextFont
        {
            get { return _font; }
            set { _font = value; }
        }


        public Randimg(string id, int length, ECodeType type, int width, int height)
        {
            _id = id;
            _length = length;
            _codeType = type;
            _width = width;
            _height = height;
            // the font
            _font = new Font(
               new FontFamily("Verdana"),
               8,
               FontStyle.Regular,
               GraphicsUnit.Point);
        }

        /// <summary>
        /// the constructor
        /// </summary>
        public Randimg()
            : this(String.Empty, 4, ECodeType.Digits, 80, 26)
        {
        }

        /// <summary>
        /// generate random char sequence
        /// </summary>
        /// <param name="iLength"></param>
        /// <returns></returns>
        private String getRandomString(int iLength)
        {
            Random rand = new Random();
            char[] chBuffer = new char[iLength];
            int iRand = 0;
            for (int i = 0; i < chBuffer.Length; i++)
            {
                iRand = rand.Next(100);
                if (CodeType == ECodeType.Digits)
                {
                    chBuffer[i] = (char)('0' + (iRand % 10));
                }
                else if (CodeType == ECodeType.Alphabet)
                {
                    chBuffer[i] = (char)('A' + (iRand % 26));
                }
                else if (CodeType == ECodeType.Han)
                {
                    chBuffer[i] = (char)('\u4f00' + iRand);
                }
                else
                {
                    if (iRand % 2 == 0)
                    {
                        chBuffer[i] = (char)('0' + (iRand % 10));
                    }
                    else
                    {
                        chBuffer[i] = (char)('A' + (iRand % 26));
                    }
                }
            }
            return new StringBuilder().Append(chBuffer).ToString();
        }

        /// <summary>
        /// calc dimension of text
        /// </summary>
        /// <param name="Graphics2D"></param>
        private void calculateDimension(Graphics g, string str)
        {
            Size size = g.MeasureString(str, this._font).ToSize();
            this.iCalculatedHeight = size.Height;
            this.iCalculatedWidth = size.Width;
        }


        /// <summary>
        /// write the char sequence to output stream
        /// </summary>
        /// <param name="strText"></param>
        /// <param name="w"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        protected System.Drawing.Image getRandomImage(String strText, int w, int h)
        {
            // calc dimension
            // self-resized image
            // last edited @0822
            int iDelta = 0;
            do
            {
                this.calculateDimension(Graphics.FromImage(new Bitmap(1, 1)), strText);
                if (this.iCalculatedWidth <= 0 || this.iCalculatedHeight <= 0)
                    break;

                if (w <= 0)
                {
                    w = this.iCalculatedWidth;
                }
                if (h <= 0)
                {
                    h = this.iCalculatedHeight;
                }
                {
                    iDelta = w - this.iCalculatedWidth;
                    if (iDelta > 0)
                    {
                        if (h - this.iCalculatedHeight > 0)
                        {
                            iDelta = Math.Min(iDelta, h - this.iCalculatedHeight);
                        }
                        else
                        {
                            iDelta = h - this.iCalculatedHeight;
                        }
                    }
                    else
                    {
                        // negative
                        if (h - this.iCalculatedHeight < 0)
                        {
                            iDelta = Math.Max(iDelta, h - this.iCalculatedHeight);
                        }
                    }
                    if (iDelta == 0)
                        break;
                    // shrink or enlarge the font
                    int theOldSize = (int)_font.Size;
                    _font = new Font(_font.FontFamily, theOldSize + (iDelta / Math.Abs(iDelta)));
                }
            } while (iDelta < 1 || iDelta > 5);
            // create a image object
            System.Drawing.Image bm = new Bitmap(w, h);
            Graphics g = Graphics.FromImage(bm);
            // clear background with white color
            g.Clear(Color.White);
            // draw noisy lines on the background
            Random rand = new Random();
            Pen p = new Pen(Color.Black);
            for (int i = 0; i < NOISY_LINES; i++)
            {
                int x1 = rand.Next(w);
                int y1 = rand.Next(h);
                int x2 = rand.Next(w);
                int y2 = rand.Next(h);
                p.Color = Color.FromArgb(100 + rand.Next(128), 100 + rand.Next(128), 100 + rand.Next(128));

                g.DrawLine(p, x1, y1, x2, y2);
            }
            // draw the string of chars
            int xBaseline = 0;
            SolidBrush sb = new SolidBrush(Color.Black);
            for (int i = 0; i < strText.Length; i++)
            {
                // set current color, angle
                sb.Color = Color.FromArgb(rand.Next(128), rand.Next(100), rand.Next(128));
                g.RotateTransform(rand.Next() % 2 == 0 ? -3f : 3f);
                g.DrawString(strText[i].ToString(), _font, sb, xBaseline, (h - _font.GetHeight()) / 2);
                // advance the xbaseline
                xBaseline += g.MeasureString(strText[i].ToString(), _font).ToSize().Width;
                // reset transform
                g.ResetTransform();
            }
            return bm;
        }

        public void WriteImage2Stream(Stream os)
        {
            _code = this.getRandomString(Length);
            // save the image into given os
            this.getRandomImage(_code, _width, _height).Save(os, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        /// <summary>
        /// verify the user keyed code (usually when user made a postback)
        /// </summary>
        /// <param name="code">user keyed code</param>
        /// <returns>true on success</returns>
        public bool Verify(string code)
        {
            return !string.IsNullOrEmpty(code) && Code == code;
        }
    }

}