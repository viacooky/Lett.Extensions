using System;

namespace Lett.Extensions
{
    /// <summary>
    ///     bool 扩展方法
    /// </summary>
    public static class BooleanExtensions
    {
        /// <summary>
        ///     结果为 True 时，执行方法
        /// </summary>
        /// <param name="this">结果</param>
        /// <param name="action">执行的方法</param>
        public static void IfTrue(this bool @this, Action action)
        {
            if (@this) action();
        }

        /// <summary>
        ///     结果为 True 时，返回参数 (结果为 False 时，返回参数类型默认值)
        /// </summary>
        /// <param name="this">结果</param>
        /// <param name="result">参数</param>
        /// <typeparam name="T">参数类型</typeparam>
        /// <returns></returns>
        public static T IfTrue<T>(this bool @this, T result)
        {
            return @this ? result : default;
        }

        /// <summary>
        ///     结果为 False 时，执行方法
        /// </summary>
        /// <param name="this">结果</param>
        /// <param name="action">执行的方法</param>
        public static void IfFalse(this bool @this, Action action)
        {
            if (!@this) action();
        }

        /// <summary>
        ///     结果为 False 时，返回参数 (结果为 True 时，返回参数类型默认值)
        /// </summary>
        /// <param name="this">结果</param>
        /// <param name="result">参数</param>
        /// <typeparam name="T">参数类型</typeparam>
        /// <returns></returns>
        public static T IfFalse<T>(this bool @this, T result)
        {
            return !@this ? result : default;
        }
    }
}