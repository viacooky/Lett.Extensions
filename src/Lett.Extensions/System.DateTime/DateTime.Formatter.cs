using System;

namespace Lett.Extensions
{
    public static partial class Extensions
    {
        /// <summary>
        ///     格式化为 yyyy
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static string ToString_Year(this DateTime @this)
        {
            return @this.ToString("yyyy");
        }

        /// <summary>
        ///     格式化为 yy
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static string ToString_ShortYear(this DateTime @this)
        {
            return @this.ToString("yy");
        }

        /// <summary>
        ///     格式化为 yyyy-MM
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static string ToString_Month(this DateTime @this)
        {
            return @this.ToString("yyyy-MM");
        }

        /// <summary>
        ///     格式化为 yy-M
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static string ToString_ShortMonth(this DateTime @this)
        {
            return @this.ToString("yy-M");
        }

        /// <summary>
        ///     格式化为 yyyy-MM-dd
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static string ToString_Day(this DateTime @this)
        {
            return @this.ToString("yyyy-MM-dd");
        }

        /// <summary>
        ///     格式化为 yy-M-d
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static string ToString_ShortDay(this DateTime @this)
        {
            return @this.ToString("yy-M-d");
        }

        /// <summary>
        ///     格式化为 HH:mm:ss
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
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
        public static string ToString_ShortTime(this DateTime @this)
        {
            return @this.ToString("hh:mm:ss tt");
        }

        /// <summary>
        ///     格式化为 yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static string ToString_Base(this DateTime @this)
        {
            return @this.ToString("yyyy-MM-dd HH:mm:ss");
        }


        /// <summary>
        ///     格式化为 yyyy-MM-dd HH:mm:ss.fffffff
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static string ToString_Full(this DateTime @this)
        {
            return @this.ToString("yyyy-MM-dd HH:mm:ss.fffffff");
        }
    }
}