using System;

namespace Lett.Extensions
{
    /// <summary>
    ///     array 扩展方法 - 操作
    /// </summary>
    public static partial class ArrayExtensions
    {
        #region ClearAll

        /// <summary>
        ///     全部清除
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

        #region ForEach

        /// <summary>
        ///     对指定数组的每个元素执行指定操作
        /// </summary>
        /// <param name="this">当前 Array 泛型接口</param>
        /// <param name="action">
        ///     <para>指定操作</para>
        ///     <para>T: 数组元素</para>
        /// </param>
        /// <typeparam name="T"></typeparam>
        public static void ForEach<T>(this T[] @this, Action<T> action)
        {
            @this.ForEach((i, arg2) => action(arg2));
        }

        /// <summary>
        ///     对指定数组的每个元素执行指定操作
        /// </summary>
        /// <param name="this">当前 Array 泛型接口</param>
        /// <param name="action">
        ///     <para>指定操作</para>
        ///     <para>int: 数组元素的索引</para>
        ///     <para>T: 数组元素</para>
        /// </param>
        /// <typeparam name="T"></typeparam>
        public static void ForEach<T>(this T[] @this, Action<int, T> action)
        {
            for (var i = 0; i < @this.Length; i++) action(i, @this[i]);
        }

        #endregion
    }
}