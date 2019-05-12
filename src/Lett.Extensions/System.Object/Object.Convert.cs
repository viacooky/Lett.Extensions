using System;

namespace Lett.Extensions
{
    /// <summary>
    ///     object 扩展方法 - 对象转换
    /// </summary>
    public static partial class ObjectExtensions
    {
        #region 对象转换

        /// <summary>
        ///     对象转换,失败则返回 func (泛型约束为实现了IConvertible的类型)
        /// </summary>
        /// <typeparam name="T">
        ///     泛型约束为实现了IConvertible的类型(Boolean,Byte,Char,DateTime,System.DBNull,Decimal,Double,System.Enum,Int16,Int32,Int64,SByte,Single,String,UInt16,UInt32,UInt64
        ///     等)
        /// </typeparam>
        /// <param name="this"></param>
        /// <returns></returns>
        public static T To<T>(this object @this) where T : IConvertible
        {
            return @this.To(default(T));
        }

        /// <summary>
        ///     对象转换,失败则返回 func (泛型约束为实现了IConvertible的类型)
        /// </summary>
        /// <typeparam name="T">
        ///     泛型约束为实现了IConvertible的类型(Boolean,Byte,Char,DateTime,System.DBNull,Decimal,Double,System.Enum,Int16,Int32,Int64,SByte,Single,String,UInt16,UInt32,UInt64
        ///     等)
        /// </typeparam>
        /// <param name="this"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static T To<T>(this object @this, Func<T> func) where T : IConvertible
        {
            return @this.To(func.Invoke());
        }

        /// <summary>
        ///     对象转换,失败则返回 defaultValue (泛型约束为实现了IConvertible的类型)
        /// </summary>
        /// <typeparam name="T">
        ///     泛型约束为实现了IConvertible的类型(Boolean,Byte,Char,DateTime,System.DBNull,Decimal,Double,System.Enum,Int16,Int32,Int64,SByte,Single,String,UInt16,UInt32,UInt64
        ///     等)
        /// </typeparam>
        /// <param name="this"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T To<T>(this object @this, T defaultValue) where T : IConvertible
        {
            if (@this == null || @this == DBNull.Value) return defaultValue;
            if (typeof(T).IsEnum)
            {
                if (@this is int) return (T) @this;
                return (T) Enum.Parse(typeof(T), @this.ToString(), true);
            }

            try { return (T) Convert.ChangeType(@this, typeof(T)); }
            catch { return defaultValue; }
        }

        #endregion

        #region 对象强转换

        /// <summary>
        ///     查询 object 的 IsAssignableFrom
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <returns></returns>
        public static bool IsAssignableFrom<T>(this object @this)
        {
            return @this.IsAssignableFrom(typeof(T));
        }

        /// <summary>
        ///     查询 object 的 IsAssignableFrom
        /// </summary>
        /// <param name="this"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static bool IsAssignableFrom(this object @this, Type targetType)
        {
            return @this.GetType().IsAssignableFrom(targetType);
        }

        /// <summary>
        ///     对象强转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <returns></returns>
        public static T As<T>(this object @this)
        {
            return @this.As(default(T));
        }

        /// <summary>
        ///     对象强转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static T As<T>(this object @this, Func<T> func)
        {
            return @this.As(func.Invoke());
        }

        /// <summary>
        ///     对象强转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T As<T>(this object @this, T defaultValue)
        {
            try { return (T) @this; }
            catch { return defaultValue; }
        }

        #endregion
    }
}