using System;
using System.Text;

namespace Lett.Extensions
{
    /// <summary>
    ///     Bytes 扩展方法
    /// </summary>
    public static class ByteExtensions
    {
        /// <summary>
        ///     转换为字符串
        /// </summary>
        /// <param name="this"></param>
        /// <param name="encoding">
        ///     <para>编码格式</para>
        ///     <para>为空时，默认Encoding.UTF8</para>
        /// </param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="this" />
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="this" />
        /// </exception>
        /// <exception cref="DecoderFallbackException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// bytes.ToString(Encoding.UTF8);
        ///         ]]>
        ///     </code>
        /// </example>
        public static string ToString(this byte[] @this, Encoding encoding)
        {
            encoding = encoding ?? Encoding.UTF8;
            return encoding.GetString(@this);
        }
    }
}