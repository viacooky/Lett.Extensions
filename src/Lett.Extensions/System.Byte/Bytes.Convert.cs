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
        /// <param name="encoding">编码格式</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        ///     <paramref name="this" />
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="this" />
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="encoding" />
        /// </exception>
        /// <exception cref="DecoderFallbackException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// bytes.ToString(Encoding.UTF8);
        ///         ]]>
        ///     </code>
        /// </example>
        public static string EncodeToString(this byte[] @this, Encoding encoding)
        {
            if (encoding == null) throw new ArgumentNullException(nameof(encoding), "encoding is null");
            return encoding.GetString(@this);
        }

        /// <summary>
        ///     <para>转换为字符串</para>
        ///     <para>默认Encoding.UTF8</para>
        /// </summary>
        /// <param name="this"></param>
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
        public static string EncodeToString(this byte[] @this)
        {
            return @this.EncodeToString(Encoding.UTF8);
        }
    }
}