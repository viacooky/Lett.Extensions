using System;

namespace Lett.Extensions
{
    /// <summary>
    ///     DateTime 扩展方法 - 转换
    /// </summary>
    public static partial class DateTimeExtensions
    {
        /// <summary>
        ///     设置DateTime的time部分
        /// </summary>
        /// <param name="this"></param>
        /// <param name="hour">小时 (0-23) </param>
        /// <param name="minute">分钟 (0-59) </param>
        /// <param name="second">秒 (0-59) </param>
        /// <param name="millisecond">毫秒 (0-999) 默认0</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">en:Hour, Minute, and Second parameters describe an un-representable DateTime. (小时、分钟和秒参数描述了一个无法表示的日期时间。)</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Valid values are between 0 and 999, inclusive. (millisecond 的有效值在0和999之间。)</exception>
        public static DateTime SetTime(this DateTime @this, int hour, int minute, int second, int millisecond = 0)
        {
            return new DateTime(@this.Year, @this.Month, @this.Day, hour, minute, second, millisecond);
        }

        /// <summary>
        ///     获取 DateTime 的开始 (year-month-day 00:00:00.000)
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static DateTime StartOfDay(this DateTime @this)
        {
            return @this.SetTime(0, 0, 0);
        }

        /// <summary>
        ///     获取 DateTime 的结束 (year-month-day 23:59:59.999)
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static DateTime EndOfDay(this DateTime @this)
        {
            return @this.SetTime(23, 59, 59, 999);
        }


        /// <summary>
        ///     获取本周开始 DateTime (year-month-day 00:00:00.000)
        /// </summary>
        /// <param name="this"></param>
        /// <param name="startOfWeek">设置每周的起始</param>
        /// <returns></returns>
        public static DateTime StartOfWeek(this DateTime @this, DayOfWeek startOfWeek)
        {
            var diff = @this.DayOfWeek - startOfWeek;
            return @this.AddDays(-1 * (diff < 0 ? diff + 7 : diff)).Date.StartOfDay();
        }

        /// <summary>
        ///     获取本周结束的 DateTime (year-month-day 23:59:59.999)
        /// </summary>
        /// <param name="this"></param>
        /// <param name="startOfWeek">设置每周的起始</param>
        /// <returns></returns>
        public static DateTime EndOfWeek(this DateTime @this, DayOfWeek startOfWeek)
        {
            return @this.StartOfWeek(startOfWeek).AddDays(6).EndOfDay();
        }
    }
}