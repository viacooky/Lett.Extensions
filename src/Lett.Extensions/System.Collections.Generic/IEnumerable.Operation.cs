using System;
using System.Collections.Generic;
using System.Text;

namespace Lett.Extensions
{
    /// <summary>
    ///     IEnumerable 扩展方法
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static partial class IEnumerableExtensions
    {
        /// <summary>
        ///     对指定集合的每个元素执行指定操作。
        /// </summary>
        /// <param name="this"></param>
        /// <param name="action">
        ///     <para>指定操作</para>
        ///     <para>int: 数组元素的索引</para>
        ///     <para>T: 元素</para>
        /// </param>
        /// <typeparam name="T">元素类型</typeparam>
        /// <exception cref="ArgumentNullException"> <paramref name="this" /> is null</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="action" /> is null</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var arr = new[] {"aa", "bb"};
        /// var rs  = new Dictionary<int, string>();
        /// arr.ForEach((index, str) => rs.Add(index, str));
        /// // rs[0] = "aa"
        /// // rs[1] = "bb"
        ///         ]]>
        ///     </code>
        /// </example>
        public static void ForEach<T>(this IEnumerable<T> @this, Action<int, T> action)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this), $"{nameof(@this)} is null");
            if (action == null) throw new ArgumentNullException(nameof(action), $"{nameof(action)} is null");
            var i = 0;
            foreach (var item in @this) action(i++, item);
        }

        /// <summary>
        ///     格式化为字符串
        /// </summary>
        /// <param name="this"></param>
        /// <param name="formatStr">格式化字符串，如："[{0}]"</param>
        /// <param name="formatParams">格式化字符串参数，需要与格式化字符串对应</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="formatStr" /> 为空</exception>
        /// <exception cref="FormatException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var input = new List<string> {"aa", "bb", "cc", "dd"};
        /// var rs = input.FormatString("[{0}]", s => new []{s});
        /// 
        /// // rs = "[aa][bb][cc][dd]"
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var input2 = new Dictionary<string,object>
        /// {
        ///     {"key1",1},
        ///     {"key2","value2"},
        ///     {"key3","value3"}
        /// };
        /// 
        /// var rs2 = input2.FormatString("[{0} - {1}]\r\n", pair => new[] {pair.Key, pair.Value});
        /// 
        /// // rs2 = "[key1 - 1]\r\n[key2 - value2]\r\n[key3 - value3]\r\n"
        ///         ]]>
        ///     </code>
        /// </example>
        public static string ToFormatString<T>(this IEnumerable<T> @this, string formatStr, Func<T, object[]> formatParams)
        {
            var rs = new StringBuilder();
            foreach (var i in @this) rs.Append(formatStr.Format(formatParams(i)));
            return rs.ToString();
        }
    }
}