using System;
using System.Reflection;
using System.Resources;
using System.Drawing;
using System.IO;

namespace Common
{
    public class Resource
    {
        // Fields
        private static Resource instance = null;
        private static object _lock = new object();
        private static string SRName = string.Empty;

        // Methods
        private Resource(string SRName)
        {
            this._rm = new ResourceManager(SRName, base.GetType().Assembly);
        }

        public static Resource GetInstance(string ResouceName)
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new Resource(ResouceName);
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// 获取资源字符串

        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetString(string name)
        {
            string str = null;
            str = instance.Resources.GetString(name);
            return str;
        }

        /// <summary>
        /// 获取资源图片
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Image GetImage(string name)
        {
            Image img = null;
            img = instance.Resources.GetObject(name) as Image;
            return img;
        }


        /// <summary>
        /// 以数据流形式获取资源文件
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Stream GetStream(string name)
        {
            Stream sm = null;
            string str = instance.Resources.GetObject(name) as string;
            byte[] byteArray = System.Text.Encoding.Default.GetBytes(str);
            sm = new MemoryStream(byteArray);
            return sm;
        }

        // Properties
        private ResourceManager _rm;
        /// <summary>
        /// 资源
        /// </summary>
        private ResourceManager Resources
        {
            get
            {
                return this._rm;
            }
        }
    }

}