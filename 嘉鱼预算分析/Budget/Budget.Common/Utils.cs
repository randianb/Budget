using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Web;

namespace Common
{
    public class Utils
    {
        #region MD5加密
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] MD5Encrypt(byte[] bytes)
        {
            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(bytes);
            return s;
        }
        #endregion


        /// <summary>
        /// 转换成Int型数字
        /// </summary>
        /// <param name="o"></param>
        /// <param name="iDefault"></param>
        /// <returns></returns>
        public static int IntSafeConvert(object o, int iDefault)
        {
            if (o == null)
                return iDefault;
            string _s = o.ToString().Trim();
            if (_s.Length <= 0)
                return iDefault;
            int res = iDefault;
            return int.TryParse(_s, out res) ? res : iDefault;
        }
        /// <summary>
        /// 转换成Int型数字
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static int IntSafeConvert(object o)
        {
            return IntSafeConvert(o, 0);
        }


        /// <summary>
        /// 转换成Byte型数字
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static byte ByteSafeConvert(object o)
        {
            return ByteSafeConvert(o, 0);
        }

        /// <summary>
        /// 转换成Byte型数字
        /// </summary>
        /// <param name="o"></param>
        /// <param name="iDefault"></param>
        /// <returns></returns>
        public static byte ByteSafeConvert(object o, byte iDefault)
        {
            if (o == null)
                return iDefault;
            string _s = o.ToString().Trim();
            if (_s.Length <= 0)
                return iDefault;
            byte res = iDefault;
            return byte.TryParse(_s, out res) ? res : iDefault;
        }


        /// <summary>
        /// 以时间命名的文件名
        /// </summary>
        /// <returns></returns>
        public static string GetTimeforFile()
        {
            string strTime = string.Empty;
            DateTime now = DateTime.Now;
            System.Random myRandom = new Random(Int32.Parse(now.Minute.ToString() + now.Millisecond.ToString()));
            strTime = now.ToString("yyyyMMddHHmmss") + now.Millisecond.ToString() + myRandom.Next(9).ToString() + myRandom.Next(9).ToString() + myRandom.Next(9).ToString() + myRandom.Next(9).ToString();
            return strTime;
        }


        /// <summary>
        /// 读取文件成Stream
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Stream ReadFileToStream(string path)
        {
            byte[] bytes = File.ReadAllBytes(path);
            Stream sr = new MemoryStream(bytes);
            return sr;
        }

        /// <summary>
        /// 保存Stream成File
        /// </summary>
        /// <param name="sr"></param>
        /// <param name="path"></param>
        public static void SaveStreamToFile(Stream sr, string path)
        {
            int len = (int)sr.Length;
            byte[] bytes = new byte[len];
            sr.Seek(0, SeekOrigin.Begin);
            sr.Read(bytes, 0, len);
            sr.Flush();
            sr.Close();
            File.WriteAllBytes(path, bytes);
        }


        /// <summary>
        /// Xml文件下载
        /// </summary>
        /// <param name="info"></param>
        public static void DownXmlFile(string fileName, string info)
        {
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Expires = 0;
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.AddHeader("Accept-Language", "zh-cn");
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            HttpContext.Current.Response.Write(info);
            HttpContext.Current.Response.End();
        }
    }


}