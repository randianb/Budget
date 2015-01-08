using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter;

namespace Common
{
    public class ChineseToNumber
    { 
        /// <summary> 
        /// 繁体转换为简体
        /// </summary> 
        /// <param name="str">繁体字</param> 
        /// <returns>简体字</returns> 
        public static string GetSimplified(string str)
        {
            string r = string.Empty;
            r = ChineseConverter.Convert(str, ChineseConversionDirection.TraditionalToSimplified);
            return r;
        }
        /// <summary>
        /// 将中文数字替换为阿拉伯数字
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static string WordToNumber(string word)
        {
            string simpl= GetSimplified(word);
            string e = "([零一二三四五六七八九十百千万亿])+";
            MatchCollection mc = Regex.Matches(simpl, e);

            foreach (Match m in mc)
            {
                simpl = word.Replace(m.Value, Word2Number(m.Value));
            }
            return simpl;
        }

        private static string Word2Number(string w)
        {
            if (w == "")
                return w;

            string e = "零一二三四五六七八九";
            string[] ew = new string[] { "十", "百", "千" };
            string ewJoin = "十百千";
            string[] ej = new string[] { "万", "亿" };

            string rss = "^([" + e + ewJoin + "]+" + ej[1] + ")?([" + e
                + ewJoin + "]+" + ej[0] + ")?([" + e + ewJoin + "]+)?$";
            string[] mcollect = Regex.Split(w, rss);
            if (mcollect.Length < 4)
                return w;
            return (
                Convert.ToInt64(foh(mcollect[1])) * 100000000 +
                Convert.ToInt64(foh(mcollect[2])) * 10000 +
                Convert.ToInt64(foh(mcollect[3]))
                ).ToString();
        }

        private static int foh(string str)
        {
            string e = "零一二三四五六七八九";
            string[] ew = new string[] { "十", "百", "千" };
            string[] ej = new string[] { "万", "亿" };

            int a = 0;
            if (str.IndexOf(ew[0]) == 0)
                a = 10;
            str = Regex.Replace(str, e[0].ToString(), "");

            if (Regex.IsMatch(str, "([" + e + "])$"))
            {
                a += e.IndexOf(Regex.Match(str, "([" + e + "])$").Value[0]);
            }

            if (Regex.IsMatch(str, "([" + e + "])" + ew[0]))
            {
                a += e.IndexOf(Regex.Match(str, "([" + e + "])" + ew[0]).Value[0]) * 10;
            }

            if (Regex.IsMatch(str, "([" + e + "])" + ew[1]))
            {
                a += e.IndexOf(Regex.Match(str, "([" + e + "])" + ew[1]).Value[0]) * 100;
            }

            if (Regex.IsMatch(str, "([" + e + "])" + ew[2]))
            {
                a += e.IndexOf(Regex.Match(str, "([" + e + "])" + ew[2]).Value[0]) * 1000;
            }
            return a;
        }
    }
}
