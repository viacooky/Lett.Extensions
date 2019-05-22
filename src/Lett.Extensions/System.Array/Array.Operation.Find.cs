using System;

namespace Lett.Extensions
{
    /// <summary>
    ///     Array 扩展方法
    /// </summary>
    public static partial class ArrayExtensions
    {
        /// <summary>
        ///     返回数组中的第一个匹配元素
        /// </summary>
        /// <param name="this"></param>
        /// <param name="match">用于定义要搜索的元素的条件的谓词</param>
        /// <typeparam name="T">数组的元素类型</typeparam>
        /// <returns></returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="match">match</paramref> is null.</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var rs = new[] {"a", "aa", "bb", "aaa"}.Find(s => s.Length == 2); // "aa"
        ///         ]]>
        ///     </code>
        /// </example>
        public static T Find<T>(this T[] @this, Predicate<T> match)
        {
            return Array.Find(@this, match);
        }

        /// <summary>
        ///     返回数组中的最后一个匹配元素
        /// </summary>
        /// <param name="this"></param>
        /// <param name="match">用于定义要搜索的元素的条件的谓词</param>
        /// <typeparam name="T">数组的元素类型</typeparam>
        /// <returns></returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="match">match</paramref> is null.</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var rs = new[] {"a", "aa", "bb", "aaa"}.FindLast(s => s.Length == 2); // "bb"
        ///         ]]>
        ///     </code>
        /// </example>
        public static T FindLast<T>(this T[] @this, Predicate<T> match)
        {
            return Array.FindLast(@this, match);
        }

        /// <summary>
        ///     返回数组中所有匹配的元素
        /// </summary>
        /// <param name="this"></param>
        /// <param name="match">用于定义要搜索的元素的条件的谓词</param>
        /// <typeparam name="T">数组的元素类型</typeparam>
        /// <returns></returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="match">match</paramref> is null.</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var rs = new[] {"a", "aa", "bb", "aaa"}.FindAll(s => s.Length == 2); // ["aa","bb"]
        ///         ]]>
        ///     </code>
        /// </example>
        public static T[] FindAll<T>(this T[] @this, Predicate<T> match)
        {
            return Array.FindAll(@this, match);
        }

        /// <summary>
        ///     返回数组中的第一个匹配元素的索引
        /// </summary>
        /// <param name="this"></param>
        /// <param name="match">用于定义要搜索的元素的条件的谓词</param>
        /// <typeparam name="T">数组的元素类型</typeparam>
        /// <returns></returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="this" /> 或 <paramref name="match" /> 为空.</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var rs = new[] {"a", "aa", "bb", "aaa"}.FindIndex(s => s.Length == 2); // 1
        ///         ]]>
        ///     </code>
        /// </example>
        public static int FindIndex<T>(this T[] @this, Predicate<T> match)
        {
            return Array.FindIndex(@this, match);
        }

        /// <summary>
        ///     返回数组中的第一个匹配元素的索引
        /// </summary>
        /// <param name="this"></param>
        /// <param name="startIndex">开始的索引</param>
        /// <param name="match">用于定义要搜索的元素的条件的谓词</param>
        /// <typeparam name="T">数组的元素类型</typeparam>
        /// <returns></returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="this" /> 或 <paramref name="match" /> 为空.</exception>
        /// <exception cref="ArgumentOutOfRangeException"/>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var rs = new[] {"a", "aa", "bb", "aaa"}.FindIndex(2, ss => ss.Length == 2); // 2
        ///         ]]>
        ///     </code>
        /// </example>
        public static int FindIndex<T>(this T[] @this, int startIndex, Predicate<T> match)
        {
            return Array.FindIndex(@this, startIndex, match);
        }

        /// <summary>
        ///     返回数组中的第一个匹配元素的索引
        /// </summary>
        /// <param name="this"></param>
        /// <param name="startIndex">开始的索引</param>
        /// <param name="count">要搜索的部分中的元素数</param>
        /// <param name="match">用于定义要搜索的元素的条件的谓词</param>
        /// <typeparam name="T">数组的元素类型</typeparam>
        /// <returns></returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="this" /> 或 <paramref name="match" /> 为空.</exception>
        /// <exception cref="ArgumentOutOfRangeException"/>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var rs = new[] {"a", "aa", "bb", "aaa"}.FindIndex(1, 2, ss => ss.Length == 2); // 1
        ///         ]]>
        ///     </code>
        /// </example>
        public static int FindIndex<T>(this T[] @this, int startIndex, int count, Predicate<T> match)
        {
            return Array.FindIndex(@this, startIndex, count, match);
        }


        /// <summary>
        ///     返回数组中的最后一个匹配元素的索引
        /// </summary>
        /// <param name="this"></param>
        /// <param name="match">用于定义要搜索的元素的条件的谓词</param>
        /// <typeparam name="T">数组的元素类型</typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="this" /> 或 <paramref name="match" /> 为空 </exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var rs = new[] {"aa", "aaa", "bb", "bb", "bbb", "ccc"}.FindLastIndex(s1 => s1.StartsWith("b")); // 4
        ///         ]]>
        ///     </code>
        /// </example>
        public static int FindLastIndex<T>(this T[] @this, Predicate<T> match)
        {
            return Array.FindLastIndex(@this, match);
        }

        /// <summary>
        ///     返回数组中的最后一个匹配元素的索引
        /// </summary>
        /// <param name="this"></param>
        /// <param name="startIndex">开始的索引</param>
        /// <param name="match">用于定义要搜索的元素的条件的谓词</param>
        /// <typeparam name="T">数组的元素类型</typeparam>
        /// <returns></returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="this" /> 或 <paramref name="match" /> 为空.</exception>
        /// <exception cref="ArgumentOutOfRangeException"/>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var rs = new[] {"aa", "aaa", "bb", "bb", "bbb", "ccc"}.FindLastIndex(1, s1 => s1.StartsWith("a")); // 1
        ///         ]]>
        ///     </code>
        /// </example>
        public static int FindLastIndex<T>(this T[] @this, int startIndex, Predicate<T> match)
        {
            return Array.FindLastIndex(@this, startIndex, match);
        }

        /// <summary>
        ///     返回数组中的最后一个匹配元素的索引
        /// </summary>
        /// <param name="this"></param>
        /// <param name="startIndex">开始的索引</param>
        /// <param name="count">要搜索的部分中的元素数</param>
        /// <param name="match">用于定义要搜索的元素的条件的谓词</param>
        /// <typeparam name="T">数组的元素类型</typeparam>
        /// <returns></returns>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="this" /> 或 <paramref name="match" /> 为空.</exception>
        /// <exception cref="ArgumentOutOfRangeException"/>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var rs = new[] {"a", "aa", "b", "bb", "bbb", "c"}.FindLastIndex(4,3, s1 => s1.StartsWith("b")); // 4
        ///         ]]>
        ///     </code>
        /// </example>
        public static int FindLastIndex<T>(this T[] @this, int startIndex, int count, Predicate<T> match)
        {
            return Array.FindLastIndex(@this, startIndex, count, match);
        }
    }
}