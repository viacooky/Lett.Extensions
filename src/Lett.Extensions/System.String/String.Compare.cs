using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Lett.Extensions
{
    /// <summary>
    ///     string 扩展方法
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        ///     是否Email
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><permission cref="@this"></permission> 字符串为空 </exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="RegexMatchTimeoutException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// "abc@qqq.com".IsEmail();  // true
        /// "abc@qqq#.com".IsEmail(); // false
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsEmail(this string @this)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this), "字符串为空");
            var match = Regex.Match(@this, @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            return match.Success;
        }

        /// <summary>
        ///     是否URL
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// "http://sdf.com".IsUrl(); // true
        /// "http://sdf.c.dddd.cccc.saaa.com".IsUrl(); // true
        /// "www.sdf.com".IsUrl(); // false
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsUrl(this string @this)
        {
            try
            {
                // ReSharper disable once ObjectCreationAsStatement
                new Uri(@this);
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        ///     是否全部大写
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// "ABC".IsUpper(); // true
        /// "ABd".IsUpper(); // false
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsUpper(this string @this)
        {
            return @this.All(char.IsUpper);
        }

        /// <summary>
        ///     是否全部小写
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// "abcddd".IsLower(); // true;
        /// "abDD".IsLower();   // false
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsLower(this string @this)
        {
            return @this.All(char.IsLower);
        }

        /// <summary>
        ///     <para>忽略大小写比较</para>
        ///     <para>使用 <see cref="StringComparison.CurrentCultureIgnoreCase" /></para>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="value">需要进行比较的字符串</param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// "aaa".IgnoreCaseEquals("AaA"); // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IgnoreCaseEquals(this string @this, string value)
        {
            return @this.Equals(value, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        ///     是否 null 或 string.Empty
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// " ".IsNullOrEmpty(); // false
        /// "".IsNullOrEmpty();  // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsNullOrEmpty(this string @this)
        {
            return string.IsNullOrEmpty(@this);
        }

        /// <summary>
        ///     是否null或空白
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// "   ".IsNullOrWhiteSpace(); // true
        /// "\r".IsNullOrWhiteSpace();  // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsNullOrWhiteSpace(this string @this)
        {
            return string.IsNullOrWhiteSpace(@this);
        }

        /// <summary>
        ///     <para>是否全部包含</para>
        ///     <para>使用 <see cref="StringComparison.CurrentCultureIgnoreCase" /> 比较</para>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="values">需要进行判断的字符串集合</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="values" /> is null </exception>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var a = "aaabbbccc";
        /// var b = new[] {"aaa", "bbb"};
        /// a.ContainsAll(b);  // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool ContainsAll(this string @this, IEnumerable<string> values)
        {
            return @this.ContainsAll(values, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        ///     是否全部包含
        /// </summary>
        /// <param name="this"></param>
        /// <param name="values">需要进行判断的字符串集合</param>
        /// <param name="comparisonType">字符串比较规则</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="values" /> is null </exception>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var a = "aaabbbccc";
        /// var b = new[] {"aaa", "bbb"};
        /// a.ContainsAll(b);  // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool ContainsAll(this string @this, IEnumerable<string> values, StringComparison comparisonType)
        {
            return values.All(s => @this.IndexOf(s, comparisonType) >= 0);
        }

        /// <summary>
        ///     是否包含任意一个
        /// </summary>
        /// <param name="this"></param>
        /// <param name="values">需要进行判断的字符串集合</param>
        /// <param name="comparisonType">字符串比较规则</param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var a = "aaabbbccc";
        /// var b = new[] {"a", "dd", "eee"};
        /// a.ContainsAny(b); // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool ContainsAny(this string @this, IEnumerable<string> values, StringComparison comparisonType)
        {
            return values.Any(s => @this.IndexOf(s, comparisonType) >= 0);
        }

        /// <summary>
        ///     <para>是否包含任意一个</para>
        ///     <para>使用 <see cref="StringComparison.CurrentCultureIgnoreCase" /> 判断</para>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="values">需要进行判断的字符串集合</param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var a = "aaabbbccc";
        /// var b = new[] {"a", "dd", "eee"};
        /// a.ContainsAny(b); // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool ContainsAny(this string @this, IEnumerable<string> values)
        {
            return @this.ContainsAny(values, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        ///     <para>使用通配符比较字符串是否相似</para>
        ///     <para>通配符 <c>*</c></para>
        ///     <para>特殊字符 用 \ 转义</para>
        ///     <para>正则匹配时，使用 <see cref="RegexOptions.Singleline" /> </para>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="pattern">通配符表达式，为 null 时返回 false</param>
        /// <returns>
        ///     <para><paramref name="this" />为 null 时 返回 false</para>
        ///     <para><paramref name="pattern" />为 null 时 返回 false</para>
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="RegexMatchTimeoutException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var test1 = "abcdefg\r\nabcdefghijk";
        /// test1.IsLike("abc*");     // true
        /// test1.IsLike("a*");       // true
        /// test1.IsLike("*ijk");     // true
        /// test1.IsLike("abc*fg*");  // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsLike(this string @this, string pattern)
        {
            if (@this == null) return false;
            if (pattern == null) return false;
            if (@this == pattern) return true;
            if (!pattern.Contains('*')) return false;

            var newPattern = new StringBuilder();
            for (var i = 0; i < pattern.Length; i++)
                if (i != 0 && pattern[i] == '*' && pattern[i - 1] != '\\')
                    newPattern.Append(".*");
                else
                    newPattern.Append(pattern[i]);

            var regexPattern = @"^{0}$".Format(newPattern.ToString());
            return @this.RegexIsMatch(regexPattern, RegexOptions.Singleline);
        }

        /// <summary>
        ///     是否空字符串
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var a = "";
        /// var b = " ";
        ///
        /// a.IsEmpty(); // true
        /// b.IsEmpty(); // false
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsEmpty(this string @this)
        {
            return @this.Equals(string.Empty);
        }

        /// <summary>
        ///     是否空白字符串
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var a = "";
        /// var b = " ";
        /// var c = "\r";
        /// var d = "\t";
        /// var e = "\n";
        /// var f = "\r \t";
        /// 
        /// a.IsWhiteSpace(); // true
        /// b.IsWhiteSpace(); // true
        /// c.IsWhiteSpace(); // true
        /// d.IsWhiteSpace(); // true
        /// e.IsWhiteSpace(); // true
        /// f.IsWhiteSpace(); // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsWhiteSpace(this string @this)
        {
            return @this.All(char.IsWhiteSpace);
        }
    }
}