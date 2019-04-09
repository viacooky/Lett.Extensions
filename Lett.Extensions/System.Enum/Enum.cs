using System;
using System.ComponentModel;

namespace Lett.Extensions
{
    public static partial class Extensions
    {
        /// <summary>
        ///     获取枚举描述
        ///     需要在枚举中加入 Description 属性
        ///     [Description("xxx")]
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum @this)
        {
            var enumType = @this.GetType();
            var enumName = Enum.GetName(enumType, @this);
            if (enumName == null) return string.Empty;
            var fieldInfo = enumType.GetField(enumName);
            if (fieldInfo == null) return string.Empty;
            return Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute), false) is DescriptionAttribute descAttr
                ? descAttr.Description
                : string.Empty;
        }

        /// <summary>
        ///     int 获取枚举的描述
        /// </summary>
        /// <param name="this"></param>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static string GetEnumDescription(this int @this, Type enumType)
        {
            if (!enumType.IsEnum) return string.Empty;
            var enumValue = Enum.ToObject(enumType, @this);
            return ((Enum) enumValue).GetDescription();
        }
    }
}