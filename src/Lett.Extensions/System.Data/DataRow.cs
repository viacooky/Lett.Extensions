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
        /// <param name="this"></param>
        /// <param name="columnName">列名</param>
        /// <typeparam name="T">目标类型，约束为 <see cref="IConvertible" /></typeparam>
        /// <returns><paramref name="columnName" />不存在 或 转换失败，返回 default(<typeparamref name="T" />)</returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var rs = dataRow.Cell<string>("columnName"); // if fail return default(string)
        ///         ]]>
        ///     </code>
        /// </example>
        public static T Cell<T>(this DataRow @this, string columnName) where T : IConvertible
        {
            return @this.Cell(columnName, default(T));
        }

        /// <summary>
        ///     获取当前行中某个列的值
        /// </summary>
        /// <param name="this"></param>
        /// <param name="columnName">列名</param>
        /// <param name="func"></param>
        /// <typeparam name="T">目标类型，约束为 <see cref="IConvertible" /></typeparam>
        /// <returns><paramref name="columnName" />不存在 或 转换失败，返回 <paramref name="func" /></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var rs = dataRow.Cell<string>("columnName", () => "func return value"); 
        ///         ]]>
        ///     </code>
        /// </example>
        public static T Cell<T>(this DataRow @this, string columnName, Func<T> func) where T : IConvertible
        {
            return @this.Cell(columnName, func.Invoke());
        }

        /// <summary>
        ///     获取当前行中某个列的值
        /// </summary>
        /// <param name="this"></param>
        /// <param name="columnName">列名</param>
        /// <param name="defaultValue">默认值</param>
        /// <typeparam name="T">
        ///     目标类型，约束为 <see cref="IConvertible" />
        /// </typeparam>
        /// <returns><paramref name="columnName" />不存在 或 转换失败，返回 <paramref name="defaultValue" /></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var rs = dataRow.Cell("columnName", "abc"); // if fail return "abc"
        ///         ]]>
        ///     </code>
        /// </example>
        public static T Cell<T>(this DataRow @this, string columnName, T defaultValue) where T : IConvertible
        {
            return @this.Table.Columns.Contains(columnName)
                       ? @this[columnName].To(defaultValue)
                       : defaultValue;
        }

        /// <summary>
        ///     <para>转换为实体</para>
        ///     <para>使用<see cref="DataRow" />中的值，填充 目标类型 的 <see cref="FieldInfo" /> 与 <see cref="PropertyInfo" /></para>
        ///     <para>匹配规则: <see cref="FieldInfo" />.Name 或 <see cref="PropertyInfo" />.Name 与 ColumnName 相同</para>
        /// </summary>
        /// <param name="this"></param>
        /// <typeparam name="T">目标类型</typeparam>
        /// <returns>
        ///     目标对象 <typeparamref name="T" />
        /// </returns>
        /// <exception cref="FieldAccessException"></exception>
        /// <exception cref="TargetException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="MethodAccessException"></exception>
        /// <exception cref="TargetInvocationException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// dataTable.Rows[0].ToEntity<TestClass1>(); 
        ///         ]]>
        ///     </code>
        /// </example>
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