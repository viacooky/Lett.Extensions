using System.Text.RegularExpressions;

namespace Lett.Extensions
{
    /// <summary>
    ///     string 扩展方法 - 正则
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        ///     正则表达式 - 是否匹配
        /// </summary>
        /// <param name="this">源字符串</param>
        /// <param name="pattern">正则表达式</param>
        /// <param name="regexOption"><see cref="MatchEvaluator" />正则表达式选项，默认值：RegexOptions.None</param>
        /// <returns></returns>
        public static bool RegexIsMatch(this string @this, string pattern, RegexOptions regexOption = RegexOptions.None)
        {
            return Regex.IsMatch(@this, pattern, regexOption);
        }

        /// <summary>
        ///     正则表达式匹配 - 单个匹配对象
        /// </summary>
        /// <param name="this">源字符串</param>
        /// <param name="pattern">正则表达式</param>
        /// <param name="regexOption"><see cref="RegexOptions" />正则表达式选项，默认值：RegexOptions.None</param>
        /// <returns>单个匹配对象</returns>
        public static Match RegexMatch(this string @this, string pattern, RegexOptions regexOption = RegexOptions.None)
        {
            return Regex.Match(@this, pattern, regexOption);
        }

        /// <summary>
        ///     正则表达式匹配 - 所有匹配对象
        /// </summary>
        /// <param name="this">源字符串</param>
        /// <param name="pattern">正则表达式</param>
        /// <param name="regexOption"><see cref="RegexOptions" />正则表达式选项，默认值：RegexOptions.None</param>
        /// <returns>所有匹配对象</returns>
        public static MatchCollection RegexMatches(this string @this, string pattern, RegexOptions regexOption = RegexOptions.None)
        {
            return Regex.Matches(@this, pattern, regexOption);
        }

        /// <summary>
        ///     正则表达式拆分字符串
        /// </summary>
        /// <param name="this">源字符串</param>
        /// <param name="pattern">正则表达式</param>
        /// <param name="regexOption"><see cref="RegexOptions" />正则表达式选项，默认值：RegexOptions.None</param>
        /// <returns></returns>
        public static string[] RegexSplit(this string @this, string pattern, RegexOptions regexOption = RegexOptions.None)
        {
            return Regex.Split(@this, pattern, regexOption);
        }

        /// <summary>
        ///     正则表达式替换字符串
        /// </summary>
        /// <param name="this">源字符串</param>
        /// <param name="pattern">正则表达式</param>
        /// <param name="replacement">替换字符串</param>
        /// <param name="regexOption"><see cref="RegexOptions" />正则表达式选项，默认值：RegexOptions.None<see cref="RegexOptions" /></param>
        /// <returns></returns>
        public static string RegexReplace(this string @this, string pattern, string replacement, RegexOptions regexOption = RegexOptions.None)
        {
            return Regex.Replace(@this, pattern, replacement, regexOption);
        }

        /// <summary>
        ///     正则表达式替换字符串
        /// </summary>
        /// <param name="this">源字符串</param>
        /// <param name="pattern">正则表达式</param>
        /// <param name="evaluator"><see cref="MatchEvaluator" />委托表示的方法返回的字符串</param>
        /// <returns></returns>
        public static string RegexReplace(this string @this, string pattern, MatchEvaluator evaluator)
        {
            return Regex.Replace(@this, pattern, evaluator);
        }
    }
}