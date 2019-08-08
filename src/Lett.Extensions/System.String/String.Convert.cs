using System;
using System.IO;
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
        
        /// <summary>
        ///     <para>转换为 <see cref="FileStream" />  (当前字符串作为 path)</para>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="fileMode">文件打开方式</param>
        /// <param name="fileAccess"></param>
        /// <param name="fileShare"></param>
        /// <param name="bufferSize">缓冲区大小</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="@this">path</paramref> is null.</exception>
        /// <exception cref="System.ArgumentException">
        ///     <paramref name="@this">path</paramref> is an empty string (""), contains only white space, or contains one or more invalid characters.   -or-
        ///     <paramref name="this">path</paramref> refers to a non-file device, such as "con:", "com1:", "lpt1:", etc. in an NTFS environment.
        /// </exception>
        /// <exception cref="System.NotSupportedException"><paramref name="@this">path</paramref> refers to a non-file device, such as "con:", "com1:", "lpt1:", etc. in a non-NTFS environment.</exception>
        /// <exception cref="System.IO.FileNotFoundException">
        ///     The file cannot be found, such as when <paramref name="fileMode">mode</paramref> is FileMode.Truncate or FileMode.Open, and the file specified by
        ///     <paramref name="this">path</paramref> does not exist. The file must already exist in these modes.
        /// </exception>
        /// <exception cref="System.IO.IOException">
        ///     An I/O error, such as specifying FileMode.CreateNew when the file specified by <paramref name="this">path</paramref> already exists, occurred.   -or-   The
        ///     system is running Windows 98 or Windows 98 Second Edition and <paramref name="fileShare">share</paramref> is set to FileShare.Delete.   -or-   The stream has been closed.
        /// </exception>
        /// <exception cref="System.Security.SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">The specified path is invalid, such as being on an unmapped drive.</exception>
        /// <exception cref="System.UnauthorizedAccessException">
        ///     The <paramref name="fileAccess">access</paramref> requested is not permitted by the operating system for the specified
        ///     <paramref name="this">path</paramref>, such as when <paramref name="fileAccess">access</paramref> is Write or ReadWrite and the file or directory is set for read-only access.
        /// </exception>
        /// <exception cref="System.IO.PathTooLongException">
        ///     The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248
        ///     characters, and file names must be less than 260 characters.
        /// </exception>
        public static FileStream AsFileStream(this string @this, FileMode fileMode, FileAccess fileAccess, FileShare fileShare, int bufferSize = 8192)
        {
            if (@this.IsNull()) throw new ArgumentNullException(nameof(@this), $"{nameof(@this)} file path is null");
            return new FileStream(@this, fileMode, fileAccess, fileShare, bufferSize);
        }

        /// <summary>
        ///     <para>转换为 <see cref="DirectoryInfo" /> (当前字符串作为 path)</para>
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static DirectoryInfo AsDirectoryInfo(this string @this)
        {
            if (@this.IsNullOrEmpty()) throw new ArgumentNullException(nameof(@this), $"{nameof(@this)} path is null or empty");
            return new DirectoryInfo(@this);
        }
    }
}