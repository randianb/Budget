using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    /// <summary>
    ///StringPlus 的摘要说明
    /// </summary>
    public class StringPlus
    {
        // Methods
        public static bool CheckPicExt(string houzui)
        {
            if ((!(houzui.ToLower() == ".jpg") && !(houzui.ToLower() == ".jpeg")) && (!(houzui.ToLower() == ".bmp") && !(houzui.ToLower() == ".gif")))
            {
                return false;
            }
            return true;
        }

        public static DataTable CreateNewDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("name");
            string[] strArray = new string[] { 
            "北京", "广东", "上海", "天津", "重庆", "海南", "广西", "福建", "浙江", "江苏", "山东", "湖南", "湖北", "四川", "贵州", "云南", 
            "江西", "安徽", "河南", "河北", "辽宁", "吉林", "内蒙", "宁夏", "山西", "陕西", "甘肃", "青海", "新疆", "西藏", "黑龙江"
         };
            for (int i = 0; i < strArray.Length; i++)
            {
                DataRow row = table.NewRow();
                row["name"] = strArray[i];
                table.Rows.Add(row);
            }
            return table;
        }

        public static string DelLastChar(string str, string strchar)
        {
            return str.Substring(0, str.LastIndexOf(strchar));
        }

        public static string DelLastComma(string str)
        {
            return str.Substring(0, str.LastIndexOf(","));
        }

        public static string GetArrayStr(List<string> list, string speater)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                if (i == (list.Count - 1))
                {
                    builder.Append(list[i]);
                }
                else
                {
                    builder.Append(list[i]);
                    builder.Append(speater);
                }
            }
            return builder.ToString();
        }

        public static string GetCleanStyle(string StrList, string SplitString)
        {
            if (StrList == null)
            {
                return "";
            }
            return StrList.Replace(SplitString, "");
        }

        public static string GetNewStyle(string StrList, string NewStyle, string SplitString, out string Error)
        {
            string str = "";
            if (StrList == null)
            {
                str = "";
                Error = "请输入需要划分格式的字符串";
                return str;
            }
            int length = StrList.Length;
            int num2 = GetCleanStyle(NewStyle, SplitString).Length;
            if (length != num2)
            {
                str = "";
                Error = "样式格式的长度与输入的字符长度不符，请重新输入";
                return str;
            }
            string str2 = "";
            for (int i = 0; i < NewStyle.Length; i++)
            {
                if (NewStyle.Substring(i, 1) == SplitString)
                {
                    str2 = str2 + "," + i;
                }
            }
            if (str2 != "")
            {
                str2 = str2.Substring(1);
            }
            foreach (string str3 in str2.Split(new char[] { ',' }))
            {
                StrList = StrList.Insert(int.Parse(str3), SplitString);
            }
            str = StrList;
            Error = "";
            return str;
        }

        public static string[] GetStrArray(string str)
        {
            return str.Split(new char[0x2c]);
        }

        public static List<string> GetStrArray(string str, char speater, bool toLower)
        {
            List<string> list = new List<string>();
            foreach (string str2 in str.Split(new char[] { speater }))
            {
                if (!string.IsNullOrEmpty(str2) && (str2 != speater.ToString()))
                {
                    string item = str2;
                    if (toLower)
                    {
                        item = str2.ToLower();
                    }
                    list.Add(item);
                }
            }
            return list;
        }

        public static string GetSubString(string str, int length)
        {
            if (str.Length <= length)
            {
                return str;
            }
            return str.Substring(0, length);
        }

        public static List<string> GetSubStringList(string o_str, char sepeater)
        {
            List<string> list = new List<string>();
            foreach (string str in o_str.Split(new char[] { sepeater }))
            {
                if (!string.IsNullOrEmpty(str) && (str != sepeater.ToString()))
                {
                    list.Add(str);
                }
            }
            return list;
        }

        public static string ToDBC(string input)
        {
            char[] chArray = input.ToCharArray();
            for (int i = 0; i < chArray.Length; i++)
            {
                if (chArray[i] == '　')
                {
                    chArray[i] = ' ';
                }
                else if ((chArray[i] > 0xff00) && (chArray[i] < 0xff5f))
                {
                    chArray[i] = (char)(chArray[i] - 0xfee0);
                }
            }
            return new string(chArray);
        }

        public static string ToSBC(string input)
        {
            char[] chArray = input.ToCharArray();
            for (int i = 0; i < chArray.Length; i++)
            {
                if (chArray[i] == ' ')
                {
                    chArray[i] = '　';
                }
                else if (chArray[i] < '\x007f')
                {
                    chArray[i] = (char)(chArray[i] + 0xfee0);
                }
            }
            return new string(chArray);
        }

    }
}