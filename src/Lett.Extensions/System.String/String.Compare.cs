using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lett.Extensions
{
    public static partial class Extensions
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
    }
}