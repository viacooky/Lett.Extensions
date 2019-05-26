using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lett.Extensions
{
    /// <summary>
    ///     Object 扩展方法
    /// </summary>
    public static partial class ObjectExtensions
    {
        /// <summary>
        ///     指定类型的实例是否能分配给当前类型实例
        /// </summary>
        /// <param name="this"></param>
        /// <param name="targetType">指定类型</param>
        /// <returns></returns>
        public static bool IsAssignableFrom(this object @this, Type targetType)
        {
            return @this.GetType().IsAssignableFrom(targetType);
        }

        /// <summary>
        ///     获取当前对象类型名称
        /// </summary>
        /// <param name="this"></param>
        /// <returns><paramref name="this" /> 为空 返回 <see cref="string.Empty" /></returns>
        /// <exception cref="NullReferenceException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var obj1 = new MyClass();
        /// obj1.GetTypeName(); // "MyClass"
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var obj2 = "";
        /// obj2.GetTypeName(); // "String"
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// object obj4 = null;
        /// obj4.GetTypeName(); // string.Empty
        ///         ]]>
        ///     </code>
        /// </example>
        public static string GetTypeName(this object @this)
        {
            return @this == null ? string.Empty : @this.GetType().Name;
        }
    }
}