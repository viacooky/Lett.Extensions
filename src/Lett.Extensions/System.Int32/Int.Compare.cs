namespace Lett.Extensions
{
    /// <summary>
    ///     int 扩展方法 - 比较
    /// </summary>
    public static partial class IntExtensions
    {
        /// <summary>
        ///     是否偶数
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static bool IsEven(this int @this)
        {
            return @this.ToLong().IsEven();
        }

        /// <summary>
        ///     是否奇数
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static bool IsOdd(this int @this)
        {
            return @this.ToLong().IsOdd();
        }

        /// <summary>
        ///     是否在指定范围内
        /// </summary>
        /// <param name="this"></param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns></returns>
        public static bool IsInRange(this int @this, int min, int max)
        {
            return min <= @this && @this <= max;
        }
    }
}