using System;
using System.Linq;

namespace Lett.Extensions
{
    /// <summary>
    ///     type 扩展方法
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        ///     是否包含Property
        /// </summary>
        /// <param name="this"></param>
        /// <param name="propertyName">属性名，忽略大小写</param>
        /// <returns></returns>
        public static bool HasProperty(this Type @this, string propertyName)
        {
            return @this.GetProperties().Any(w => w.Name.Equals(propertyName, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}