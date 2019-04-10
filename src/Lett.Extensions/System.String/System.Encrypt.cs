using System;
using System.Security.Cryptography;
using System.Text;

namespace Lett.Extensions
{
    public static partial class Extensions
    {
        /// <summary>
        ///     获取MD5
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static string ToMd5String(this string @this)
        {
            using (var md5 = MD5.Create())
            {
                var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(@this));
                var sb    = new StringBuilder();
                foreach (var t in bytes) sb.Append(t.ToString("x2"));

                return sb.ToString();
            }
        }

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
            catch
            {
                return null;
            }
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
            catch
            {
                return null;
            }
        }
    }
}