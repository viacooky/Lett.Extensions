using System;

namespace Lett.Extensions
{
    /// <summary>
    ///     Array 扩展方法
    /// </summary>
    public static partial class ArrayExtensions
    {
        #region ClearAll

        /// <summary>
        ///     将所有元素设置为元素类型的默认值
        /// </summary>
        /// <param name="this"></param>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var s = new[] {"aaa", "bbb"};
        /// s.ClearAll();
        /// // s.Length == 2;
        /// // s[0] == null;
        ///
        /// var s = new[] {11, 22};
        /// s.ClaerAll();
        /// // s.Length == 2;
        /// // s[0] == 0;
        /// // s[1] == 1;
        ///         ]]>
        ///     </code>
        /// </example>
        public static void ClearAll(this Array @this)
        {
            Array.Clear(@this, 0, @this.Length);
        }

        /// <summary>
        ///     将所有元素设置为元素类型的默认值
        /// </summary>
        /// <param name="this"></param>
        /// <typeparam name="T">数组的元素类型</typeparam>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var s = new[] {"aaa", "bbb"};
        /// s.ClearAll();
        /// // s.Length == 2;
        /// // s[0] == null;
        ///
        /// var s = new[] {11, 22};
        /// s.ClaerAll();
        /// // s.Length == 2;
        /// // s[0] == 0;
        /// // s[1] == 1;
        ///         ]]>
        ///     </code>
        /// </example>
        public static void ClearAll<T>(this T[] @this)
        {
            Array.Clear(@this, 0, @this.Length);
        }

        #endregion

        #region ForEach

        /// <summary>
        ///     对每个元素执行指定操作
        /// </summary>
        /// <param name="this"></param>
        /// <param name="action">
        ///     <para>指定操作</para>
        ///     <para>T: 数组元素</para>
        /// </param>
        /// <typeparam name="T">数组的元素类型</typeparam>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var s  = new[] {"aa", "aaa", "bb", "bb", "bbb", "ccc"};
        /// var rs = new List<string>();
        /// s.ForEach(e => rs.Add(e));
        /// // rs.Count == 6;
        /// // rs[0] == "aa";
        ///         ]]>
        ///     </code>
        /// </example>
        public static void ForEach<T>(this T[] @this, Action<T> action)
        {
            @this.ForEach((i, arg2) => action(arg2));
        }

        /// <summary>
        ///     对每个元素执行指定操作
        /// </summary>
        /// <param name="this"></param>
        /// <param name="action">
        ///     <para>指定操作</para>
        ///     <para>int: 数组元素的索引</para>
        ///     <para>T: 数组元素</para>
        /// </param>
        /// <typeparam name="T">数组的元素类型</typeparam>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var s  = new[] {"aa", "aaa", "bb", "bb", "bbb", "ccc"};
        /// var rs = new List<string>();
        /// s.ForEach((index, e) => rs2.Add($"{index}-{e}"));
        /// // rs.Count == 6;
        /// // rs[0] == "0-aa";
        ///         ]]>
        ///     </code>
        /// </example>
        public static void ForEach<T>(this T[] @this, Action<int, T> action)
        {
            for (var i = 0; i < @this.Length; i++) action(i, @this[i]);
        }

        #endregion
    }
}