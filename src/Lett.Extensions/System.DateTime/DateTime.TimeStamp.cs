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
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 1, 11, 11, 11);
        /// dt.GetTotalDays(); // 17987.466099537036
        ///         ]]>
        ///     </code>
        /// </example>
        public static double GetTotalDays(this DateTime @this)
        {
            return (@this - OriginDateTime).TotalDays;
        }

        /// <summary>
        ///     获取时间戳的小时表示
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 1, 11, 11, 11);
        /// dt.GetTotalHours(); // 431699.18638888886
        ///         ]]>
        ///     </code>
        /// </example>
        public static double GetTotalHours(this DateTime @this)
        {
            return (@this - OriginDateTime).TotalHours;
        }

        /// <summary>
        ///     获取时间戳的分钟表示
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 1, 11, 11, 11);
        /// dt.GetTotalMinutes(); // 25901951.183333334
        ///         ]]>
        ///     </code>
        /// </example>
        public static double GetTotalMinutes(this DateTime @this)
        {
            return (@this - OriginDateTime).TotalMinutes;
        }

        /// <summary>
        ///     获取时间戳的秒表示
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 1, 11, 11, 11);
        /// dt.GetTotalSeconds(); // 1554117071
        ///         ]]>
        ///     </code>
        /// </example>
        public static double GetTotalSeconds(this DateTime @this)
        {
            return (@this - OriginDateTime).TotalSeconds;
        }

        /// <summary>
        ///     获取时间戳的毫秒表示
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 1, 11, 11, 11);
        /// dt.GetTotalMilliseconds(); // 1554117071000
        ///         ]]>
        ///     </code>
        /// </example>
        public static double GetTotalMilliseconds(this DateTime @this)
        {
            return (@this - OriginDateTime).TotalMilliseconds;
        }
    }
}