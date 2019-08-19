using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
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

        /// <summary>
        ///     转换为实体
        /// </summary>
        /// <param name="this"></param>
        /// <param name="converter">
        ///     <para>参数 <see cref="DataRow" />: 当前行 </para>
        ///     <para>参数 <typeparamref name="T" />: 目标新实例</para>
        /// </param>
        /// <typeparam name="T">目标类型</typeparam>
        /// <returns>目标对象 <typeparamref name="T" /></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var rs = dt.Rows[0].ToEntity<TestClass1>((row, newClass) =>
        /// {
        ///     newClass.Property1    = row.Cell<string>("Property1");
        ///     newClass.PublicField1 = row.Cell<string>("PublicField1");
        ///     return newClass;
        /// });
        ///         ]]>
        ///     </code>
        /// </example>
        public static T ToEntity<T>(this DataRow @this, Func<DataRow, T, T> converter) where T : class, new()
        {
            var newObj = new T();
            return converter(@this, newObj);
        }

        /// <summary>
        ///     <para>转换为动态对象集合</para>
        ///     <para>值为 <see cref="DBNull.Value" /> 转换为 Null </para>
        /// </summary>
        /// <param name="this"></param>
        /// <returns>如果Cell为 <see cref="DBNull.Value" /> 则动态对象属性的值为 null </returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DataTable();
        /// dt.Columns.Add("col1", typeof(string));
        /// dt.Columns.Add("col2", typeof(DateTime));
        /// dt.Columns.Add("col3", typeof(decimal));
        /// dt.Columns.Add("col4", typeof(string));
        /// dt.Columns.Add("col5", typeof(string));
        /// dt.Rows.Add("strVal", new DateTime(2019, 4, 1), 100.23m, DBNull.Value, null);
        /// var rs = dt.Rows[0].ToDynamicObject();
        /// 
        /// // rs.col1 == "strVal"
        /// // rs.col2 == new DateTime(2019, 4, 1)
        /// // rs.col3 == 100.23m
        /// // rs.col4 is null
        /// // rs.col5 is null
        ///         ]]>
        ///     </code>
        /// </example>
        public static dynamic ToDynamicObject(this DataRow @this)
        {
            var rs = (IDictionary<string, object>) new ExpandoObject();
            foreach (DataColumn column in @this.Table.Columns)
                rs.Add(column.ColumnName, @this[column.ColumnName] == DBNull.Value ? null : @this[column.ColumnName]);
            return rs;
        }

        /// <summary>
        ///     列是否存在
        /// </summary>
        /// <param name="this"></param>
        /// <param name="columnName">列名</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">columnName is null or empty</exception>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// row.HasColumn("FRowId");
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool HasColumn(this DataRow @this, string columnName)
        {
            return @this.Table.Columns.Contains(columnName);
        }

        /// <summary>
        ///     <para>设置值</para>
        ///     <para>出现异常时，使用 <c>DBNull.Value</c> 进行填充</para>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="columnName"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="ArgumentNullException"><paramref name="columnName" /> is null</exception>
        /// <exception cref="ArgumentNullException"><typeparamref name="T" /> is null</exception>
        /// <exception cref="ArgumentException"><paramref name="columnName" /> not exist</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// row.SetValue("FColumnName", "value");
        /// // if column "FColumnName" type is bool, row["FColumnName"] is DBNull.Value
        ///         ]]>
        ///     </code>
        /// </example>
        public static void SetValue<T>(this DataRow @this, string columnName, T value)
        {
            @this.SetValue(columnName, value, true);
        }

        /// <summary>
        ///     设置值
        /// </summary>
        /// <param name="this"></param>
        /// <param name="columnName">列名</param>
        /// <param name="value">值</param>
        /// <param name="isDefaultDbNull">赋值出现异常时，是否使用 <c>DBNull.Value</c> 进行填充</param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="ArgumentNullException"><paramref name="columnName" /> is null</exception>
        /// <exception cref="ArgumentNullException"><typeparamref name="T" /> is null</exception>
        /// <exception cref="ArgumentException"><paramref name="columnName" /> not exist</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// row.SetValue("FColumnName", "value", true);
        /// // if column "FColumnName" type is bool, row["FColumnName"] is DBNull.Value
        ///         ]]>
        ///     </code>
        /// </example>
        public static void SetValue<T>(this DataRow @this, string columnName, T value, bool isDefaultDbNull)
        {
            if (columnName.IsNullOrEmpty()) throw new ArgumentNullException(nameof(columnName));
            if (!@this.HasColumn(columnName)) throw new ArgumentException("column not exist", nameof(columnName));
            if (typeof(T) == null) throw new ArgumentNullException(nameof(T));
            if (typeof(T).NotIn(DataTableExtensions.SupportedDataTypes)) throw new ArgumentException("type not supported", nameof(T));
            try { @this[columnName] = value; }
            catch (Exception)
            {
                if (!isDefaultDbNull) throw;
                @this[columnName] = DBNull.Value;
            }
        }
    }
}