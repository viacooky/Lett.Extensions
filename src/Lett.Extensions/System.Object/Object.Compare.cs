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
        /// 是否 <c>Null</c> 或 <c>DBNull</c>
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var v = DBNull.Value;
        /// v.IsNullOrDbNull();         // true
        /// var v2 = default(string);   // null
        /// v2.IsNullOrDbNull();        // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsNullOrDbNull(this object @this)
        {
            return @this == null || @this.IsDBNull();
        }

        /// <summary>
        ///     当前对象类型是否 Class
        /// </summary>
        /// <param name="this"></param>
        /// <returns><paramref name="this" /> 为 null ，返回 false</returns>
        /// <exception cref="NullReferenceException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var obj1 = new MyClass();
        /// obj1.IsClass(); // true
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var obj2 = 12;
        /// obj2.IsClass(); // false
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// object obj3 = null;
        /// obj3.IsClass(); // false
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsClass(this object @this)
        {
            return @this != null && @this.GetType().IsClass;
        }

        /// <summary>
        ///     当前对象类型是否 Array
        /// </summary>
        /// <param name="this"></param>
        /// <returns><paramref name="this" /> 为 null ，返回 false</returns>
        /// <exception cref="NullReferenceException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var obj1 = new[] {"1", "2"};
        /// obj1.IsArray(); // true
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var obj2 = new List<string> {"1", "2"};
        /// obj2.IsArray(); // false
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// object obj3 = null;
        /// obj3.IsArray(); // false
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var obj4 = new MyClass();
        /// obj4.IsArray(); // false
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsArray(this object @this)
        {
            return @this != null && @this.GetType().IsArray;
        }

        /// <summary>
        ///     当前对象类型是否可序列化的
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <returns><paramref name="this" /> 为 null ，返回 false</returns>
        /// <exception cref="NullReferenceException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var obj1 = new[] {"1", "2"};
        /// obj1.IsSerializable(); // true
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// object obj3 = null;
        /// obj3.IsSerializable(); // false
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// private class MyClass
        /// {
        ///     public string Name { get; set; }
        /// }
        /// 
        /// var obj4 = new MyClass();
        /// obj4.IsSerializable(); // false
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// [Serializable]
        /// private class MySerializableClass
        /// {
        ///    public string Name { get; set; }
        /// }
        /// 
        /// var obj5 = new MySerializableClass();
        /// obj5.IsSerializable(); // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsSerializable(this object @this)
        {
            return @this != null && @this.GetType().IsSerializable;
        }

        /// <summary>
        ///     当前对象类型是否枚举
        /// </summary>
        /// <param name="this"></param>
        /// <returns><paramref name="this" /> 为 null ，返回 false</returns>
        /// <exception cref="NullReferenceException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// private enum MyEnum
        /// {
        ///     None
        /// }
        /// 
        /// var obj1 = MyEnum.None;
        /// obj1.IsEnum(); // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsEnum(this object @this)
        {
            return @this != null && @this.GetType().IsEnum;
        }

        /// <summary>
        ///     当前对象类型是否值类型
        /// </summary>
        /// <param name="this"></param>
        /// <returns><paramref name="this" /> 为 null ，返回 false</returns>
        /// <exception cref="NullReferenceException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var obj1 = 12;
        /// obj1.IsValueType(); // true
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var obj2 = "";
        /// obj2.IsValueType(); // false
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var obj4 = new MyStruct();
        /// obj4.IsValueType(); // true
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var obj5 = new DateTime();
        /// obj5.IsValueType(); // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool IsValueType(this object @this)
        {
            return @this.GetType().IsValueType;
        }

        #region In or Not In

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
        /// <returns><paramref name="items" /> 为空  返回 false </returns>
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

        /// <summary>
        ///     当前对象是否存在于 <paramref name="items" /> 数组内
        /// </summary>
        /// <param name="this"></param>
        /// <param name="items">params <typeparamref name="T" />[]</param>
        /// <typeparam name="T"></typeparam>
        /// <returns><paramref name="items" /> 为空 返回 false</returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// "a".InParams("A", "a"); // true
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// string s = null;
        /// s.InParams("a"); // false
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool InParams<T>(this T @this, params T[] items)
        {
            return items != null && @this.In(items);
        }

        /// <summary>
        ///     当前对象是否存在于 <paramref name="items" /> 数组内
        /// </summary>
        /// <param name="this"></param>
        /// <param name="comparer">比较器</param>
        /// <param name="items">params <typeparamref name="T" />[]</param>
        /// <typeparam name="T"></typeparam>
        /// <returns><paramref name="items" /> 为空 返回 false</returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// "a".InParams(StringComparer.CurrentCultureIgnoreCase, "A", "B"); // true
        /// "a".InParams(StringComparer.Ordinal, "A", "B");                  // false
        /// "a".InParams(StringComparer.Ordinal, null);                      // false
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool InParams<T>(this T @this, IEqualityComparer<T> comparer, params T[] items)
        {
            return items != null && @this.In(items, comparer);
        }

        /// <summary>
        ///     当前对象是否不存在于<paramref name="items" />集合内
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
        /// dt2.NotIn(dtItems); // false
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var    stringItems = new[] {"a", "b", null};
        /// var    s           = "a";
        /// string s2          = null;
        /// s.NotIn(stringItems); // false
        /// s2.NotIn(stringItems); // false
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// string[] stringItems2 = null;
        /// var      s3           = "a";
        /// s3.NotIn(stringItems2); // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool NotIn<T>(this T @this, IEnumerable<T> items)
        {
            return !@this.In(items);
        }

        /// <summary>
        ///     当前对象是否不存在于<paramref name="items" />集合内
        /// </summary>
        /// <param name="this"></param>
        /// <param name="items">进行比较的集合</param>
        /// <param name="comparer">比较器</param>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns><paramref name="items" /> 为空  返回 false </returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dtItems = new[] {
        ///     new DateTime(2018, 1, 1), 
        ///     new DateTime(2019, 1, 1, 9, 10, 1), 
        ///     DateTime.Today
        /// };
        /// var dt      = new DateTime(2019, 5, 25, 1, 1, 1);
        /// 
        /// dt.NotIn(dtItems, new MyComparer()); // false
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool NotIn<T>(this T @this, IEnumerable<T> items, IEqualityComparer<T> comparer)
        {
            return !@this.In(items, comparer);
        }

        /// <summary>
        ///     当前对象是否不存在于 <paramref name="items" /> 数组内
        /// </summary>
        /// <param name="this"></param>
        /// <param name="items">params <typeparamref name="T" />[]</param>
        /// <typeparam name="T"></typeparam>
        /// <returns><paramref name="items" /> 为空 返回 false</returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// "a".NotInParams("A", "a"); // fase
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// string s = null;
        /// s.InParams("a"); // false
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool NotInParams<T>(this T @this, params T[] items)
        {
            return !@this.InParams(items);
        }
        
        /// <summary>
        ///     当前对象是否不存在于 <paramref name="items" /> 数组内
        /// </summary>
        /// <param name="this"></param>
        /// <param name="comparer">比较器</param>
        /// <param name="items">params <typeparamref name="T" />[]</param>
        /// <typeparam name="T"></typeparam>
        /// <returns><paramref name="items" /> 为空 返回 false</returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// "a".NotInParams(StringComparer.CurrentCultureIgnoreCase, "A", "B"); // false
        /// "a".NotInParams(StringComparer.Ordinal, "A", "B");                  // true
        /// "a".NotInParams(StringComparer.Ordinal, null);                      // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool NotInParams<T>(this T @this, IEqualityComparer<T> comparer, params T[] items)
        {
            return !@this.InParams(comparer, items);
        }

        #endregion
    }
}