using System;
using System.Text;
using System.Xml;

namespace Lett.Extensions
{
    /// <summary>
    ///     string 扩展方法
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        ///     转换为 XmlDocument
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="XmlException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var source = "<item><name>wrench</name></item>";
        /// var rs     = source.ToXmlDocument();
        ///         ]]>
        ///     </code>
        /// </example>
        public static XmlDocument ToXmlDocument(this string @this)
        {
            var doc = new XmlDocument();
            doc.LoadXml(@this);
            return doc;
        }

        /// <summary>
        ///     转换为 byte 数组
        /// </summary>
        /// <param name="this"></param>
        /// <param name="encoding">编码格式</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="encoding" /> is null</exception>
        /// <exception cref="ArgumentNullException"><paramref name="this" /> is null</exception>
        /// <exception cref="EncoderFallbackException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var source = "abcd";
        /// var rs = source.ToBytes(Encoding.Unicode);
        /// var rs2 = source.ToBytes();    // use Encoding.UTF8
        ///         ]]>
        ///     </code>
        /// </example>
        public static byte[] ToBytes(this string @this, Encoding encoding)
        {
            if (encoding == null) throw new ArgumentNullException(nameof(encoding), "encoding is null");
            return encoding.GetBytes(@this);
        }

        /// <summary>
        ///     <para>转换为 byte 数组</para>
        ///     <para>编码格式 默认为 <see cref="Encoding.UTF8" /></para>
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="this" /> is null</exception>
        /// <exception cref="EncoderFallbackException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var source = "abcd";
        /// var rs = source.ToBytes(Encoding.Unicode);
        /// var rs2 = source.ToBytes();    // use Encoding.UTF8
        ///         ]]>
        ///     </code>
        /// </example>
        public static byte[] ToBytes(this string @this)
        {
            return @this.ToBytes(Encoding.UTF8);
        }
    }
}