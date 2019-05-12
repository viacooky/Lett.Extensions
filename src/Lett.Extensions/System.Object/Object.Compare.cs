using System;

namespace Lett.Extensions
{
    /// <summary>
    ///     object 扩展方法 - 比较
    /// </summary>
    public static partial class ObjectExtensions
    {
        /// <summary>
        ///     是否DBNull
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        public static bool IsDBNull(this object @this)
        {
            return Convert.IsDBNull(@this);
        }
    }
}