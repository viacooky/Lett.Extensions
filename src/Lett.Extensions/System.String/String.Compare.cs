using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Lett.Extensions
{
    /// <summary>
    ///     string 扩展方法 - 比较
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        ///     是否Email
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static bool IsEmail(this string @this)
        {
            var match = Regex.Match(@this, @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            return match.Success;
        }

        /// <summary>
        ///     是否URL
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static bool IsUrl(this string @this)
        {
            try
            {
                var uri = new Uri(@this);
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        ///     是否大写
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static bool IsUpper(this string @this)
        {
            return @this.All(char.IsUpper);
        }

        /// <summary>
        ///     是否小写
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static bool IsLower(this string @this)
        {
            return @this.All(char.IsLower);
        }

        /// <summary>
        ///     忽略大小写比较
        /// </summary>
        /// <param name="this"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IgnoreCaseEquals(this string @this, string value)
        {
            return @this.Equals(value, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        ///     是否null或空白
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string @this)
        {
            return string.IsNullOrWhiteSpace(@this);
        }

        /// <summary>
        ///     是否全部包含，默认不区分大小写
        /// </summary>
        /// <param name="this"></param>
        /// <param name="values"></param>
        /// <param name="comparisonType"></param>
        /// <returns></returns>
        public static bool ContainsAll(this string @this, IEnumerable<string> values, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase)
        {
            return values.All(s => @this.IndexOf(s, comparisonType) >= 0);
        }

        /// <summary>
        ///     是否包含任意一个，默认不区分大小写
        /// </summary>
        /// <param name="this"></param>
        /// <param name="values"></param>
        /// <param name="comparisonType"></param>
        /// <returns></returns>
        public static bool ContainsAny(this string @this, IEnumerable<string> values, StringComparison comparisonType = StringComparison.CurrentCultureIgnoreCase)
        {
            return values.Any(s => @this.IndexOf(s, comparisonType) >= 0);
        }

        /// <summary>
        ///     *通配符比较是否相似 (特殊字符 用 \ 转义)
        /// </summary>
        /// <param name="this">源字符串，为 null 时返回 false</param>
        /// <param name="pattern">通配符表达式，为 null 时返回 false</param>
        /// <returns></returns>
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
    }
}