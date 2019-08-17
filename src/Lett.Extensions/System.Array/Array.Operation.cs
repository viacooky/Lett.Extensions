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
    }
}