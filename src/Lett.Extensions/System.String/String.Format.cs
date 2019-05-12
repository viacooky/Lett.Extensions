﻿namespace Lett.Extensions
{
    /// <summary>
    ///     string 扩展方法 - 格式化
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        ///     格式化
        /// </summary>
        /// <param name="this"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        /// var tmp = "{0}-{1}";
        /// tmp.Format(new[]{"aaa","bbb"}); // "aaa-bbb" 
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
        /// <param name="length"></param>
        /// <exception cref="System.ArgumentOutOfRangeException">length 参数不允许小于0</exception>
        /// <returns></returns>
        public static string Left(this string @this, int length)
        {
            return @this != null && @this.Length > length ? @this.Substring(0, length) : @this;
        }

        /// <summary>
        ///     从右侧返回指定长度的字符串
        /// </summary>
        /// <param name="this"></param>
        /// <param name="length"></param>
        /// <exception cref="System.ArgumentOutOfRangeException">length 参数不允许小于0</exception>
        /// <returns></returns>
        public static string Right(this string @this, int length)
        {
            return @this != null && @this.Length > length ? @this.Substring(@this.Length - length) : @this;
        }
    }
}