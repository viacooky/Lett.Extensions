namespace Lett.Extensions
{
    /// <summary>
    ///     long 扩展方法 - 比较
    /// </summary>
    public static partial class LongExtensions
    {
        /// <summary>
        ///     是否偶数
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static bool IsEven(this long @this)
        {
            return @this % 2 == 0;
        }

        /// <summary>
        ///     是否奇数
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static bool IsOdd(this long @this)
        {
            return @this % 2 != 0;
        }

        /// <summary>
        ///     是否在指定范围内
        /// </summary>
        /// <param name="this"></param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns></returns>
        public static bool IsInRange(this long @this, long min, long max)
        {
            return min <= @this && @this <= max;
        }
    }
}