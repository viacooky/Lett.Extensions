using System;

namespace Lett.Extensions
{
    /// <summary>
    ///     Array 扩展方法
    /// </summary>
    public static partial class ArrayExtensions
    {
        /// <summary>
        ///     反转数组中元素的顺序
        /// </summary>
        /// <param name="this"></param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="this" />
        /// </exception>
        /// <exception cref="RankException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var s = new[] {"a", "A", "B", "b", "0"};
        /// s.Reverse(); // {"0", "b", "B", "A", "a"}
        ///         ]]>
        ///     </code>
        /// </example>
        public static void Reverse(this Array @this)
        {
            Array.Reverse(@this);
        }

        /// <summary>
        ///     反转数组中元素的顺序
        /// </summary>
        /// <param name="this"></param>
        /// <typeparam name="T">数组的元素类型</typeparam>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="this" />
        /// </exception>
        /// <exception cref="RankException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var s = new[] {"a", "A", "B", "b", "0"};
        /// s.Reverse(); // {"0", "b", "B", "A", "a"}
        ///         ]]>
        ///     </code>
        /// </example>
        public static void Reverse<T>(this T[] @this)
        {
            Array.Reverse(@this);
        }

        /// <summary>
        ///     反转数组中元素的顺序
        /// </summary>
        /// <param name="this"></param>
        /// <param name="index">要反转的部分的起始索引</param>
        /// <param name="length">要反转的部分中的元素数</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="this" />
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="RankException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var s =  new[] {"a", "A", "B", "b", "0"};
        /// s.Reverse(2, 3); // {"a", "A", "0", "b", "B"}
        ///         ]]>
        ///     </code>
        /// </example>
        public static void Reverse(this Array @this, int index, int length)
        {
            Array.Reverse(@this, index, length);
        }

        /// <summary>
        ///     反转数组中元素的顺序
        /// </summary>
        /// <param name="this">当前 Array 泛型接口</param>
        /// <param name="index">要反转的部分的起始索引</param>
        /// <param name="length">要反转的部分中的元素数</param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="this" />
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="RankException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var s =  new[] {"a", "A", "B", "b", "0"};
        /// s.Reverse(2, 3); // {"a", "A", "0", "b", "B"}
        ///         ]]>
        ///     </code>
        /// </example>
        public static void Reverse<T>(this T[] @this, int index, int length)
        {
            Array.Reverse(@this, index, length);
        }
    }
}