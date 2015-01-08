using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Common
{
    /// <summary>
    /// 正则表达式工具
    /// </summary>
    public static class RegexUtil
    {
        /// <summary>
        /// 检测是否符合email格式
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsEmail(string str)
        {
            return Regex.IsMatch(str, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        /// <summary>
        /// 检测是否是正确的Url
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsURL(string str)
        {
            return Regex.IsMatch(str, @"^(http|https)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&%\$#\=~_\-]+))*$");
        }

        /// <summary>
        /// 判断是否为base64字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsBase64String(string str)
        {
            //A-Z, a-z, 0-9, +, /, =
            return Regex.IsMatch(str, @"[A-Za-z0-9\+\/\=]");
        }

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
        /// 是否为ip
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsIP(string str)
        {
            return Regex.IsMatch(str, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        /// <summary>
        /// 验证字符串是否为正整数
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsUInt(string str)
        {
            return Regex.IsMatch(str, @"^[0-9]*$");
        }

        /// <summary>
        /// 验证字符串是否为时间HH:mm:ss
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsTime(string str)
        {
            return Regex.IsMatch(str, @"^([0-1]?[0-9]|2[0-3]):([0-5][0-9])(:([0-5][0-9]))?$");
        }

        /// <summary>
        /// 验证字符串是否为合法日期yyyy-MM-dd
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsDate(string str)
        {
            return Regex.IsMatch(str, @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[469]|11)-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)[13579][26])-0?2-29)|(((1[6-9]|[2-9]\d)[2468][048])-0?2-29)|(((1[6-9]|[2-9]\d)0[48])-0?2-29)|(([13579]6)00-0?2-29)|(([2468][048])00-0?2-29)|(([3579]2)00-0?2-29))$");
        }

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

        /// <summary>
        /// 是否仅为汉字
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsChineseOnly(string str)
        {
            return Regex.IsMatch(str, @"^[\u4e00-\u9fa5]{0,}$");
        }
    }

}