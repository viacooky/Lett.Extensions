namespace Lett.Extensions
{
    /// <summary>
    ///     Int 扩展方法
    /// </summary>
    public static partial class IntExtensions
    {
        /// <summary>
        ///     是否偶数
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// 0.IsEven(); // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsEven(this int @this)
        {
            return @this.ToLong().IsEven();
        }

        /// <summary>
        ///     是否奇数
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// (-1).IsOdd(); // true
        ///         ]]>
        ///     </code>
        /// </example>
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
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// (-1).IsInRange(0, 10); // false
        /// 10.IsInRange(0, 10);   // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsInRange(this int @this, int min, int max)
        {
            return min <= @this && @this <= max;
        }
    }
}