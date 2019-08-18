using System;

namespace Lett.Extensions
{
    public static class GuidExtensions
    {
        /// <summary>
        ///     当 <paramref name="this" /> 为 <c>Guid.Empty</c> 时，返回新的 Guid/>
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var guid = Guid.Empty;
        /// guid = guid.GetNewGuidIfEmpty();
        ///         ]]>
        ///     </code>
        /// </example>
        public static Guid GetNewGuidIfEmpty(this Guid @this)
        {
            return @this == Guid.Empty ? Guid.NewGuid() : @this;
        }
    }
}