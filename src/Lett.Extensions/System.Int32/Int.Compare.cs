using System;

namespace Lett.Extensions
{
    /// <summary>
    ///     int 扩展方法 - 比较
    /// </summary>
    public static partial class IntExtensions
    {
        /// <summary>
        /// 是否偶数
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static bool IsEven(this int @this)
        {
            return @this % 2 == 0;
        }

        /// <summary>
        /// 是否奇数
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static bool IsOdd(this int @this)
        {
            return @this % 2 != 0;
        }
    }
}