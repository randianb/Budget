using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    /// <summary>
    /// 字符串转换工具
    /// </summary>
    public static class ParseUtil
    {
        #region ToBoolean
        /// <summary>
        /// 字符串转换成布尔值
        /// </summary>
        /// <param name="src">字符串</param>
        /// <param name="defaultValue">转换失败时取默认值</param>
        /// <returns>转换结果</returns>
        public static bool ToBoolean(string src, bool defaultValue)
        {
            bool result;
            if (bool.TryParse(src, out result))
            {
                return result;
            }
            return defaultValue;
        }
        /// <summary>
        /// 字符串转换成布尔值
        /// </summary>
        /// <param name="src">字符串</param>
        /// <returns>转换结果</returns>
        public static bool? ToBoolean(string src)
        {
            bool result;
            if (bool.TryParse(src, out result))
            {
                return result;
            }
            return default(bool?);
        }
        #endregion

        #region ToByte
        /// <summary>
        /// 字符串转换成字节
        /// </summary>
        /// <param name="src">字符串</param>
        /// <param name="defaultValue">转换失败时取默认值</param>
        /// <returns>转换结果</returns>
        public static byte ToByte(string src, byte defaultValue)
        {
            byte result;
            if (byte.TryParse(src, out result))
            {
                return result;
            }
            return defaultValue;
        }
        /// <summary>
        /// 字符串转换成字节
        /// </summary>
        /// <param name="src">字符串</param>
        /// <returns>转换结果</returns>
        public static byte? ToByte(string src)
        {
            byte result;
            if (byte.TryParse(src, out result))
            {
                return result;
            }
            return default(byte?);
        }
        #endregion

        #region ToSByte
        /// <summary>
        /// 字符串转换成8位有符号整数
        /// </summary>
        /// <param name="src">字符串</param>
        /// <param name="defaultValue">转换失败时取默认值</param>
        /// <returns>转换结果</returns>
        public static sbyte ToSByte(string src, sbyte defaultValue)
        {
            sbyte result;
            if (sbyte.TryParse(src, out result))
            {
                return result;
            }
            return defaultValue;
        }
        /// <summary>
        /// 字符串转换成空值8位有符号整数
        /// </summary>
        /// <param name="src">字符串</param>
        /// <returns>转换结果</returns>
        public static sbyte? ToSByte(string src)
        {
            sbyte result;
            if (sbyte.TryParse(src, out result))
            {
                return result;
            }
            return default(sbyte?);
        }
        #endregion

        #region ToChar
        /// <summary>
        /// 字符串转换成字符
        /// </summary>
        /// <param name="src">字符串</param>
        /// <param name="defaultValue">转换失败时取默认值</param>
        /// <returns>转换结果</returns>
        public static char ToChar(string src, char defaultValue)
        {
            char result;
            if (char.TryParse(src, out result))
            {
                return result;
            }
            return defaultValue;
        }
        /// <summary>
        /// 字符串转换成字符
        /// </summary>
        /// <param name="src">字符串</param>
        /// <returns>转换结果</returns>
        public static char? ToChar(string src)
        {
            char result;
            if (char.TryParse(src, out result))
            {
                return result;
            }
            return default(char?);
        }
        #endregion

        #region ToShort
        /// <summary>
        /// 字符串转换成16位有符号整数
        /// </summary>
        /// <param name="src">字符串</param>
        /// <param name="defaultValue">转换失败时取默认值</param>
        /// <returns>转换结果</returns>
        public static short ToShort(string src, short defaultValue)
        {
            short result;
            if (short.TryParse(src, out result))
            {
                return result;
            }
            return defaultValue;
        }
        /// <summary>
        /// 字符串转换成空值16位有符号整数
        /// </summary>
        /// <param name="src">字符串</param>
        /// <returns>转换结果</returns>
        public static short? ToShort(string src)
        {
            short result;
            if (short.TryParse(src, out result))
            {
                return result;
            }
            return default(short?);
        }
        #endregion

        #region ToUShort
        /// <summary>
        /// 字符串转换成16位无符号整数
        /// </summary>
        /// <param name="src">字符串</param>
        /// <param name="defaultValue">转换失败时取默认值</param>
        /// <returns>转换结果</returns>
        public static ushort ToUShort(string src, ushort defaultValue)
        {
            ushort result;
            if (ushort.TryParse(src, out result))
            {
                return result;
            }
            return defaultValue;
        }
        /// <summary>
        /// 字符串转换成空值16位无符号整数
        /// </summary>
        /// <param name="src">字符串</param>
        /// <returns>转换结果</returns>
        public static ushort? ToUShort(string src)
        {
            ushort result;
            if (ushort.TryParse(src, out result))
            {
                return result;
            }
            return default(ushort?);
        }
        #endregion

        #region ToInt
        /// <summary>
        /// 字符串转换成整数
        /// </summary>
        /// <param name="src">字符串</param>
        /// <param name="defaultValue">转换失败时取默认值</param>
        /// <returns>转换结果</returns>
        public static int ToInt(string src, int defaultValue)
        {
            int result;
            if (int.TryParse(src, out result))
            {
                return result;
            }
            return defaultValue;
        }
        /// <summary>
        /// 字符串转换成空值整数
        /// </summary>
        /// <param name="src">字符串</param>
        /// <returns>转换结果</returns>
        public static int? ToInt(string src)
        {
            int result;
            if (int.TryParse(src, out result))
            {
                return result;
            }
            return default(int?);
        }
        #endregion

        #region ToUInt
        /// <summary>
        /// 字符串转换成32位无符号整数
        /// </summary>
        /// <param name="src">字符串</param>
        /// <param name="defaultValue">转换失败时取默认值</param>
        /// <returns>转换结果</returns>
        public static uint ToUInt(string src, uint defaultValue)
        {
            uint result;
            if (uint.TryParse(src, out result))
            {
                return result;
            }
            return defaultValue;
        }
        /// <summary>
        /// 字符串转换成空值32位无符号整数
        /// </summary>
        /// <param name="src">字符串</param>
        /// <returns>转换结果</returns>
        public static uint? ToUInt(string src)
        {
            uint result;
            if (uint.TryParse(src, out result))
            {
                return result;
            }
            return default(uint?);
        }
        #endregion

        #region ToLong
        /// <summary>
        /// 字符串转换成长整数
        /// </summary>
        /// <param name="src">字符串</param>
        /// <param name="defaultValue">转换失败时取默认值</param>
        /// <returns>转换结果</returns>
        public static long ToLong(string src, long defaultValue)
        {
            long result;
            if (long.TryParse(src, out result))
            {
                return result;
            }
            return defaultValue;
        }
        /// <summary>
        /// 字符串转换成长整数
        /// </summary>
        /// <param name="src">字符串</param>
        /// <returns>转换结果</returns>
        public static long? ToLong(string src)
        {
            long result;
            if (long.TryParse(src, out result))
            {
                return result;
            }
            return default(long?);
        }
        #endregion

        #region ToULong
        /// <summary>
        /// 字符串转换成64位无符号整数
        /// </summary>
        /// <param name="src">字符串</param>
        /// <param name="defaultValue">转换失败时取默认值</param>
        /// <returns>转换结果</returns>
        public static ulong ToULong(string src, ulong defaultValue)
        {
            ulong result;
            if (ulong.TryParse(src, out result))
            {
                return result;
            }
            return defaultValue;
        }
        /// <summary>
        /// 字符串转换成空值64位无符号整数
        /// </summary>
        /// <param name="src">字符串</param>
        /// <returns>转换结果</returns>
        public static ulong? ToULong(string src)
        {
            ulong result;
            if (ulong.TryParse(src, out result))
            {
                return result;
            }
            return default(ulong?);
        }
        #endregion

        #region ToFloat
        /// <summary>
        /// 字符串转换成单精度浮点数
        /// </summary>
        /// <param name="src">字符串</param>
        /// <param name="defaultValue">转换失败时取默认值</param>
        /// <returns>转换结果</returns>
        public static float ToFloat(string src, float defaultValue)
        {
            float result;
            if (float.TryParse(src, out result))
            {
                return result;
            }
            return defaultValue;
        }
        /// <summary>
        /// 字符串转换成单精度浮点数
        /// </summary>
        /// <param name="src">字符串</param>
        /// <returns>转换结果</returns>
        public static float? ToFloat(string src)
        {
            float result;
            if (float.TryParse(src, out result))
            {
                return result;
            }
            return default(float?);
        }
        #endregion

        #region ToDouble
        /// <summary>
        /// 字符串转换成双精度浮点数
        /// </summary>
        /// <param name="src">字符串</param>
        /// <param name="defaultValue">转换失败时取默认值</param>
        /// <returns>转换结果</returns>
        public static double ToDouble(string src, double defaultValue)
        {
            double result;
            if (double.TryParse(src, out result))
            {
                return result;
            }
            return defaultValue;
        }
        /// <summary>
        /// 字符串转换成双精度浮点数
        /// </summary>
        /// <param name="src">字符串</param>
        /// <returns>转换结果</returns>
        public static double? ToDouble(string src)
        {
            double result;
            if (double.TryParse(src, out result))
            {
                return result;
            }
            return default(double?);
        }
        #endregion

        #region ToDecimal
        /// <summary>
        /// 字符串转换成十进制数
        /// </summary>
        /// <param name="src">字符串</param>
        /// <param name="defaultValue">转换失败时取默认值</param>
        /// <returns>转换结果</returns>
        public static decimal ToDecimal(string src, decimal defaultValue)
        {
            decimal result;
            if (decimal.TryParse(src, out result))
            {
                return result;
            }
            return defaultValue;
        }
        /// <summary>
        /// 字符串转换成十进制数
        /// </summary>
        /// <param name="src">字符串</param>
        /// <returns>转换结果</returns>
        public static decimal? ToDecimal(string src)
        {
            decimal result;
            if (decimal.TryParse(src, out result))
            {
                return result;
            }
            return default(decimal?);
        }
        #endregion

        #region ToDateTime
        /// <summary>
        /// 字符串转换成日期时间
        /// </summary>
        /// <param name="src">字符串</param>
        /// <param name="defaultValue">转换失败时取默认值</param>
        /// <returns>转换结果</returns>
        public static DateTime ToDateTime(string src, DateTime defaultValue)
        {
            DateTime result;
            if (DateTime.TryParse(src, out result))
            {
                return result;
            }
            return defaultValue;
        }
        /// <summary>
        /// 字符串转换成日期时间
        /// </summary>
        /// <param name="src">字符串</param>
        /// <returns>转换结果</returns>
        public static DateTime? ToDateTime(string src)
        {
            DateTime result;
            if (DateTime.TryParse(src, out result))
            {
                return result;
            }
            return default(DateTime?);
        }
        #endregion

        /// <summary>
        /// 字符串时间转Jason时间
        /// </summary>
        /// <param name="strTime"></param>
        /// <returns></returns>
        public static string StrToJsonTime(string strTime)
        {
            string temp = strTime;
            try
            {
                DateTime dt = (DateTime)ToDateTime(strTime);
                if (dt != null)
                {
                    temp = dt.ToString("yyyy年MM月dd日hh时mm分ss秒");
                }
            }
            catch
            {
                temp = strTime;
            }
            return temp;
        }

        /// <summary>
        /// 时间转Jason时间
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string DateToJsonTime(DateTime time)
        {
            string temp = string.Empty;
            if (time != null)
            {
                temp = time.ToString("yyyy年MM月dd日hh时mm分ss秒");
            }
            return temp;
        }

        /// <summary>
        /// 时间转Jason时间
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string DateToyyMMdd(DateTime time)
        {
            string temp = string.Empty;
            if (time != null)
            {
                temp = time.ToString("yyyy年MM月dd日");
            }
            return temp;
        }

        /// <summary>
        /// 时间转Jason时间
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string DateToyyMM(DateTime time)
        {
            string temp = string.Empty;
            if (time != null)
            {
                temp = time.ToString("yyyy年MM月");
            }
            return temp;
        }


        /// <summary>
        /// Jason时间转字符串时间
        /// </summary>
        /// <param name="strTime"></param>
        /// <returns></returns>
        public static string JsonTimeToDateStr(string strTime)
        {
            string temp = strTime;
            try
            {
                DateTime time = DateTime.ParseExact(strTime, "yyyy年MM月dd日HH时mm分ss秒", null);
                temp = time.ToString();
            }
            catch
            {
                temp = strTime;
            }
            return temp;
        }

        /// <summary>
        /// Jason时间转字符串时间
        /// </summary>
        /// <param name="strTime"></param>
        /// <returns></returns>
        public static DateTime JsonTimeToDateTime(string strTime)
        {
            DateTime dt = DateTime.Now;
            try
            {
                dt = DateTime.ParseExact(strTime, "yyyy年MM月dd日HH时mm分ss秒", null);
            }
            catch
            {
                dt = DateTime.Now;
            }
            return dt = DateTime.Now; ;
        }

    }

}