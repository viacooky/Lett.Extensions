using System;

namespace Lett.Extensions
{
    /// <summary>
    ///     long 扩展方法 - 次数操作
    /// </summary>
    public static partial class LongExtensions
    {
        /// <summary>
        ///     执行次数操作，次数基于原 long 值
        /// </summary>
        /// <param name="this">次数</param>
        /// <param name="action">执行的操作</param>
        public static void Times(this long @this, Action action)
        {
            @this.Times(i => action());
        }

        /// <summary>
        ///     执行次数操作，次数基于原 long 值
        /// </summary>
        /// <param name="this">次数</param>
        /// <param name="action">执行的操作(参数是从0开始的 index)</param>
        public static void Times(this long @this, Action<long> action)
        {
            for (var i = 0; i < @this; i++) action(i);
        }
    }
}