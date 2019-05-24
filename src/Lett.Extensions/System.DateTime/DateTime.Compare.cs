using System;

namespace Lett.Extensions
{
    /// <summary>
    ///     DateTime 扩展方法
    /// </summary>
    public static partial class DateTimeExtensions
    {
        /// <summary>
        ///     是否在指定日期之间
        /// </summary>
        /// <param name="this"></param>
        /// <param name="startDateTime">开始时间</param>
        /// <param name="endDateTime">结束时间</param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019,4,1);
        /// var startDate = new DateTime(2019,4,1,0,0,1);
        /// var endDate = new DateTime(2019,5,1);
        /// dt.IsBetween(startDateTime, endDateTime);  // false
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsBetween(this DateTime @this, DateTime startDateTime, DateTime endDateTime)
        {
            return startDateTime <= @this && @this <= endDateTime;
        }

        /// <summary>
        ///     是否当天
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = DateTime.Now;
        /// dt.IsToday(); // true
        /// var dt2 = new DateTime(2019,1,1);
        /// dt2.IsToday(); // false
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsToday(this DateTime @this)
        {
            return @this.Date == DateTime.Today;
        }

        /// <summary>
        ///     是否工作日 (周一至周五)
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019,5,4);
        /// dt.IsWeekDay();  // false
        /// var dt2 = new DateTime(2019,5,1);
        /// dt2.IsWeekDay(); // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsWeekDay(this DateTime @this)
        {
            return @this.DayOfWeek != DayOfWeek.Saturday && @this.DayOfWeek != DayOfWeek.Sunday;
        }
    }
}