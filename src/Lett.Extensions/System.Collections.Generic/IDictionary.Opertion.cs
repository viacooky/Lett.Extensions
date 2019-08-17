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
        ///     <para>批量添加或更新</para>
        ///     <para>遍历<paramref name="pairs" />, 当 <paramref name="this" /> 中不存在 <c>pair</c> 的 <c>Key</c> 时，将 <c>pair</c> 的 <c>Value</c> 添加到 <paramref name="this" /> 中</para>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="pairs"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NotSupportedException"><paramref name="this" /> maybe is read-only</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dict1 = new Dictionary<string, int> {{"a", 1}, {"b", 2}};
        /// var sameDict = new Dictionary<string, int> {{"a", 3}, {"b", 4}, {"c", 5}};
        /// dict1.AddOrUpdateRange(sameDict);
        /// // dict1 => {{"a", 3}, {"b", 4}, {"c", 5}}
        ///         ]]>
        ///     </code>
        /// </example>
        public static void AddOrUpdateRange<TKey, TValue>(this IDictionary<TKey, TValue> @this, IEnumerable<KeyValuePair<TKey, TValue>> pairs)
        {
            foreach (var pair in pairs) @this.AddOrUpdate(pair);
        }

        /// <summary>
        ///     <para>添加或更新</para>
        ///     <para>当 <paramref name="this" /> 中不存在 <paramref name="pair" /> 的 <c>Key</c> 时，将 <paramref name="pair" /> 的 <c>Value</c> 添加到 <paramref name="this" /> 中</para>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="pair">键值对</param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <exception cref="ArgumentNullException">key is null</exception>
        /// <exception cref="NotSupportedException"><paramref name="this" /> maybe is read-only</exception>
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
        public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> @this, KeyValuePair<TKey, TValue> pair)
        {
            @this.AddOrUpdate(pair.Key, pair.Value);
        }

        /// <summary>
        ///     <para>添加或更新</para>
        ///     <para>当 <paramref name="this" /> 中不存在 <paramref name="key" /> 时，将 {<paramref name="key" />, <paramref name="value" />} 添加到 <paramref name="this" /> 中</para>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <exception cref="ArgumentNullException">key is null</exception>
        /// <exception cref="NotSupportedException"><paramref name="this" /> maybe is read-only</exception>
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
        public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key, TValue value)
        {
            if (@this.ContainsKey(key)) @this[key] = value;
            else @this.Add(key, value);
        }

        /// <summary>
        ///     <para>获取值或更新</para>
        ///     <para>当 <paramref name="this" /> 中不存在 <paramref name="key" /> 时，将 {<paramref name="key" />, <paramref name="value" />} 添加到 <paramref name="this" /> 中，并返回 <paramref name="value" /></para>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">key is null</exception>
        /// <exception cref="NotSupportedException"><paramref name="this" />maybe is read-only</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dict = new Dictionary<string, int> {{"a", 1}, {"b", 2}};
        /// var rs = dict.GetOrUpdate("c", 3);
        /// // rs = 3;
        /// // dict = {{"a", 1}, {"b", 2}, {"c", 3}};
        ///         ]]>
        ///     </code>
        /// </example>
        public static TValue GetOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key, TValue value)
        {
            if (@this.ContainsKey(key)) return @this[key];
            @this.Add(key, value);
            return value;
        }

        /// <summary>
        ///     <para>批量添加</para>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="pairs">键值对集合</param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <exception cref="ArgumentException"><paramref name="pairs" /> has same key</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dict = new Dictionary<string, int> {{"a", 1}, {"b", 2}};
        /// var appendDict = new Dictionary<string, int> {{"c", 3}, {"d", 4}};
        /// dict.AddRange(appendDict);
        /// // dict = {{"a", 1}, {"b", 2}, {"c", 3}, {"d", 4}};
        ///         ]]>
        ///     </code>
        /// </example>
        public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> @this, IEnumerable<KeyValuePair<TKey, TValue>> pairs)
        {
            foreach (var pair in pairs) @this.Add(pair);
        }

        /// <summary>
        ///     <para>批量添加</para>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="pairs">键值对数组</param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <exception cref="ArgumentException"><paramref name="pairs" /> has same key</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dict = new Dictionary<string, int> {{"a", 1}, {"b", 2}};
        /// dict.AddRangeParams(new KeyValuePair<string, int>("c", 3), new KeyValuePair<string, int>("d", 4));
        /// // dict = {{"a", 1}, {"b", 2}, {"c", 3}, {"d", 4}};
        ///         ]]>
        ///     </code>
        /// </example>
        public static void AddRangeParams<TKey, TValue>(this IDictionary<TKey, TValue> @this, params KeyValuePair<TKey, TValue>[] pairs)
        {
            @this.AddRange(pairs);
        }
    }
}