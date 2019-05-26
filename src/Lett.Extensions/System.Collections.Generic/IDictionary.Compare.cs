using System;
using System.Collections.Generic;
using System.Linq;

namespace Lett.Extensions
{
    /// <summary>
    ///     ICollections 扩展方法
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static class IDictionaryExtensions
    {
        /// <summary>
        ///     是否包含任一 Key
        /// </summary>
        /// <param name="this"></param>
        /// <param name="keys">Key 集合</param>
        /// <typeparam name="TKey">Key 类型</typeparam>
        /// <typeparam name="TValue">Value 类型</typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="this" /> is null</exception>
        /// <exception cref="ArgumentNullException"><paramref name="keys" /> is null</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dict = new Dictionary<string, object>
        /// {
        ///     {"1", "1"}, {"2", "2"}, {"3", "3"}, {"4", "4"},
        /// };
        /// var keys  = new[] {"6"};
        /// var keys2 = new List<string> {"1"};
        /// 
        /// dict.ContainsKeyAny(keys); // false
        /// dict.ContainsKeyAny(keys2); // true
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dict = new Dictionary<string, object>
        /// {
        ///     {"1", "1"}, {"2", "2"}, {"3", "3"}, {"4", "4"},
        /// };
        /// Dictionary<string, object> dict2 = null;
        /// var keys  = new[] {"6"};
        /// List<string> keys3 = null;
        /// 
        /// dict2.ContainsKeyAny(keys); // error -> throw ArgumentNullException  dict2 is null
        /// 
        /// dict.ContainsKeyAny(keys3); // error -> throw ArgumentNullException  keys3 is null 
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool ContainsKeyAny<TKey, TValue>(this IDictionary<TKey, TValue> @this, IEnumerable<TKey> keys)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this), $"{nameof(@this)} is null");
            if (keys == null) throw new ArgumentNullException(nameof(keys), $"{nameof(keys)} is null");
            return keys.Any(@this.ContainsKey);
        }

        /// <summary>
        ///     是否包含任一 Key
        /// </summary>
        /// <param name="this"></param>
        /// <param name="keys">params <typeparamref name="TKey" />[]</param>
        /// <typeparam name="TKey">Key 类型</typeparam>
        /// <typeparam name="TValue">Value 类型</typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="this" /> is null</exception>
        /// <exception cref="ArgumentNullException"><paramref name="keys" /> is null</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dict = new Dictionary<string, object>
        /// {
        ///     {"1", "1"}, {"2", "2"}, {"3", "3"}, {"4", "4"},
        /// };
        /// 
        /// dict2.ContainsKeyAny("1", "2"); // true
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool ContainsKeyAnyParams<TKey, TValue>(this IDictionary<TKey, TValue> @this, params TKey[] keys)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this), $"{nameof(@this)} is null");
            if (keys == null) throw new ArgumentNullException(nameof(keys), $"{nameof(keys)} is null");
            return keys.Any(@this.ContainsKey);
        }

        /// <summary>
        ///     是否包含全部 Key
        /// </summary>
        /// <param name="this"></param>
        /// <param name="keys">Key 集合</param>
        /// <typeparam name="TKey">Key 类型</typeparam>
        /// <typeparam name="TValue">Value 类型</typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="this" />  is null</exception>
        /// <exception cref="ArgumentNullException"><paramref name="keys" /> is null</exception>
        /// <example></example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dict = new Dictionary<string, object>
        /// {
        ///     {"1", "1"}, {"2", "2"}, {"3", "3"}, {"4", "4"},
        /// };
        /// var keys = new[] {"6"};
        /// var keys2 = new List<string> {"1", "2", "3", "4"};
        /// 
        /// dict.ContainsKeyAll(keys); // false
        /// dict.ContainsKeyAll(keys2); // true
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dict = new Dictionary<string, object>
        /// {
        ///     {"1", "1"}, {"2", "2"}, {"3", "3"}, {"4", "4"},
        /// };
        /// Dictionary<string, object> dict2 = null;
        /// var keys  = new[] {"6"};
        /// List<string> keys3 = null;
        /// 
        /// dict2.ContainsKeyAll(keys); // error -> throw ArgumentNullException dict2 is null
        /// 
        /// dict.ContainsKeyAll(keys3); // error -> throw ArgumentNullException  keys3 is null 
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool ContainsKeyAll<TKey, TValue>(this IDictionary<TKey, TValue> @this, IEnumerable<TKey> keys)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this), $"{nameof(@this)} is null");
            if (keys == null) throw new ArgumentNullException(nameof(keys), $"{nameof(keys)} is null");
            return keys.All(@this.ContainsKey);
        }

        /// <summary>
        ///     是否包含全部 Key
        /// </summary>
        /// <param name="this"></param>
        /// <param name="keys">params <typeparamref name="TKey" />[]</param>
        /// <typeparam name="TKey">Key 类型</typeparam>
        /// <typeparam name="TValue">Value 类型</typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="this" />  is null</exception>
        /// <exception cref="ArgumentNullException"><paramref name="keys" /> is null</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dict = new Dictionary<string, object>
        /// {
        ///     {"1", "1"}, {"2", "2"}, {"3", "3"}, {"4", "4"},
        /// };
        /// 
        /// dict.ContainsKeyAll(keys3); // error -> throw ArgumentNullException  keys3 is null 
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool ContainsKeyAllParams<TKey, TValue>(this IDictionary<TKey, TValue> @this, params TKey[] keys)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this), $"{nameof(@this)} is null");
            if (keys == null) throw new ArgumentNullException(nameof(keys), $"{nameof(keys)} is null");
            return keys.All(@this.ContainsKey);
        }

        /// <summary>
        ///     是否包含 <paramref name="value" />
        /// </summary>
        /// <param name="this"></param>
        /// <param name="value"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="this" /> is null</exception>
        /// <exception cref="ArgumentNullException"><paramref name="value" /> is null</exception>
        public static bool ContainsValue<TKey, TValue>(this IDictionary<TKey, TValue> @this, TValue value)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this), $"{nameof(@this)} is null");
            if (value == null) throw new ArgumentNullException(nameof(value), $"{nameof(value)} is null");
            return @this.Values.Contains(value);
        }

        /// <summary>
        ///     是否包含任一 value
        /// </summary>
        /// <param name="this"></param>
        /// <param name="values">value 集合</param>
        /// <typeparam name="TKey">Key 类型</typeparam>
        /// <typeparam name="TValue">Value 类型</typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="this" /> is null</exception>
        /// <exception cref="ArgumentNullException"><paramref name="values" /> is null</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dict = new Dictionary<string,object>
        /// {
        ///     {"Key1", "1Value"}, {"Key2", "2Value"}, {"Key3", "3Value"}, {"Key4", "4Value"},
        /// };
        /// var values = new List<string> {"1Value"};
        /// var values2 = new List<string> {"6666Value"};
        /// Dictionary<string, object> dict2 = null;
        /// 
        /// 
        /// dict.ContainsValueAny(values); // true
        /// dict.ContainsValueAny(values2); // false
        /// dict.ContainsValueAnyParams("1Value"); // true
        /// 
        /// dict2.ContainsKeyAll(values); // throw ArgumentNullException this is null
        /// dict.ContainsKeyAllParams(null); // throw ArgumentNullException values is null
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool ContainsValueAny<TKey, TValue>(this IDictionary<TKey, TValue> @this, IEnumerable<TValue> values)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this), $"{nameof(@this)} is null");
            if (values == null) throw new ArgumentNullException(nameof(values), $"{nameof(values)} is null");
            return values.Any(@this.ContainsValue);
        }

        /// <summary>
        ///     是否包含任一 value
        /// </summary>
        /// <param name="this"></param>
        /// <param name="values">params <typeparamref name="TValue" />[]</param>
        /// <typeparam name="TKey">Key 类型</typeparam>
        /// <typeparam name="TValue">Value 类型</typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="this" /> is null</exception>
        /// <exception cref="ArgumentNullException"><paramref name="values" /> is null</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dict = new Dictionary<string,object>
        /// {
        ///     {"Key1", "1Value"}, {"Key2", "2Value"}, {"Key3", "3Value"}, {"Key4", "4Value"},
        /// };
        /// var values = new List<string> {"1Value"};
        /// var values2 = new List<string> {"6666Value"};
        /// Dictionary<string, object> dict2 = null;
        /// 
        /// 
        /// dict.ContainsValueAny(values); // true
        /// dict.ContainsValueAny(values2); // false
        /// dict.ContainsValueAnyParams("1Value"); // true
        /// 
        /// dict2.ContainsKeyAll(values); // throw ArgumentNullException this is null
        /// dict.ContainsKeyAllParams(null); // throw ArgumentNullException values is null
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool ContainsValueAnyParams<TKey, TValue>(this IDictionary<TKey, TValue> @this, params TValue[] values)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this), $"{nameof(@this)} is null");
            if (values == null) throw new ArgumentNullException(nameof(values), $"{nameof(values)} is null");
            return values.Any(@this.ContainsValue);
        }

        /// <summary>
        ///     是否包含全部 Value
        /// </summary>
        /// <param name="this"></param>
        /// <param name="values"></param>
        /// <typeparam name="TKey">Key 类型</typeparam>
        /// <typeparam name="TValue">Value 类型</typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="this" /> is null</exception>
        /// <exception cref="ArgumentNullException"><paramref name="values" /> is null</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dict = new Dictionary<string, object>
        /// {
        ///     {"Key1", "1Value"}, {"Key2", "2Value"}, {"Key3", "3Value"}, {"Key4", "4Value"},
        /// };
        /// var values  = new List<string> {"1Value", "2Value", "3Value", "4Value"};
        /// var values2 = new List<string> {"1Value", "2Value", "3Value", "4Value", "6666Value"};
        /// 
        /// Dictionary<string, object> dict2 = null;
        /// 
        /// dict.ContainsValueAll(values); // true
        /// dict.ContainsValueAll(values2); // false
        /// dict.ContainsValueAllParams("1Value", "2Value", "3Value", "4Value"); // true
        /// dict.ContainsValueAllParams("1Value", "2Value", "3Value", "4Value","6666Value"); // false
        /// 
        /// dict2.ContainsValueAll(values); // throw ArgumentNullException this is null
        /// dict.ContainsValueAllParams(null); // throw ArgumentNullException values is null
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool ContainsValueAll<TKey, TValue>(this IDictionary<TKey, TValue> @this, IEnumerable<TValue> values)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this), $"{nameof(@this)} is null");
            if (values == null) throw new ArgumentNullException(nameof(values), $"{nameof(values)} is null");
            return values.All(@this.ContainsValue);
        }

        /// <summary>
        ///     是否包含全部 Value
        /// </summary>
        /// <param name="this"></param>
        /// <param name="values">params <typeparamref name="TValue" />[]</param>
        /// <typeparam name="TKey">Key 类型</typeparam>
        /// <typeparam name="TValue">Value 类型</typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="this" /> is null</exception>
        /// <exception cref="ArgumentNullException"><paramref name="values" /> is null</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dict = new Dictionary<string, object>
        /// {
        ///     {"Key1", "1Value"}, {"Key2", "2Value"}, {"Key3", "3Value"}, {"Key4", "4Value"},
        /// };
        /// var values  = new List<string> {"1Value", "2Value", "3Value", "4Value"};
        /// var values2 = new List<string> {"1Value", "2Value", "3Value", "4Value", "6666Value"};
        /// 
        /// Dictionary<string, object> dict2 = null;
        /// 
        /// dict.ContainsValueAll(values); // true
        /// dict.ContainsValueAll(values2); // false
        /// dict.ContainsValueAllParams("1Value", "2Value", "3Value", "4Value"); // true
        /// dict.ContainsValueAllParams("1Value", "2Value", "3Value", "4Value","6666Value"); // false
        /// 
        /// dict2.ContainsValueAll(values); // throw ArgumentNullException this is null
        /// dict.ContainsValueAllParams(null); // throw ArgumentNullException values is null
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool ContainsValueAllParams<TKey, TValue>(this IDictionary<TKey, TValue> @this, params TValue[] values)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this), $"{nameof(@this)} is null");
            if (values == null) throw new ArgumentNullException(nameof(values), $"{nameof(values)} is null");
            return values.All(@this.ContainsValue);
        }
    }
}