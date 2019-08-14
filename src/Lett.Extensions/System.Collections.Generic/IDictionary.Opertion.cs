using System;
using System.Collections.Generic;

namespace Lett.Extensions
{
    /// <summary>
    ///     IDictionary 扩展方法
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static partial class IDictionaryExtensions
    {
        /// <summary>
        ///     添加或设置
        /// </summary>
        /// <param name="this"></param>
        /// <param name="pair">键值对</param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <exception cref="ArgumentNullException">key is null</exception>
        /// <exception cref="NotSupportedException"><paramref name="this" />maybe is read-only</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dict1 = new Dictionary<string, int> {{"a", 1}, {"b", 2}};
        /// dict1.AddOrSet("a", 3);
        /// dict1.AddOrSet("c", 3);
        /// // dict1 => {{"a", 3}, {"b", 2}, {"c", 3}}
        ///         ]]>
        ///     </code>
        /// </example>
        public static void AddOrSet<TKey, TValue>(this IDictionary<TKey, TValue> @this, KeyValuePair<TKey, TValue> pair)
        {
            @this.AddOrSet(pair.Key, pair.Value);
        }

        /// <summary>
        ///     添加或设置
        /// </summary>
        /// <param name="this"></param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <exception cref="ArgumentNullException">key is null</exception>
        /// <exception cref="NotSupportedException"><paramref name="this" />maybe is read-only</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dict2 = new Dictionary<string, int>{{"a",1},{"b",2}};
        /// dict2.AddOrSet(new KeyValuePair<string, int>("a",3));
        /// dict2.AddOrSet(new KeyValuePair<string, int>("c",3));
        /// // dict1 => {{"a", 3}, {"b", 2}, {"c", 3}}
        ///         ]]>
        ///     </code>
        /// </example>
        public static void AddOrSet<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key, TValue value)
        {
            if (@this.ContainsKey(key)) @this[key] = value;
            else @this.Add(key, value);
        }
    }
}