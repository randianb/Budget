using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;


namespace Common
{
    /// <summary>
    /// Xml工具
    /// </summary>
    public static class XmlUtil
    {
        /// <summary>
        /// 获取属性值，没有找到则为null
        /// </summary>
        /// <param name="node">Xml节点</param>
        /// <param name="xpath">XPath表达式</param>
        /// <param name="attributeName">属性名称</param>
        /// <returns></returns>
        public static string GetAttributeValue(XmlNode node, string xpath, string attributeName)
        {
            XmlNode xn = node.SelectSingleNode(xpath);
            if (xn != null)
            {
                return GetAttributeValue(xn, attributeName);
            }
            return null;
        }

        /// <summary>
        /// 获取属性值，没有找到则为null
        /// </summary>
        /// <param name="node">Xml节点</param>
        /// <param name="attributeName">属性名称</param>
        /// <returns></returns>
        public static string GetAttributeValue(XmlNode node, string attributeName)
        {
            XmlAttribute attribute = node.Attributes[attributeName];
            if (attribute != null)
            {
                return attribute.Value;
            }
            return null;
        }
    }

}