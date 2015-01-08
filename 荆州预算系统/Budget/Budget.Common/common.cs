using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;

namespace Common
{
    /// <summary>
    ///common 的摘要说明
    /// </summary>
    public class common
    {
        // Methods
        public static string ParseTags(string HTMLStr)
        {
            return Regex.Replace(HTMLStr, "<[^>]*>", "");
        }

        #region 字符串截取
        public static string Sub_StringEx(string str, int length)
        {
            if (str.Length > length - 3)
            {
                return str.Substring(0, length - 3) + "...";
            }
            return str;



        }

        public static string Sub_String(string str, int lenghth)
        {
            if (str.Length > lenghth)
            {
                return str.Substring(0, lenghth);
            }
            return str;
        }
        #endregion

        #region 2.检查字符是否数字或字母

        /// <summary>
        /// 检查字符是否数字或字母
        /// </summary>
        /// <returns></returns>
        public static bool IsNumOrLetter(char c)
        {
            string Str = "abcdefghigklmnopqrstuvwxyzABCDEFGHIGKLMNOPQRSTUVWXYZ0123456789";
            if (Str.Contains(c.ToString()))
                return true;
            else
                return false;
        }

        #endregion

        #region 字符串处理
        /// <summary>
        /// 根据长度截取字符串
        /// </summary>
        /// <param name="strs">传入的字符串</param>
        /// <param name="count">传入要截取的字数</param>
        /// <returns>返回的字符串</returns>
        public static string GetStr(string strs, int count)
        {
            string str = StripHTML(HttpContext.Current.Server.HtmlDecode(strs));
            if (str.Length > count)
            {
                str = str.Substring(0, count) + "...";
            }
            return str;
        }
        /// <summary>
        /// 对数据库记录中存在HTML标签的数据进行处理
        /// </summary>
        /// <param name="strHtml">传入的字符串</param>
        /// <returns>返回的字符串</returns>
        public static string StripHTML(string Htmlstring)
        {
            //string[] aryReg ={
            //              @"<script[^>]*?>.*?</script>",
            //              @"<(\/\s*)?!?((\w+:)?\w+)(\w+(\s*=?\s*(([""'])(\\[""'tbnr]|[^\7])*?\7|\w+)|.{0})|\s)*?(\/\s*)?>",
            //              @"([\r\n])[\s]+",
            //              @"&(quot|#34);",
            //              @"&(amp|#38);",
            //              @"&(lt|#60);",
            //              @"&(gt|#62);",   
            //              @"&(nbsp|#160);",   
            //              @"&(iexcl|#161);",
            //              @"&(cent|#162);",
            //              @"&(pound|#163);",
            //              @"&(copy|#169);",
            //              @"&#(\d+);",
            //              @"-->",
            //              @"<!--.*\n"
            //            };

            //string[] aryRep =   {
            //                "",
            //                "",
            //                "",
            //                "\"",
            //                "&",
            //                "<",
            //                ">",
            //                "   ",
            //                "\xa1",//chr(161),
            //                "\xa2",//chr(162),
            //                "\xa3",//chr(163),
            //                "\xa9",//chr(169),
            //                "",
            //                "\r\n",
            //                ""
            //              };
            //string newReg = aryReg[0];
            //string strOutput = strHtml;
            //for (int i = 0; i < aryReg.Length; i++)
            //{
            //    Regex regex = new Regex(aryReg[i], RegexOptions.IgnoreCase);
            //    strOutput = regex.Replace(strOutput, aryRep[i]);
            //}
            //strOutput.Replace("<", "");
            //strOutput.Replace(">", "");
            //strOutput.Replace("\r\n", "");
            //return strOutput;

            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);        //删除HTML           
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<img[^>]*>;", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;
        }
        #endregion

        #region 类型转换

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

        #endregion

        #region 加解密

        private static string encryptkey = "Wlc8";    //密钥  

