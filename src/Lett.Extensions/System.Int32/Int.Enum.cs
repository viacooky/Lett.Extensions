using System;

namespace Lett.Extensions
{
    /// <summary>
    /// int 扩展方法
    /// </summary>
    public static partial class IntExtensions
    {
        /// <summary>
        ///     获取对应枚举的描述
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