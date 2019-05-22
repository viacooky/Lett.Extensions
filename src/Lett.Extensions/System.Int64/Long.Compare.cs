namespace Lett.Extensions
{
    /// <summary>
    ///     Long 扩展方法
    /// </summary>
    public static partial class LongExtensions
    {
        /// <summary>
        ///     是否偶数
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// 0L.IsEven(); // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsEven(this long @this)
        {
            return @this % 2 == 0;
        }

        /// <summary>
        ///     是否奇数
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// (-1L).IsOdd(); // true
        ///         ]]>
        ///     </code>
        /// </example>
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
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// (-1L).IsInRange(0, 10); // false
        /// 10L.IsInRange(0, 10);   // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsInRange(this long @this, long min, long max)
        {
            return min <= @this && @this <= max;
        }
    }
}