using System;
using System.ComponentModel;
using System.Reflection;

namespace Lett.Extensions
{
    /// <summary>
    ///     Enum 扩展方法
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        ///     <para>获取枚举描述</para>
        ///     <para>需要在枚举中加入 Description 属性</para>
        ///         <code>
        /// 示例
        ///         <![CDATA[
        /// private enum MyEnum
        /// {
        ///     [Description("这里是EnumValue0的描述")]
        ///     EnumValue0 = 0,
        /// }
        ///         ]]>
        ///     </code>
        /// </summary>
        /// <param name="this"></param>
        /// <returns>获取失败时 返回null</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="AmbiguousMatchException"></exception>
        /// <exception cref="TypeLoadException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var rs = MyEnum.EnumValue0.GetDescription(); // rs == "这里是EnumValue0的描述" 
        ///         ]]>
        ///     </code>
        /// </example>
        public static string GetDescription(this Enum @this)
        {
            var enumType = @this.GetType();
            var enumName = Enum.GetName(enumType, @this);
            if (enumName == null) return null;
            var fieldInfo = enumType.GetField(enumName);
            if (fieldInfo == null) return null;
            return Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute), false) is DescriptionAttribute descAttr
                       ? descAttr.Description
                       : null;
        }
    }
}