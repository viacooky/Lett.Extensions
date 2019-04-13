using System;

namespace Lett.Extensions
{
    /// <summary>
    ///     对象比较相关拓展方法
    /// </summary>
    public static partial class Extensions
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