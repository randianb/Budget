using System;
using System.IO;
using System.Xml.Serialization;

namespace Common
{
    public class ConfigOper
    {

        #region 配置信息操作

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="filename">文件路径</param>
        /// <returns></returns>
        public static object Load(Type type, string path)
        {
            Stream stream = null;
            try
            {
                //stream = XOR.ReadAndDecrypt(path);//异或解密
                stream = Utils.ReadFileToStream(path);
                XmlSerializer serializer = new XmlSerializer(type);
                return serializer.Deserialize(stream);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="path">文件路径</param>
        public static void Save(object obj, string path)
        {
            Stream stream = null;
            try
            {
                stream = new MemoryStream();
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(stream, obj);
                //XOR.EncryptAndSave(stream, path);
                Utils.SaveStreamToFile(stream, path);
                //XOR.EncryptAndSave(stream, path);//异或加密
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }
        #endregion
    }

}