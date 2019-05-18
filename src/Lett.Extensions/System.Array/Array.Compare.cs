using System;

namespace Lett.Extensions
{
    /// <summary>
    ///     array 扩展方法 - 比较
    /// </summary>
    public static partial class ArrayExtensions
    {
        /// <summary>
        ///     是否包含索引
        /// </summary>
        /// <param name="this">当前 Array 泛型接口</param>
        /// <param name="index">索引</param>
        /// <typeparam name="T"></typeparam>
        public static bool ContainsIndex<T>(this T[] @this, int index)
        {
            return 0 <= index && index < @this.Length;
        }

        /// <summary>
        ///     是否包含索引
        /// </summary>
        /// <param name="this">当前Array</param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static bool ContainsIndex(this Array @this, int index)
        {
            return 0 <= index && index < @this.Length;
        }
    }
}