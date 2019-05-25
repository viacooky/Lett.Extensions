using System;
using System.Collections.Generic;
using System.Linq;

namespace Lett.Extensions
{
    /// <summary>
    ///     IEnumerable 扩展方法
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static class IEnumerableExtensions
    {
        /// <summary>
        ///     是否空或空集合
        /// </summary>
        /// <param name="this"></param>
        /// <typeparam name="T">集合中元素的类型</typeparam>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var arr = new[] {"aa", "bb"};
        /// var rs = arr.IsNullOrEmpty(); // false
        ///
        /// var arr2 = new string[] { };
        /// var rs2 = arr.IsNullOrEmpty(); // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> @this)
        {
            return @this == null || !@this.Any();
        }

        /// <summary>
        ///     是否包含任一元素
        /// </summary>
        /// <param name="this"></param>
        /// <param name="items">需要进行判断的元素集合</param>
        /// <typeparam name="T">集合中元素的类型</typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="this" /> is null </exception>
        /// <exception cref="ArgumentNullException"><paramref name="items" /> is null </exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var arr = new[] {"aa", "bb"};
        /// var match = new[] {"aa"};
        /// var rs = arr.ContainsAny(match); // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool ContainsAny<T>(this IEnumerable<T> @this, IEnumerable<T> items)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this), $"{nameof(@this)} is null");
            if (items == null) throw new ArgumentNullException(nameof(items), $"{nameof(items)} is null");
            return @this.Any(items.Contains);
        }

        /// <summary>
        ///     是否包含全部元素
        /// </summary>
        /// <param name="this"></param>
        /// <param name="items">需要进行判断的元素集合</param>
        /// <typeparam name="T">集合中元素的类型</typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="this" /> is null </exception>
        /// <exception cref="ArgumentNullException"><paramref name="items" /> is null </exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var arr = new[] {"aa", "bb"};
        /// var match = new[] {"aa"};
        /// var match2 = new[] {"aa", "bb"};
        /// var rs = arr.ContainsAll(match); // false;
        /// var rs2 = arr.ContainsAll(match2); // true;
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool ContainsAll<T>(this IEnumerable<T> @this, IEnumerable<T> items)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this), $"{nameof(@this)} is null");
            if (items == null) throw new ArgumentNullException(nameof(items), $"{nameof(items)} is null");
            return @this.All(items.Contains);
        }
    }
}