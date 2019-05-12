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
        /// <param name="this">集合</param>
        /// <param name="item">项</param>
        /// <typeparam name="T">类型</typeparam>
        public static void AddIfNotContains<T>(this ICollection<T> @this, T item)
        {
            if (@this != null && !@this.Contains(item)) @this.Add(item);
        }

        /// <summary>
        ///     如果不包含，则添加
        /// </summary>
        /// <param name="this">集合</param>
        /// <param name="items">项集合</param>
        /// <typeparam name="T">类型</typeparam>
        public static void AddIfNotContains<T>(this ICollection<T> @this, ICollection<T> items)
        {
            if (@this == null || items == null) return;
            foreach (var item in items) @this.AddIfNotContains(item);
        }
    }
}