using System;
using System.Text.RegularExpressions;

namespace Lett.Extensions
{
    /// <summary>
    ///     string 扩展方法
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        ///     正则表达式 - 是否匹配
        /// </summary>
        /// <param name="this"></param>
        /// <param name="pattern">正则表达式</param>
        /// <param name="regexOption">正则表达式选项，默认值：<see cref="RegexOptions.None" /></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="RegexMatchTimeoutException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var source = "abcdefg\r\nabcdefghijk";
        /// source.RegexIsMatch(@"^abc.*\r$", RegexOptions.Multiline); // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool RegexIsMatch(this string @this, string pattern, RegexOptions regexOption = RegexOptions.None)
        {
            return Regex.IsMatch(@this, pattern, regexOption);
        }

        /// <summary>
        ///     正则表达式 - 单个匹配对象
        /// </summary>
        /// <param name="this"></param>
        /// <param name="pattern">正则表达式</param>
        /// <param name="regexOption">正则表达式选项，默认值：<see cref="RegexOptions.None" /></param>
        /// <returns>单个匹配对象</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="RegexMatchTimeoutException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var str = "aaaabaaaabaaaa";
        /// var match = str.RegexMatch("b"); // match.Success == true;
        ///         ]]>
        ///     </code>
        /// </example>
        public static Match RegexMatch(this string @this, string pattern, RegexOptions regexOption = RegexOptions.None)
        {
            return Regex.Match(@this, pattern, regexOption);
        }

        /// <summary>
        ///     正则表达式 - 所有匹配对象
        /// </summary>
        /// <param name="this">源字符串</param>
        /// <param name="pattern">正则表达式</param>
        /// <param name="regexOption">正则表达式选项，默认值：<see cref="RegexOptions.None" /></param>
        /// <returns>所有匹配对象</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var str   = "aaaabaaaabaaaa";
        /// var matches = str.RegexMatches(@"aaaab");  // matches.Count == 2
        ///         ]]>
        ///     </code>
        /// </example>
        public static MatchCollection RegexMatches(this string @this, string pattern, RegexOptions regexOption = RegexOptions.None)
        {
            return Regex.Matches(@this, pattern, regexOption);
        }

        /// <summary>
        ///     正则表达式 - 拆分字符串
        /// </summary>
        /// <param name="this">源字符串</param>
        /// <param name="pattern">正则表达式</param>
        /// <param name="regexOption">正则表达式选项，默认值：<see cref="RegexOptions.None" /></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="RegexMatchTimeoutException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        ///  var str = "aaaa.bbbb.cccc";
        /// var rs = str.RegexSplit(@"\."); // rs.Count == 3
        ///         ]]>
        ///     </code>
        /// </example>
        public static string[] RegexSplit(this string @this, string pattern, RegexOptions regexOption = RegexOptions.None)
        {
            return Regex.Split(@this, pattern, regexOption);
        }

        /// <summary>
        ///     正则表达式 - 替换字符串
        /// </summary>
        /// <param name="this">源字符串</param>
        /// <param name="pattern">正则表达式</param>
        /// <param name="replacement">替换字符串</param>
        /// <param name="regexOption">正则表达式选项，默认值：<see cref="RegexOptions.None" /></param>
        /// <returns></returns>
        public static string RegexReplace(this string @this, string pattern, string replacement, RegexOptions regexOption = RegexOptions.None)
        {
            return Regex.Replace(@this, pattern, replacement, regexOption);
        }

        /// <summary>
        ///     正则表达式 - 替换字符串
        /// </summary>
        /// <param name="this">源字符串</param>
        /// <param name="pattern">正则表达式</param>
        /// <param name="evaluator">委托表示的方法返回的字符串</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="RegexMatchTimeoutException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var rs2 = test1.RegexReplace(@"\.", match => match.Value + "@");  // "aaaa.@bbbb.@cccc"
        ///         ]]>
        ///     </code>
        /// </example>
        public static string RegexReplace(this string @this, string pattern, MatchEvaluator evaluator)
        {
            return Regex.Replace(@this, pattern, evaluator);
        }
    }
}