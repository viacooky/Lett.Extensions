using System;

namespace Lett.Extensions
{
    /// <summary>
    ///     DateTime 扩展方法 - 操作
    /// </summary>
    public static partial class DateTimeExtensions
    {
        /// <summary>
        ///     移除时间部分
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static DateTime RemoveTimePart(this DateTime @this)
        {
            return new DateTime(@this.Year, @this.Month, @this.Day);
        }
    }
}