using System;
using System.Linq;
using System.Reflection;

namespace Lett.Extensions
{
    /// <summary>
    ///     type 扩展方法
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        ///     是否包含 <see cref="PropertyInfo" /> (可访问的<see cref="PropertyInfo" />)
        /// </summary>
        /// <param name="this"></param>
        /// <param name="propertyName">属性名，忽略大小写</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// public class Class1
        /// {
        /// public  string PropertyA { get; set; }
        /// private string PropertyB { get; set; }
        /// }
        /// 
        /// 
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool HasProperty(this Type @this, string propertyName)
        {
            return @this.GetProperties().Any(w => w.Name.Equals(propertyName, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}