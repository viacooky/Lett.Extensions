using System;
using System.Text;

namespace Lett.Extensions
{
    /// <summary>
    ///     string 扩展方法
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        ///     <para>进行 BASE64 编码</para>
        ///     <para>使用 <see cref="Encoding.UTF8" /></para>
        /// </summary>
        /// <param name="this"></param>
        /// <returns>转换失败返回 <c>null</c></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var str1   = "ABCD";
        /// str1.Base64Encode(); // "QUJDRA=="
        ///         ]]>
        ///     </code>
        /// </example>
        public static string Base64Encode(this string @this)
        {
            try
            {
                var encoding = Encoding.UTF8;
                var bytes    = encoding.GetBytes(@this);
                return Convert.ToBase64String(bytes);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        ///     <para>进行 BASE6 4解码</para>
        ///     <para>使用 <see cref="Encoding.UTF8" /></para>
        /// </summary>
        /// <param name="this"></param>
        /// <returns>转换失败返回 <c>null</c></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var base64 = "QUJDRA==";
        /// base64.Base64Decode(); // "ABCD"
        ///         ]]>
        ///     </code>
        /// </example>
        public static string Base64Decode(this string @this)
        {
            try
            {
                var encoding = Encoding.UTF8;
                var bytes    = Convert.FromBase64String(@this);
                return encoding.GetString(bytes);
            }
            catch
            {
                return null;
            }
        }
    }
}