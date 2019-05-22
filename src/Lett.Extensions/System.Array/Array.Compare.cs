using System;

namespace Lett.Extensions
{
    /// <summary>
    ///     Array 扩展方法
    /// </summary>
    public static partial class ArrayExtensions
    {
        /// <summary>
        ///     是否包含索引
        /// </summary>
        /// <typeparam name="T">数组的元素类型</typeparam>
        /// <param name="this"></param>
        /// <param name="index">索引</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">数组为空</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var s = new[] {"aaa", "bbb"};
        /// s.ContainsIndex(0);  // true
        /// s.ContainsIndex(2);  // false
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool ContainsIndex<T>(this T[] @this, int index)
        {
            return 0 <= index && index < @this.Length;
        }

        /// <summary>
        ///     是否包含索引
        /// </summary>
        /// <param name="this"></param>
        /// <param name="index">索引</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">数组为空</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var s = new[] {"aaa", "bbb"};
        /// s.ContainsIndex(0);  // true
        /// s.ContainsIndex(2);  // false
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool ContainsIndex(this Array @this, int index)
        {
            return 0 <= index && index < @this.Length;
        }
    }
}