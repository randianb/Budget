using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Common
{
    public class XOR
    {
        /// <summary>
        /// 异或3
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static byte[] ExclusiveOR(byte[] bytes)
        {
            int len = bytes.Length;
            for (int i = 0; i < len; i++)
            {
                bytes[i] ^= 3;
            }
            return bytes;
        }


        /// <summary>
        /// 字符串异或
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string EncryptStr(string str)
        {
            byte[] bytes = System.Text.Encoding.Default.GetBytes(str);
            bytes = ExclusiveOR(bytes);
            return System.Text.Encoding.Default.GetString(bytes);
        }

        /// <summary>
        /// 加密并保存
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static void EncryptAndSave(Stream sr, string path)
        {
            int len = (int)sr.Length;
            byte[] bytes = new byte[len];
            sr.Seek(0, SeekOrigin.Begin);
            sr.Read(bytes, 0, len);
            sr.Flush();
            sr.Close();
            bytes = ExclusiveOR(bytes);
            File.WriteAllBytes(path, bytes);
        }

        /// <summary>
        /// 读取并解密
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Stream ReadAndDecrypt(string path)
        {
            byte[] bytes = File.ReadAllBytes(path);
            bytes = ExclusiveOR(bytes);
            Stream sr = new MemoryStream(bytes);
            return sr;
        }
    }

}