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

        /// <summary>
        ///     int 获取枚举的描述
        ///     异常时 返回null
        /// </summary>
        /// <param name="this"></param>
        /// <param name="enumType">枚举类型，枚举类型不存在时，返回空字符串</param>
        /// <returns></returns>
        public static string GetEnumDescription(this int @this, Type enumType)
        {
            if (!enumType.IsEnum) return null;
            var enumValue = Enum.ToObject(enumType, @this);
            return ((Enum) enumValue).GetDescription();
        }
    }
}