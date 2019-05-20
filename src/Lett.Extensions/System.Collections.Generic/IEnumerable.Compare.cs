using System.Collections.Generic;
using System.Linq;

namespace Lett.Extensions
{
    /// <summary>
    ///     IEnumerable 扩展方法 - 比较
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static class IEnumerableExtensions
    {
        /// <summary>
        ///     是否空或空集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> @this)
        {
            return @this == null || !@this.Any();
        }

        /// <summary>
        ///     是否包含任一元素
        /// </summary>
        /// <param name="this"></param>
        /// <param name="items">需要进行判断的元素集合</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool ContainsAny<T>(this IEnumerable<T> @this, IEnumerable<T> items)
        {
            return @this.Any(items.Contains);
        }

        /// <summary>
        ///     是否包含全部元素
        /// </summary>
        /// <param name="this"></param>
        /// <param name="items">需要进行判断的元素集合</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool ContainsAll<T>(this IEnumerable<T> @this, IEnumerable<T> items)
        {
            return @this.All(items.Contains);
        }
    }
}