        #region   对数据进行加密
        /// <summary>
        /// 对数据进行加密
        /// </summary>
        /// <param name="encryptstring">需要加密的数据</param>
        /// <returns></returns>
        public static string DESEncrypt(string encryptstring)
        {
            string strRtn;
            try
            {
                DESCryptoServiceProvider desc = new DESCryptoServiceProvider();//des进行加密
                byte[] key = System.Text.Encoding.Unicode.GetBytes(encryptkey);
                byte[] data = System.Text.Encoding.Unicode.GetBytes(encryptstring);
                MemoryStream ms = new MemoryStream();//存储加密后的数据
                CryptoStream cs = new CryptoStream(ms, desc.CreateEncryptor(key, key), CryptoStreamMode.Write);
                cs.Write(data, 0, data.Length);//进行加密
                cs.FlushFinalBlock();
                strRtn = Convert.ToBase64String(ms.ToArray());
                return strRtn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region   对数据进行解密
        /// <summary>
        /// 对数据进行解密
        /// </summary>
        /// <param name="decryptstring">需要解密的数据</param>
        /// <returns></returns>
        public static string DESDecrypt(string decryptstring)
        {
            string strRtn;
            try
            {
                DESCryptoServiceProvider desc = new DESCryptoServiceProvider();
                byte[] key = System.Text.Encoding.Unicode.GetBytes(encryptkey);
                byte[] data = Convert.FromBase64String(decryptstring);
                MemoryStream ms = new MemoryStream();//存储解密后的数据
                CryptoStream cs = new CryptoStream(ms, desc.CreateDecryptor(key, key), CryptoStreamMode.Write);
                cs.Write(data, 0, data.Length);//解密数据
                cs.FlushFinalBlock();
                strRtn = System.Text.Encoding.Unicode.GetString(ms.ToArray());
                return strRtn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #endregion

        #region 格式化日期
        public static string FormatDate(string date)
        {
            DateTime d = Convert.ToDateTime(date);
            return d.ToString("yyyy-MM-dd");

        }
        public static string GetYear(string date)
        {
            DateTime d = Convert.ToDateTime(date);
            return d.ToString("yyyy");
        }
        #endregion

        /// <summary>
        /// 过滤HTML中的不安全标签
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static string RemoveUnsafeHtml(string str)
        {
            str = Regex.Replace(str, @"(\<|\s+)o([a-z]+\s?=)", "$1$2", RegexOptions.IgnoreCase);
            return Regex.Replace(str, @"(script|frame|form|meta|behavior|style)([\s|:|>])+", "$1.$2", RegexOptions.IgnoreCase);
        }

        #region 过滤危险字符
        public static string SafeSql(string sql)
        {
            sql = sql.Replace("<", "");
            sql = sql.Replace(">", "");
            sql = sql.Replace(" ", "");
            sql = sql.Replace("*", "");
            sql = sql.Replace("'", "");
            sql = sql.Replace("%", "");
            sql = sql.Replace("|", "");
            sql = sql.Replace("-", "");
            sql = sql.Replace("!", "");
            return sql;
        }
        #endregion

        /// <summary>
        /// 检测是否有Sql危险字符
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsSafeSqlString(string str)
        {
            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }


        /// <summary> 
        /// 描述：把DataTable内容导出excel并返回客户端  
        /// 时间：2012-10-18 
        /// </summary> 
        /// <param name="dtData"></param> 
        /// <param name="header"></param> 
        /// <param name="fileName"></param> 
        /// <param name="mergeCellNums">要合并的列索引字典 格式：列索引-合并模式(合并模式 1 合并相同项、2 合并空项、3 合并相同项及空项)</param> 
        /// <param name="mergeKey">作为合并项的标记列索引</param> 
        public static void DataTable2Excel(System.Data.DataTable dtData, TableCell[] header, string fileName, Dictionary<int, int> mergeCellNums, int? mergeKey)
        {
            System.Web.UI.WebControls.GridView gvExport = null;
            // 当前对话  
            System.Web.HttpContext curContext = System.Web.HttpContext.Current;
            // IO用于导出并返回excel文件  
            System.IO.StringWriter strWriter = null;
            System.Web.UI.HtmlTextWriter htmlWriter = null;

            if (dtData != null)
            {
                // 设置编码和附件格式  
                curContext.Response.ContentType = "application/vnd.ms-excel";
                curContext.Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                curContext.Response.Charset = "gb2312";
                if (!string.IsNullOrEmpty(fileName))
                {
                    //处理中文名乱码问题 
                    fileName = System.Web.HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8);
                    curContext.Response.AppendHeader("Content-Disposition", ("attachment;filename=" + (fileName.ToLower().EndsWith(".xls") ? fileName : fileName + ".xls")));
                }
                // 导出excel文件  
                strWriter = new System.IO.StringWriter();
                htmlWriter = new System.Web.UI.HtmlTextWriter(strWriter);

                // 重新定义一个无分页的GridView  
                gvExport = new System.Web.UI.WebControls.GridView();
                gvExport.DataSource = dtData.DefaultView;
                gvExport.AllowPaging = false;
                //优化导出数据显示，如身份证、12-1等显示异常问题 
                gvExport.RowDataBound += new System.Web.UI.WebControls.GridViewRowEventHandler(dgExport_RowDataBound);

                gvExport.DataBind();
                //处理表头 
                if (header != null && header.Length > 0)
                {
                    gvExport.HeaderRow.Cells.Clear();
                    gvExport.HeaderRow.Cells.AddRange(header);
                }
                //合并单元格 
                if (mergeCellNums != null && mergeCellNums.Count > 0)
                {
                    foreach (int cellNum in mergeCellNums.Keys)
                    {
                        MergeRows(gvExport, cellNum, mergeCellNums[cellNum], mergeKey);
                    }
                }

                // 返回客户端  
                gvExport.RenderControl(htmlWriter);
                curContext.Response.Clear();
                curContext.Response.Write("<meta http-equiv=\"content-type\" content=\"application/ms-excel; charset=gb2312\"/>" + strWriter.ToString());
                curContext.Response.End();
            }
        }

        /// <summary> 
        /// 描述：行绑定事件 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        protected static void dgExport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (TableCell cell in e.Row.Cells)
                {
                    //优化导出数据显示，如身份证、12-1等显示异常问题 
                    if (Regex.IsMatch(cell.Text.Trim(), @"^\d{12,}$") || Regex.IsMatch(cell.Text.Trim(), @"^\d+[-]\d+$"))
                    {
                        cell.Attributes.Add("style", "vnd.ms-excel.numberformat:@");
                    }
                }
            }
        }


        /// <summary>    
        /// 描述：合并GridView列中相同的行 
        /// 作者：李伟波 
        /// 时间：2012-10-18 
        /// </summary>    
        /// <param   name="gvExport">GridView对象</param>    
        /// <param   name="cellNum">需要合并的列</param>    
        /// <param name="mergeMode">合并模式 1 合并相同项、2 合并空项、3 合并相同项及空项</param> 
        /// <param name="mergeKey">作为合并项的标记列索引</param> 
        public static void MergeRows(GridView gvExport, int cellNum, int mergeMode, int? mergeKey)
        {
            int i = 0, rowSpanNum = 1;
            System.Drawing.Color alterColor = System.Drawing.Color.LightGray;
            while (i < gvExport.Rows.Count - 1)
            {
                GridViewRow gvr = gvExport.Rows[i];
                for (++i; i < gvExport.Rows.Count; i++)
                {
                    GridViewRow gvrNext = gvExport.Rows[i];
                    if ((!mergeKey.HasValue || (mergeKey.HasValue && (gvr.Cells[mergeKey.Value].Text.Equals(gvrNext.Cells[mergeKey.Value].Text) || " ".Equals(gvrNext.Cells[mergeKey.Value].Text)))) && ((mergeMode == 1 && gvr.Cells[cellNum].Text == gvrNext.Cells[cellNum].Text) || (mergeMode == 2 && " ".Equals(gvrNext.Cells[cellNum].Text.Trim())) || (mergeMode == 3 && (gvr.Cells[cellNum].Text == gvrNext.Cells[cellNum].Text || " ".Equals(gvrNext.Cells[cellNum].Text.Trim())))))
                    {
                        gvrNext.Cells[cellNum].Visible = false;
                        rowSpanNum++;
                        gvrNext.BackColor = gvr.BackColor;
                    }
                    else
                    {
                        gvr.Cells[cellNum].RowSpan = rowSpanNum;
                        rowSpanNum = 1;
                        //间隔行加底色，便于阅读 
                        if (mergeKey.HasValue && cellNum == mergeKey.Value)
                        {
                            if (alterColor == System.Drawing.Color.White)
                            {
                                gvr.BackColor = System.Drawing.Color.White;
                                alterColor = System.Drawing.Color.White;
                            }
                            else
                            {
                                alterColor = System.Drawing.Color.White;
                            }
                        }
                        break;
                    }
                    if (i == gvExport.Rows.Count - 1)
                    {
                        gvr.Cells[cellNum].RowSpan = rowSpanNum;
                        if (mergeKey.HasValue && cellNum == mergeKey.Value)
                        {
                            if (alterColor == System.Drawing.Color.White)
                                gvr.BackColor = System.Drawing.Color.White;
                        }
                    }
                }
            }
        } 
    }
}