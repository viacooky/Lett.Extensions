using System;
using System.Collections.Generic;

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
        /// <exception cref="ArgumentNullException"><paramref name="this.Keys" /> is null</exception>
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
        /// dict2.ContainsKeyAny(keys); // error -> throw NullReferenceException
        /// 
        /// dict.ContainsKeyAny(keys3); // error -> throw ArgumentNullException  keys3 is null 
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool ContainsKeyAny<TKey, TValue>(this IDictionary<TKey, TValue> @this, IEnumerable<TKey> keys)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this), $"{nameof(@this)} is null");
            return @this.Keys.ContainsAny(keys);
        }

        /// <summary>
        ///     是否包含全部 Key
        /// </summary>
        /// <param name="this"></param>
        /// <param name="keys">Key 集合</param>
        /// <typeparam name="TKey">Key 类型</typeparam>
        /// <typeparam name="TValue">Value 类型</typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        ///     <exception cref="@this"> is null</exception>
        /// </exception>
        /// <exception cref="ArgumentNullException"><paramref name="this.Keys" /> is null</exception>
        /// <exception cref="ArgumentNullException"><paramref name="keys" /> is null</exception>
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
        /// dict2.ContainsKeyAll(keys); // error -> throw NullReferenceException
        /// 
        /// dict.ContainsKeyAll(keys3); // error -> throw ArgumentNullException  keys3 is null 
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool ContainsKeyAll<TKey, TValue>(this IDictionary<TKey, TValue> @this, IEnumerable<TKey> keys)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this), $"{nameof(@this)} is null");
            return @this.Keys.ContainsAll(keys);
        }
    }
}