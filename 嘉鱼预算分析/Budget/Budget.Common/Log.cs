using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;


namespace Common
{
    /// <summary>
    ///Log 的摘要说明
    /// </summary>
    public class Log
    {
        public Log()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="msg">错误消息提示</param>
        /// <param name="tag">命名空间.类名</param>
        public static void WriteLog(string msg, string tag)
        {
            string strA = DateTime.Now.ToString("yyyy年MM月dd日HH时mm分ss秒");
            int t = (new Random()).Next(1, 9999);
            string strB = t.ToString().PadLeft(4, '0');
            string path = HttpContext.Current.Server.MapPath("~") + "\\log\\" + strA + strB + ".txt";
            System.IO.File.WriteAllText(path, tag + ":" + msg);
        }
    }

}
