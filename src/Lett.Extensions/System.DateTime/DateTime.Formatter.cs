using System;

namespace Lett.Extensions
{
    /// <summary>
    ///     DateTime 扩展方法
    /// </summary>
    public static partial class DateTimeExtensions
    {
        /// <summary>
        ///     格式化为 yyyy
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 1, 21, 11, 11, 123);
        /// dt.ToString_Year(); // "2019"
        ///         ]]>
        ///     </code>
        /// </example>
        public static string ToString_Year(this DateTime @this)
        {
            return @this.ToString("yyyy");
        }

        /// <summary>
        ///     格式化为 yy
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 1, 21, 11, 11, 123);
        /// dt.ToString_ShortYear(); // "19"
        ///         ]]>
        ///     </code>
        /// </example>
        public static string ToString_ShortYear(this DateTime @this)
        {
            return @this.ToString("yy");
        }

        /// <summary>
        ///     格式化为 yyyy-MM
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 1, 21, 11, 11, 123);
        /// dt.ToString_Month(); // "2019-04"
        ///         ]]>
        ///     </code>
        /// </example>
        public static string ToString_Month(this DateTime @this)
        {
            return @this.ToString("yyyy-MM");
        }

        /// <summary>
        ///     格式化为 yy-M
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 1, 21, 11, 11, 123);
        /// dt.ToString_ShortMonth(); // "19-4"
        ///         ]]>
        ///     </code>
        /// </example>
        public static string ToString_ShortMonth(this DateTime @this)
        {
            return @this.ToString("yy-M");
        }

        /// <summary>
        ///     格式化为 yyyy-MM-dd
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 1, 21, 11, 11, 123);
        /// dt.ToString_Day(); // "2019-04-01"
        ///         ]]>
        ///     </code>
        /// </example>
        public static string ToString_Day(this DateTime @this)
        {
            return @this.ToString("yyyy-MM-dd");
        }

        /// <summary>
        ///     格式化为 yy-M-d
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 1, 21, 11, 11, 123);
        /// dt.ToString_ShortDay(); // "19-4-1"
        ///         ]]>
        ///     </code>
        /// </example>
        public static string ToString_ShortDay(this DateTime @this)
        {
            return @this.ToString("yy-M-d");
        }

        /// <summary>
        ///     格式化为 HH:mm:ss
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 1, 21, 11, 11, 123);
        /// dt.ToString_Time(); // "21:11:11"
        ///         ]]>
        ///     </code>
        /// </example>
        public static string ToString_Time(this DateTime @this)
        {
            return @this.ToString("HH:mm:ss");
        }

        /// <summary>
        ///     格式化为 hh:mm:ss tt
        ///     eg. 11:23:02 PM
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 1, 21, 11, 11, 123);
        /// dt.ToString_ShortTime(); // "09:11:11 PM"
        ///         ]]>
        ///     </code>
        /// </example>
        public static string ToString_ShortTime(this DateTime @this)
        {
            return @this.ToString("hh:mm:ss tt");
        }

        /// <summary>
        ///     格式化为 yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 1, 21, 11, 11, 123);
        /// dt.ToString_Base(); // "2019-04-01 21:11:11"
        ///         ]]>
        ///     </code>
        /// </example>
        public static string ToString_Base(this DateTime @this)
        {
            return @this.ToString("yyyy-MM-dd HH:mm:ss");
        }


        /// <summary>
        ///     格式化为 yyyy-MM-dd HH:mm:ss.fffffff
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DateTime(2019, 4, 1, 21, 11, 11, 123);
        /// dt.ToString_Full(); // "2019-04-01 21:11:11.1230000"
        ///         ]]>
        ///     </code>
        /// </example>
        public static string ToString_Full(this DateTime @this)
        {
            return @this.ToString("yyyy-MM-dd HH:mm:ss.fffffff");
        }
    }
}