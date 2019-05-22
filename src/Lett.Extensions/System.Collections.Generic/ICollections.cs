using System;
using System.Collections.Generic;

namespace Lett.Extensions
{
    /// <summary>
    ///     ICollections 扩展方法
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static class ICollectionsExtensions
    {
        /// <summary>
        ///     如果不包含，则添加
        /// </summary>
        /// <param name="this"></param>
        /// <param name="item">匹配项</param>
        /// <typeparam name="T">集合中元素的类型</typeparam>
        /// <exception cref="NotSupportedException">
        ///     <paramref name="this" />
        /// </exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var list = new List<string> {"aa", "bb"};
        /// list.AddIfNotContains("cc");
        /// list.AddIfNotContains("aa");
        /// // {"aa", "bb", "cc"}
        ///         ]]>
        ///     </code>
        /// </example>
        public static void AddIfNotContains<T>(this ICollection<T> @this, T item)
        {
            if (@this != null && !@this.Contains(item)) @this.Add(item);
        }

        /// <summary>
        ///     如果不包含，则添加
        /// </summary>
        /// <param name="this"></param>
        /// <param name="items">匹配项集合</param>
        /// <typeparam name="T">集合中元素的类型</typeparam>
        /// <exception cref="NotSupportedException">
        ///     <paramref name="this" />
        /// </exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var list = new List<string> {"aa", "bb"};
        /// var appendList = new[] {"cc", "aa"};
        /// list.AddIfNotContains(appendList);
        /// // {"aa", "bb", "cc"}
        ///         ]]>
        ///     </code>
        /// </example>
        public static void AddIfNotContains<T>(this ICollection<T> @this, ICollection<T> items)
        {
            if (@this == null || items == null) return;
            foreach (var item in items) @this.AddIfNotContains(item);
        }
    }
}