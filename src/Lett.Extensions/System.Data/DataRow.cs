using System;
using System.Data;
using System.Reflection;

namespace Lett.Extensions
{
    /// <summary>
    ///     DataRow 扩展方法
    /// </summary>
    public static class DataRowExtensions
    {
        /// <summary>
        ///     获取当前行中某个列的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="columnName">列名</param>
        /// <returns></returns>
        public static T Cell<T>(this DataRow @this, string columnName) where T : IConvertible
        {
            return @this.Cell(columnName, default(T));
        }

        /// <summary>
        ///     获取当前行中某个列的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="columnName">列名</param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static T Cell<T>(this DataRow @this, string columnName, Func<T> func) where T : IConvertible
        {
            return @this.Cell(columnName, func.Invoke());
        }

        /// <summary>
        ///     获取当前行中某个列的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="columnName">列名</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static T Cell<T>(this DataRow @this, string columnName, T defaultValue) where T : IConvertible
        {
            return @this.Table.Columns.Contains(columnName)
                       ? @this[columnName].To(defaultValue)
                       : defaultValue;
        }

        /// <summary>
        ///     转换为实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <returns></returns>
        public static T ToEntity<T>(this DataRow @this) where T : class, new()
        {
            var type       = typeof(T);
            var fields     = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var obj = new T();

            // fields
            foreach (var fieldInfo in fields)
                if (@this.Table.Columns.Contains(fieldInfo.Name))
                    fieldInfo.SetValue(obj, @this[fieldInfo.Name]);

            // properties
            foreach (var propertyInfo in properties)
                if (@this.Table.Columns.Contains(propertyInfo.Name))
                    propertyInfo.SetValue(obj, @this[propertyInfo.Name]);

            return obj;
        }
    }
}