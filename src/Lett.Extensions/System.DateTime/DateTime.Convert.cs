using System;

namespace Lett.Extensions
{
    /// <summary>
    ///     DateTime 扩展方法
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
        /// <returns>返回一个新的<see cref="DateTime" /></returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="hour" />、<paramref name="minute" /> 和
        ///     <paramref name="second" /> 参数描述了一个无法表示的日期时间
        /// </exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt2 = new DateTime(2019, 4, 1, 1, 2, 3);
        /// var rs2 = dt2.SetTime(23, 11, 11, 999);
        ///         ]]>
        ///     </code>
        /// </example>
        public static DateTime SetTime(this DateTime @this, int hour, int minute, int second)
        {
            return @this.SetTime(hour, minute, second, 0);
        }

        /// <summary>
        ///     设置DateTime的time部分
        /// </summary>
        /// <param name="this"></param>
        /// <param name="hour">小时 (0-23) </param>
        /// <param name="minute">分钟 (0-59) </param>
        /// <param name="second">秒 (0-59) </param>
        /// <param name="millisecond">毫秒 (0-999) 默认0</param>
        /// <returns>返回一个新的<see cref="DateTime" /></returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="hour" />、<paramref name="minute" />、<paramref name="second" />、<paramref name="millisecond" /> 参数描述了一个无法表示的日期时间
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="millisecond" /> 的有效值不在0和999之间</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt2 = new DateTime(2019, 4, 1, 1, 2, 3);
        /// var rs2 = dt2.SetTime(23, 11, 11, 999);
        ///         ]]>
        ///     </code>
        /// </example>
        public static DateTime SetTime(this DateTime @this, int hour, int minute, int second, int millisecond)
        {
            return new DateTime(@this.Year, @this.Month, @this.Day, hour, minute, second, millisecond);
        }

        /// <summary>
        ///     获取 DateTime 的开始 (year-month-day 00:00:00.000)
        /// </summary>
        /// <param name="this"></param>
        /// <returns>返回一个新的<see cref="DateTime" /></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 1, 21, 11, 11, 123);
        /// var rs = dt.StartOfDay(); // rs == new DateTime(2019, 4, 1, 0, 0, 0, 000)
        ///         ]]>
        ///     </code>
        /// </example>
        public static DateTime StartOfDay(this DateTime @this)
        {
            return @this.SetTime(0, 0, 0);
        }

        /// <summary>
        ///     获取 DateTime 的结束 (year-month-day 23:59:59.999)
        /// </summary>
        /// <param name="this"></param>
        /// <returns>返回一个新的<see cref="DateTime" /></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 1, 1, 2, 3);
        /// var rs = dt.EndOfDay(); // rs == new DateTime(2019, 4, 1, 23, 59, 59, 999);
        ///         ]]>
        ///     </code>
        /// </example>
        public static DateTime EndOfDay(this DateTime @this)
        {
            return @this.SetTime(23, 59, 59, 999);
        }

        /// <summary>
        ///     获取本周开始 DateTime (year-month-day 00:00:00.000)
        /// </summary>
        /// <param name="this"></param>
        /// <param name="startOfWeek">设置每周的起始</param>
        /// <returns>返回一个新的<see cref="DateTime" /></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 1, 1, 2, 3);
        /// var rs = dt.StartOfWeek(DayOfWeek.Sunday); // 2019-03-31 00:00:00
        ///         ]]>
        ///     </code>
        /// </example>
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
        /// <returns>返回一个新的<see cref="DateTime" /></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt2 = new DateTime(2019, 4, 1, 1, 2, 3);
        /// var rs2 = dt.EndOfWeek(DayOfWeek.Friday); // 2019-04-04 23:59:59.999
        ///         ]]>
        ///     </code>
        /// </example>
        public static DateTime EndOfWeek(this DateTime @this, DayOfWeek startOfWeek)
        {
            return @this.StartOfWeek(startOfWeek).AddDays(6).EndOfDay();
        }

        /// <summary>
        ///     获取月的开始 DateTime (year-month-day 00:00:00.000)
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 12, 1, 2, 3);
        /// var rs = dt.StartOfMonth(); // 2019-04-01 00:00:00.000
        ///         ]]>
        ///     </code>
        /// </example>
        public static DateTime StartOfMonth(this DateTime @this)
        {
            return new DateTime(@this.Year, @this.Month, 1);
        }

        /// <summary>
        ///     获取月的结束 DateTime (year-month-day 23:59:59.999)
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 12, 1, 2, 3);
        /// var rs = dt.EndOfMonth(); // 2019-04-30 23:59:59.999
        ///         ]]>
        ///     </code>
        /// </example>
        public static DateTime EndOfMonth(this DateTime @this)
        {
            return @this.StartOfMonth().AddMonths(1).Subtract(new TimeSpan(0, 0, 0, 0, 1));
        }

        /// <summary>
        ///     获取年的开始 DateTime (year-month-day 00:00:00.000)
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 12, 1, 2, 3);
        /// var rs = dt.StartOfYear(); // 2019-01-01 00:00:00.000
        ///         ]]>
        ///     </code>
        /// </example>
        public static DateTime StartOfYear(this DateTime @this)
        {
            return new DateTime(@this.Year, 1, 1);
        }

        /// <summary>
        ///     获取年的结束 DateTime (year-month-day 23:59:59.999)
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 12, 1, 2, 3);
        /// var rs = dt.EndOfYear(); // 2019-12-31 23.59.59.999
        ///         ]]>
        ///     </code>
        /// </example>
        public static DateTime EndOfYear(this DateTime @this)
        {
            return @this.StartOfYear().AddYears(1).Subtract(new TimeSpan(0, 0, 0, 0, 1));
        }
    }
}