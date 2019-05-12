using System.Text;
using System.Xml;

namespace Lett.Extensions
{
    /// <summary>
    ///     string 扩展方法 - 转换
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        ///     转换为 XmlDocument
        /// </summary>
        /// <param name="this">源字符串</param>
        /// <returns></returns>
        public static XmlDocument ToXmlDocument(this string @this)
        {
            var doc = new XmlDocument();
            doc.LoadXml(@this);
            return doc;
        }

        /// <summary>
        ///     转换为 byte 数组
        /// </summary>
        /// <param name="this">源字符串</param>
        /// <param name="encoding">编码格式 默认 UTF8 </param>
        /// <returns></returns>
        public static byte[] ToBytes(this string @this, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            return encoding.GetBytes(@this);
        }
    }
}