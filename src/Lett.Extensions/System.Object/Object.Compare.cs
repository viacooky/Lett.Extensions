using System;
using System.Collections.Generic;
using System.Linq;

namespace Lett.Extensions
{
    /// <summary>
    ///     Object 扩展方法
    /// </summary>
    public static partial class ObjectExtensions
    {
        /// <summary>
        ///     是否DBNull
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var value = DBNull.Value;
        /// value.IsDBNull(); // true
        ///         ]]>
        ///     </code>
        /// </example>
        // ReSharper disable once InconsistentNaming
        public static bool IsDBNull(this object @this)
        {
            return Convert.IsDBNull(@this);
        }

        /// <summary>
        ///     当前对象是否存在于<paramref name="items" />集合内
        /// </summary>
        /// <param name="this"></param>
        /// <param name="items">进行比较的集合</param>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns><paramref name="items" /> 为空  返回 false </returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dtItems = new[]
        /// {
        ///     new DateTime(2018, 1, 1),
        ///     new DateTime(2019, 1, 1, 9, 10, 1),
        ///     DateTime.Today
        /// };
        /// var dt2 = DateTime.Today;
        /// dt2.In(dtItems); // true
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var    stringItems = new[] {"a", "b", null};
        /// var    s           = "a";
        /// string s2          = null;
        /// s.In(stringItems); // true
        /// s2.In(stringItems); // true
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// string[] stringItems2 = null;
        /// var      s3           = "a";
        /// s3.In(stringItems2); // false,  stringItems2 is null always return false
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool In<T>(this T @this, IEnumerable<T> items)
        {
            return items != null && items.Contains(@this);
        }


        /// <summary>
        ///     当前对象是否存在于<paramref name="items" />集合内
        /// </summary>
        /// <param name="this"></param>
        /// <param name="items">进行比较的集合</param>
        /// <param name="comparer">比较器</param>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// public class MyComparer : IEqualityComparer<DateTime>
        /// {
        ///     public bool Equals(DateTime x, DateTime y)
        ///     {
        ///         return x.Year.Equals(y.Year);
        ///     }
        /// 
        ///     public int GetHashCode(DateTime obj)
        ///     {
        ///         return obj.GetHashCode();
        ///     }
        /// }
        /// 
        /// var dtItems = new[]
        /// {
        ///     new DateTime(2018, 1, 1),
        ///     new DateTime(2019, 1, 1, 9, 10, 1),
        ///     DateTime.Today
        /// };
        /// var dt = new DateTime(2019, 5, 25, 1, 1, 1);
        /// 
        /// dt.In(dtItems, new MyComparer());  // true
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var strItems = new[] {"a", "A", "b"};
        /// var s        = "B";
        /// s.In(strItems, StringComparer.CurrentCultureIgnoreCase); // true
        /// s.In(strItems, StringComparer.CurrentCulture);  // false
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool In<T>(this T @this, IEnumerable<T> items, IEqualityComparer<T> comparer)
        {
            return items != null && items.Contains(@this, comparer);
        }
    }
}