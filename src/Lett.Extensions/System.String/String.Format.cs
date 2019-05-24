using System;

namespace Lett.Extensions
{
    /// <summary>
    ///     string 扩展方法
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        ///     格式化
        /// </summary>
        /// <param name="this"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var tmp = "{0}-{1}";
        /// tmp.Format(new[]{"aaa","bbb"}); // "aaa-bbb" 
        ///         ]]>
        /// </code>
        /// </example>
        public static string Format(this string @this, params object[] args)
        {
            return string.Format(@this, args);
        }

        /// <summary>
        ///     从左侧返回指定长度的字符串
        /// </summary>
        /// <param name="this"></param>
        /// <param name="length">指定长度 不能小于 0</param>
        /// <exception cref="System.ArgumentOutOfRangeException"><paramref name="length"/> 不能小于 0 </exception>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// "1234567890".Left(3); // "123"
        ///         ]]>
        ///     </code>
        /// </example>
        public static string Left(this string @this, int length)
        {
            return @this != null && @this.Length > length ? @this.Substring(0, length) : @this;
        }

        /// <summary>
        ///     从右侧返回指定长度的字符串
        /// </summary>
        /// <param name="this"></param>
        /// <param name="length">指定长度 不能小于 0</param>
        /// <exception cref="System.ArgumentOutOfRangeException"><paramref name="length"/> 不能小于 0 </exception>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// "1234567890".Right(3); // "890"
        ///         ]]>
        ///     </code>
        /// </example>
        public static string Right(this string @this, int length)
        {
            return @this != null && @this.Length > length ? @this.Substring(@this.Length - length) : @this;
        }
    }
}