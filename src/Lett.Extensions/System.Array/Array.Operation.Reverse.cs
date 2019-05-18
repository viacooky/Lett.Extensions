using System;

namespace Lett.Extensions
{
    /// <summary>
    ///     array 扩展方法 - 操作 - 反转
    /// </summary>
    public static partial class ArrayExtensions
    {
        /// <summary>
        ///     反转数组中元素的顺序
        /// </summary>
        /// <param name="this">当前 Array </param>
        public static void Reverse(this Array @this)
        {
            Array.Reverse(@this);
        }

        /// <summary>
        ///     反转数组中元素的顺序
        /// </summary>
        /// <param name="this">当前 Array 泛型接口</param>
        /// <typeparam name="T"></typeparam>
        public static void Reverse<T>(this T[] @this)
        {
            Array.Reverse(@this);
        }

        /// <summary>
        ///     反转数组中元素的顺序
        /// </summary>
        /// <param name="this">当前 Array</param>
        /// <param name="index">要反转的部分的起始索引</param>
        /// <param name="length">要反转的部分中的元素数</param>
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
        public static void Reverse<T>(this T[] @this, int index, int length)
        {
            Array.Reverse(@this, index, length);
        }
    }
}