using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Lett.Extensions
{
    /// <summary>
    ///     XmlDocument 扩展方法
    /// </summary>
    public static class XmlDocumentExtensions
    {
        /// <summary>
        ///     <para>选择匹配 XPath 表达式的节点集合</para>
        ///     <para>匹配结果为空时，返回 null </para>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="xpath">xpath</param>
        /// <exception cref="ArgumentNullException"><paramref name="this" /> is null</exception>
        /// <exception cref="ArgumentNullException"><paramref name="xpath" /> is null</exception>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var xmlDoc = new XmlDocument();
        /// xmlDoc.Load("System.Xml.XmlDocument/test.xml");
        /// var xpath = "/functional/dataSource/storeSource/columns/column";
        /// var rs = xmlDoc.SelectNodesEnumerable(xpath);
        /// 
        /// // rs.ToList()[0]?.Attributes?.GetNamedItem("name").Value; == "FRowId"
        /// // xmlDoc.SelectNodesEnumerable(null); // error throw ArgumentNullException
        /// xmlDoc = null;
        /// var rs = xmlDoc.SelectNodesEnumerable(xpath); // error error throw ArgumentNullException
        ///         ]]>
        ///     </code>
        /// </example>
        public static IEnumerable<XmlNode> SelectNodesEnumerable(this XmlDocument @this, string xpath)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this), $"{nameof(@this)} is null");
            if (xpath == null) throw new ArgumentNullException(nameof(xpath), $"{nameof(xpath)} is null");
            return @this.SelectNodes(xpath)?.Cast<XmlNode>();
        }
    }
}