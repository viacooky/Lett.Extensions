using System;
using System.Collections.Generic;
using System.Linq;

namespace Lett.Extensions
{
    public static partial class Extensions
    {
        /// <summary>
        ///     拓展ForEach方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(this IEnumerable<T> @this, Action<T> action)
        {
            @this.ToList().ForEach(action);
        }

        /// <summary>
        ///     是否空或空集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> @this)
        {
            return @this == null || !@this.Any();
        }
    }
}