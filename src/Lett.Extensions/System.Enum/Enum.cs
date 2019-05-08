using System;
using System.ComponentModel;

namespace Lett.Extensions
{
    /// <summary>
    /// Enum 扩展方法
    /// </summary>
    public static partial class EnumExtensions
    {
        /// <summary>
        ///     获取枚举描述
        ///     需要在枚举中加入 Description 属性
        ///     [Description("xxx")]
        ///     异常时 返回null
        /// </summary>
        /// <param name="this"></param>
        /// <returns>  </returns>
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