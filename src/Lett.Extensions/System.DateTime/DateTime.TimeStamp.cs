using System;

namespace Lett.Extensions
{
    /// <summary>
    ///     DateTime 扩展方法 - 时间戳
    /// </summary>
    public static partial class DateTimeExtensions
    {
        private static readonly DateTime OriginDateTime = new DateTime(1970, 1, 1, 0, 0, 0);

        /// <summary>
        ///     获取时间戳的日表示
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static double GetTotalDays(this DateTime @this)
        {
            return (@this - OriginDateTime).TotalDays;
        }

        /// <summary>
        ///     获取时间戳的小时表示
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static double GetTotalHours(this DateTime @this)
        {
            return (@this - OriginDateTime).TotalHours;
        }

        /// <summary>
        ///     获取时间戳的分钟表示
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static double GetTotalMinutes(this DateTime @this)
        {
            return (@this - OriginDateTime).TotalMinutes;
        }

        /// <summary>
        ///     获取时间戳的秒表示
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static double GetTotalSeconds(this DateTime @this)
        {
            return (@this - OriginDateTime).TotalSeconds;
        }

        /// <summary>
        ///     获取时间戳的毫秒表示
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static double GetTotalMilliseconds(this DateTime @this)
        {
            return (@this - OriginDateTime).TotalMilliseconds;
        }
    }
}