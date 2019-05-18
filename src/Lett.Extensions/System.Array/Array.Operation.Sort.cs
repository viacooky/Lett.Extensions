using System;
using System.Collections;

namespace Lett.Extensions
{
    /// <summary>
    ///     array 扩展方法 - 操作 - 排序
    /// </summary>
    public static partial class ArrayExtensions
    {
        /// <summary>
        ///     排序
        /// </summary>
        /// <param name="this">当前 Array</param>
        public static void Sort(this Array @this)
        {
            Array.Sort(@this);
        }

        /// <summary>
        ///     排序
        /// </summary>
        /// <param name="this">当前 Array 泛型接口</param>
        /// <typeparam name="T"></typeparam>
        public static void Sort<T>(this T[] @this)
        {
            Array.Sort(@this);
        }


        /// <summary>
        ///     排序
        /// </summary>
        /// <param name="this">当前 Array</param>
        /// <param name="comparer">比较元素时使用的 IComparer&lt;T&gt; 泛型接口实现；如果为 null，则使用每个元素的 IComparable&lt;T&gt; 泛型接口实现</param>
        public static void Sort(this Array @this, IComparer comparer)
        {
            Array.Sort(@this, comparer);
        }

        /// <summary>
        ///     排序
        /// </summary>
        /// <param name="this">当前 Array 泛型接口</param>
        /// <param name="comparer">比较元素时使用的 IComparer&lt;T&gt; 泛型接口实现；如果为 null，则使用每个元素的 IComparable&lt;T&gt; 泛型接口实现</param>
        /// <typeparam name="T"></typeparam>
        public static void Sort<T>(this T[] @this, IComparer comparer)
        {
            Array.Sort(@this, comparer);
        }

        /// <summary>
        ///     排序
        /// </summary>
        /// <param name="this">当前 Array</param>
        /// <param name="index">排序范围的起始索引</param>
        /// <param name="length">排序范围内的元素数</param>
        public static void Sort(this Array @this, int index, int length)
        {
            Array.Sort(@this, index, length);
        }

        /// <summary>
        ///     排序
        /// </summary>
        /// <param name="this">当前 Array 泛型接口</param>
        /// <param name="index">排序范围的起始索引</param>
        /// <param name="length">排序范围内的元素数</param>
        /// <typeparam name="T"></typeparam>
        public static void Sort<T>(this T[] @this, int index, int length)
        {
            Array.Sort(@this, index, length);
        }

        /// <summary>
        ///     排序
        /// </summary>
        /// <param name="this">当前 Array</param>
        /// <param name="index">排序范围的起始索引</param>
        /// <param name="length">排序范围内的元素数</param>
        /// <param name="comparer">比较元素时使用的 IComparer&lt;T&gt; 泛型接口实现；如果为 null，则使用每个元素的 IComparable&lt;T&gt; 泛型接口实现</param>
        public static void Sort(this Array @this, int index, int length, IComparer comparer)
        {
            Array.Sort(@this, index, length, comparer);
        }

        /// <summary>
        ///     排序
        /// </summary>
        /// <param name="this">当前 Array 泛型接口</param>
        /// <param name="index">排序范围的起始索引</param>
        /// <param name="length">排序范围内的元素数</param>
        /// <param name="comparer">比较元素时使用的 IComparer&lt;T&gt; 泛型接口实现；如果为 null，则使用每个元素的 IComparable&lt;T&gt; 泛型接口实现</param>
        /// <typeparam name="T"></typeparam>
        public static void Sort<T>(this T[] @this, int index, int length, IComparer comparer)
        {
            Array.Sort(@this, index, length, comparer);
        }
    }
}