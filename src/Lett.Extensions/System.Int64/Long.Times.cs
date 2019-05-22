using System;

namespace Lett.Extensions
{
    /// <summary>
    ///     Long 扩展方法
    /// </summary>
    public static partial class LongExtensions
    {
        /// <summary>
        ///     执行次数操作，次数基于 <paramref name="this" />
        /// </summary>
        /// <param name="this"></param>
        /// <param name="action">执行的操作</param>
        /// <exception cref="ArgumentOutOfRangeException">执行次数 <paramref name="this" /> 小于0</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var rs = 0;
        /// 10L.Times(() => rs += 1); // rs == 10
        ///         ]]>
        ///     </code>
        /// </example>
        public static void Times(this long @this, Action action)
        {
            @this.Times(i => action());
        }

        /// <summary>
        ///     执行次数操作，次数基于 <paramref name="this" />
        /// </summary>
        /// <param name="this"></param>
        /// <param name="action">执行的操作(参数是从0开始的 index)</param>
        /// <exception cref="ArgumentOutOfRangeException">执行次数 <paramref name="this" /> 小于0</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var rs2 = 0;
        /// 10L.Times(i => rs2 += i); // rs2 == 45
        ///         ]]>
        ///     </code>
        /// </example>
        public static void Times(this long @this, Action<long> action)
        {
            for (var i = 0; i < @this; i++) action(i);
        }
    }
}