using System;
using System.Text;

namespace Lett.Extensions
{
    /// <summary>
    ///     string 扩展方法 - 加密
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        ///     BASE64编码
        ///     ps: 转换失败返回NULL
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static string Base64Encode(this string @this)
        {
            try
            {
                var encoding = Encoding.UTF8;
                var bytes    = encoding.GetBytes(@this);
                return Convert.ToBase64String(bytes);
            }
            catch { return null; }
        }

        /// <summary>
        ///     BASE64解码
        ///     ps: 转换失败返回NULL
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static string Base64Decode(this string @this)
        {
            try
            {
                var encoding = Encoding.UTF8;
                var bytes    = Convert.FromBase64String(@this);
                return encoding.GetString(bytes);
            }
            catch { return null; }
        }
    }
}