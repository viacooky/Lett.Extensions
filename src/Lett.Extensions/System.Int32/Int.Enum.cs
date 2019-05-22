using System;
using System.Reflection;

namespace Lett.Extensions
{
    /// <summary>
    ///     Int 扩展方法
    /// </summary>
    public static partial class IntExtensions
    {
        /// <summary>
        ///     获取对应枚举的描述
        /// </summary>
        /// <param name="this"></param>
        /// <param name="enumType">枚举类型</param>
        /// <returns>获取失败 返回null</returns>
        /// <exception cref="ArgumentNullException"><paramref name="enumType" /> 为空</exception>
        /// <exception cref="ArgumentException"><paramref name="enumType" /> 不是枚举类型</exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="AmbiguousMatchException"></exception>
        /// <exception cref="TypeLoadException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// enum MyEnum
        /// {
        /// [System.ComponentModel.Description("这里是EnumValue0的说明")]
        /// EnumValue0 = 0,
        /// }
        /// 
        /// 0.GetEnumDescription(typeof(MyEnum); // "这里是EnumValue0的说明"
        ///         ]]>
        ///     </code>
        /// </example>
        public static string GetEnumDescription(this int @this, Type enumType)
        {
            if (!enumType.IsEnum) return null;
            var enumValue = Enum.ToObject(enumType, @this);
            return ((Enum) enumValue).GetDescription();
        }
    }
}