using System;

namespace Lett.Extensions
{
    /// <summary>
    ///     Object 扩展方法
    /// </summary>
    public static partial class ObjectExtensions
    {
        /// <summary>
        ///     是否DBNull
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var value = DBNull.Value;
        /// value.IsDBNull(); // true
        ///         ]]>
        ///     </code>
        /// </example>
        // ReSharper disable once InconsistentNaming
        public static bool IsDBNull(this object @this)
        {
            return Convert.IsDBNull(@this);
        }
    }
}