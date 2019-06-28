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
        /// <exception cref="System.ArgumentOutOfRangeException"><paramref name="length" /> 不能小于 0 </exception>
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
        /// <exception cref="System.ArgumentOutOfRangeException"><paramref name="length" /> 不能小于 0 </exception>
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


        /// <summary>
        ///     <para>如果字符串不包含指定前缀，则添加前缀</para>
        ///     <para>默认不区分大小写</para>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="prefix">前缀</param>
        /// <param name="stringComparison">字符串比较规则 默认使用 <see cref="StringComparison.OrdinalIgnoreCase" /> </param>
        /// <exception cref="ArgumentNullException"><paramref name="this" /> 不允许为空</exception>
        /// <exception cref="ArgumentNullException"><paramref name="prefix" /> 不允许为空</exception>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var rs1  = "aa".AppendPrefixIfNotExist("t_");                               // t_aa
        /// 
        /// var rs2  = "T_bb".AppendPrefixIfNotExist("t_");                             // T_bb
        /// 
        /// var rs3  = "T_cc".AppendPrefixIfNotExist("t_", StringComparison.Ordinal);   // t_T_cc
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// "T_cc".AppendPrefixIfNotExist(null);         // throw ArgumentNullException  prefix is null
        /// 
        /// default(string).AppendPrefixIfNotExist("d"); // throw ArgumentNullException  @this is null
        ///         ]]>
        ///     </code>
        /// </example>
        public static string AppendPrefixIfNotExist(this string @this, string prefix, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this), "不允许为空");
            if (prefix == null) throw new ArgumentNullException(nameof(prefix), "不允许为空");
            return @this.StartsWith(prefix, stringComparison)
                ? @this
                : $"{prefix}{@this}";
        }

        /// <summary>
        ///     <para>如果字符串不包含指定后缀，则添加后缀</para>
        ///     <para>默认不区分大小写</para>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="suffix">后缀</param>
        /// <param name="stringComparison">字符串比较规则 默认使用 <see cref="StringComparison.OrdinalIgnoreCase" /> </param>
        /// <exception cref="ArgumentNullException"><paramref name="this" /> 不允许为空</exception>
        /// <exception cref="ArgumentNullException"><paramref name="suffix" /> 不允许为空</exception>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var rs1  = "aa".AppendSuffixIfNotExist("_t");                               // aa_t
        /// 
        /// var rs2  = "bb_T".AppendSuffixIfNotExist("_t");                             // bb_T
        /// 
        /// var rs3  = "cc_T".AppendSuffixIfNotExist("_t", StringComparison.Ordinal);   // cc_T_t
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// "cc_T".AppendSuffixIfNotExist(null);            // throw ArgumentNullException suffix is null
        /// 
        /// default(string).AppendSuffixIfNotExist("_t");   // throw ArgumentNullException @this is null
        ///         ]]>
        ///     </code>
        /// </example>
        public static string AppendSuffixIfNotExist(this string @this, string suffix, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this), "不允许为空");
            if (suffix == null) throw new ArgumentNullException(nameof(suffix), "不允许为空");
            return @this.EndsWith(suffix, stringComparison)
                ? @this
                : $"{@this}{suffix}";
        }
    }
}