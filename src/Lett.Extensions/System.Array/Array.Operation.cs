using System;
using System.Collections;

namespace Lett.Extensions
{
    /// <summary>
    ///     array 扩展方法 - 操作
    /// </summary>
    public static partial class ArrayExtensions
    {
        #region ClearAll

        /// <summary>
        /// 全部清除
        /// </summary>
        /// <param name="this">当前 Array</param>
        public static void ClearAll(this Array @this)
        {
            Array.Clear(@this, 0, @this.Length);
        }

        /// <summary>
        ///     全部清除
        /// </summary>
        /// <param name="this">当前 Array 泛型接口</param>
        /// <typeparam name="T"></typeparam>
        public static void ClearAll<T>(this T[] @this)
        {
            Array.Clear(@this, 0, @this.Length);
        }

        #endregion

    }
}