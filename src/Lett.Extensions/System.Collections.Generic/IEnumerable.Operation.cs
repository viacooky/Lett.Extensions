using System;
using System.Collections.Generic;
using System.Linq;
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
        ///     对指定集合的每个元素执行指定操作。
        /// </summary>
        /// <param name="this"></param>
        /// <param name="action">
        ///     <para>指定操作</para>
        ///     <para>T: 元素</para>
        /// </param>
        /// <typeparam name="T">元素类型</typeparam>
        /// <exception cref="ArgumentNullException"> <paramref name="this" /> is null</exception>
        /// <exception cref="ArgumentNullException"> <paramref name="action" /> is null</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var arr = new[] {"aa", "bb"};
        /// var rs  = new List<string>();
        /// arr.ForEach(str => rs.Add(str));
        /// // rs[0] = "aa"
        /// // rs[1] = "bb"
        ///         ]]>
        ///     </code>
        /// </example>
        public static void ForEach<T>(this IEnumerable<T> @this, Action<T> action)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this), $"{nameof(@this)} is null");
            if (action == null) throw new ArgumentNullException(nameof(action), $"{nameof(action)} is null");
            foreach (var item in @this) action(item);
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

        /// <summary>
        ///     返回序列中的非重复元素
        /// </summary>
        /// <param name="this"></param>
        /// <param name="selector">选择器，选择用于比较的对象</param>
        /// <param name="equalityComparer">比较器</param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="this" /> is null</exception>
        /// <exception cref="ArgumentNullException"><paramref name="selector" /> is null</exception>
        /// <exception cref="ArgumentNullException"><paramref name="equalityComparer" /> is null</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var input = new List<MyClass> {new MyClass {Age = 2, Name = "a"}, new MyClass {Age = 2, Name = "A"}, new MyClass {Age = 2, Name = "b"}};
        /// 
        /// var rs1 = input.Distinct(s => s.Name, StringComparer.OrdinalIgnoreCase)
        /// .ToList();
        /// 
        /// rs1.Count;      // 2
        /// rs1[0].Name;    // "a"
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var input = new List<MyClass> {new MyClass {Age = 2, Name = "a"}, new MyClass {Age = 2, Name = "A"}, new MyClass {Age = 2, Name = "b"}};
        /// 
        /// var rs2 = input.Distinct(s => s.Age, EqualityComparer<int>.Default)
        /// .ToList();
        /// 
        /// rs2.Count;      // 1
        /// rs2[0];         // "a"
        ///         ]]>
        ///     </code>
        /// </example>
        public static IEnumerable<T> Distinct<T, TResult>(this IEnumerable<T> @this, Func<T, TResult> selector, IEqualityComparer<TResult> equalityComparer)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this), "is null");
            if (selector == null) throw new ArgumentNullException(nameof(selector), "is null");
            if (equalityComparer == null) throw new ArgumentNullException(nameof(equalityComparer), "is null");

            var rs = new HashSet<TResult>(equalityComparer);
            foreach (var element in @this)
            {
                var setValue = selector(element);
                if (rs.Contains(setValue)) continue;
                yield return element;
                rs.Add(setValue);
            }
        }

        /// <summary>
        ///     <para>分割成指定size的块</para>
        ///     <remarks>like this : <br /> new[] {1, 2, 3, 4, 5, 6, 7}.SplitBlock(3); -&gt; {{1, 2, 3}, {4, 5, 6}, {7}}</remarks>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="size">size</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="this" /> is null</exception>
        /// <exception cref="ArgumentException"><paramref name="size" /> less than 1</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var s = new[] {1, 2, 3, 4, 5, 6, 7};
        /// var rs = s.Block(2);  // rs = {{1, 2}, {3, 4}, {5, 6}, {7}}
        /// var rs2 = s.Block(3); // rs2 = {{1, 2, 3}, {4, 5, 6}, {7}}
        /// var rs3 = s.Block(4); // rs3 = {{1, 2, 3, 4}, {5, 6, 7}}
        ///         ]]>
        ///     </code>
        /// </example>
        public static IEnumerable<IEnumerable<T>> SplitBlock<T>(this IEnumerable<T> @this, int size)
        {
            if (@this.IsNull()) throw new ArgumentNullException(nameof(@this), "is null");
            if (size < 1) throw new ArgumentException($"{nameof(size)} less than 1", nameof(size));
            var source = @this.ToList();
            var rs     = new List<IEnumerable<T>>();
            var index  = 0;
            while (index < source.Count)
            {
                rs.Add(source.Skip(index).Take(size));
                index += size;
            }

            return rs;
        }
    }
}