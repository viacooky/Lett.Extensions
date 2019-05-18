using System;

namespace Lett.Extensions
{
    /// <summary>
    ///     array 扩展方法 - 查找
    /// </summary>
    public static partial class ArrayExtensions
    {
        /// <summary>
        ///     返回数组中的第一个匹配元素
        /// </summary>
        /// <param name="this"></param>
        /// <param name="match">用于定义要搜索的元素的条件的谓词</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Find<T>(this T[] @this, Predicate<T> match)
        {
            return Array.Find(@this, match);
        }

        /// <summary>
        ///     返回数组中的最后一个匹配元素
        /// </summary>
        /// <param name="this"></param>
        /// <param name="match">用于定义要搜索的元素的条件的谓词</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FindLast<T>(this T[] @this, Predicate<T> match)
        {
            return Array.FindLast(@this, match);
        }

        /// <summary>
        ///     返回数组中所有匹配的元素
        /// </summary>
        /// <param name="this"></param>
        /// <param name="match">用于定义要搜索的元素的条件的谓词</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T[] FindAll<T>(this T[] @this, Predicate<T> match)
        {
            return Array.FindAll(@this, match);
        }
    }
}