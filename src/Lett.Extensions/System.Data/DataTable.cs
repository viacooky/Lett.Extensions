using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using Lett.Extensions.Exceptions;

namespace Lett.Extensions
{
    /// <summary>
    ///     DataTable 扩展方法
    /// </summary>
    public static class DataTableExtensions
    {
        /// <summary>
        ///     是否存在数据行
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// dataTable.HasRows();
        ///         ]]>
        ///     </code>
        /// </example>
        public static bool HasRows(this DataTable @this)
        {
            return @this.Rows.Count > 0;
        }

        /// <summary>
        ///     获取首行
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="DataTableException">当前DataTable没有行</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// dataTable.FirstRow();
        ///         ]]>
        ///     </code>
        /// </example>
        public static DataRow FirstRow(this DataTable @this)
        {
            if (!@this.HasRows()) throw new DataTableException("当前DataTable没有行");
            return @this.Rows[0];
        }

        /// <summary>
        ///     获取末行
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="DataTableException">当前DataTable没有行</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// dataTable.LastRow();
        ///         ]]>
        ///     </code>
        /// </example>
        public static DataRow LastRow(this DataTable @this)
        {
            if (!@this.HasRows()) throw new DataTableException("当前DataTable没有行");
            return @this.Rows[@this.Rows.Count - 1];
        }

        /// <summary>
        ///     获取DataRow可枚举对象
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><see cref="DataRow" /> 为空</exception>
        /// <exception cref="InvalidCastException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var rs = dataTable.RowsEnumerable();
        ///         ]]>
        ///     </code>
        /// </example>
        public static IEnumerable<DataRow> RowsEnumerable(this DataTable @this)
        {
            return @this.Rows.Cast<DataRow>();
        }

        /// <summary>
        ///     获取DataColumn可枚举对象
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><see cref="DataColumn" />为空</exception>
        /// <exception cref="InvalidCastException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var rs = dataTable.ColumnsEnumerable();
        ///         ]]>
        ///     </code>
        /// </example>
        public static IEnumerable<DataColumn> ColumnsEnumerable(this DataTable @this)
        {
            return @this.Columns.Cast<DataColumn>();
        }

        /// <summary>
        ///     获取Column的数据类型
        /// </summary>
        /// <param name="this"></param>
        /// <param name="columnName">列名</param>
        /// <returns></returns>
        /// <exception cref="DataTableException">DataTable中不包含<paramref name="columnName" />}</exception>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var columnType = dt.GetColumnDataType("columnName");
        ///         ]]>
        ///     </code>
        /// </example>
        public static Type GetColumnDataType(this DataTable @this, string columnName)
        {
            if (!@this.Columns.Contains(columnName)) throw new DataTableException(@"DataTable中不包含Column:{columnName}");
            return @this.Columns[columnName].DataType;
        }

        /// <summary>
        ///     获取Column的数据类型
        /// </summary>
        /// <param name="this"></param>
        /// <param name="index">索引</param>
        /// <returns></returns>
        /// <exception cref="DataTableException"><paramref name="index" /> 索引超出了数组范围</exception>
        /// <exception cref="ArgumentException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var columnType = dataTable.GetColumnDataType(-1);
        ///         ]]>
        ///     </code>
        /// </example>
        public static Type GetColumnDataType(this DataTable @this, int index)
        {
            if (index < 0) throw new DataTableException("索引超出了数组范围");
            if (@this.Columns.Count - 1 < index) throw new DataTableException("索引超出了数组范围");
            return @this.Columns[index].DataType;
        }

        /// <summary>
        ///     <para>转换为实体列表</para>
        ///     <para>使用<see cref="DataRow" />中的值，填充 目标类型 的 <see cref="FieldInfo" /> 与 <see cref="PropertyInfo" /> </para>
        ///     <para>匹配规则: <see cref="FieldInfo" />.Name 或 <see cref="PropertyInfo" />.Name 与 ColumnName 相同</para>
        /// </summary>
        /// <param name="this"></param>
        /// <typeparam name="T">目标类型</typeparam>
        /// <returns>返回 List&lt;<typeparamref name="T" />&gt;</returns>
        /// <exception cref="ArgumentNullException"><paramref name="this" />.<see cref="DataRow" /> 为空</exception>
        /// <exception cref="InvalidCastException"></exception>
        /// <exception cref="FieldAccessException"></exception>
        /// <exception cref="TargetException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="MethodAccessException"></exception>
        /// <exception cref="TargetInvocationException"></exception>
        /// <exception cref="ArgumentNullException"><paramref name="this" />.<see cref="RowsEnumerable" /> 为空</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var rs = dataTable.ToEntityList<TestClass1>();
        ///         ]]>
        ///     </code>
        /// </example>
        public static List<T> ToEntityList<T>(this DataTable @this) where T : class, new()
        {
            return @this.RowsEnumerable().Select(s => s.ToEntity<T>()).ToList();
        }

        /// <summary>
        ///     转换为实体列表
        /// </summary>
        /// <param name="this"></param>
        /// <param name="converter">
        ///     <para>参数 <see cref="DataRow" />: 当前行 </para>
        ///     <para>参数 <typeparamref name="T" />: 目标新实例</para>
        /// </param>
        /// <typeparam name="T">目标类型</typeparam>
        /// <returns>返回 List&lt;<typeparamref name="T" />&gt;</returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var rs = dt.ToEntityList<TestClass1>((row, newObj) =>
        /// {
        ///     newObj.PublicField = row.Cell<string>("PublicField");
        ///     return newObj;
        /// });
        ///         ]]>
        ///     </code>
        /// </example>
        public static List<T> ToEntityList<T>(this DataTable @this, Func<DataRow, T, T> converter) where T : class, new()
        {
            return @this.RowsEnumerable().Select(s => s.ToEntity(converter)).ToList();
        }


        /// <summary>
        ///     <para>转换为动态对象</para>
        ///     <para>值为 <see cref="DBNull.Value" /> 转换为 Null </para>
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt = new DataTable();
        /// dt.Columns.AddRange(new[] {"Name", "Number"});
        /// dt.Columns.Add(new DataColumn("Age", typeof(int)));
        /// dt.Columns.Add(new DataColumn("CreateTime", typeof(DateTime)));
        /// dt.Rows.Add("Name_1", "Number_1", 10, DateTime.Now);
        /// dt.Rows.Add("Name_2", "Number_2", 10, DateTime.Now);
        /// dt.Rows.Add("Name_3", "Number_3", 10, DateTime.Now);
        /// dt.Rows.Add("Name_4", DBNull.Value, 10, DateTime.Now);
        /// 
        /// var rs = dt.ToDynamicObjects().ToList();
        /// 
        /// // rs[0].Name == "Name_1"
        /// // rs[0].Number == "Number_1"
        /// // rs[0].Age == 10
        /// // rs[0].CreateTime.GetType() == typeof(DateTime)
        /// 
        /// // rs[3].Number is null
        ///         ]]>
        ///     </code>
        /// </example>
        public static IEnumerable<dynamic> ToDynamicObjects(this DataTable @this)
        {
            return @this.RowsEnumerable().Select(row => new DynamicRowObject(row));
        }

        private sealed class DynamicRowObject : DynamicObject
        {
            private readonly DataRow _row;

            internal DynamicRowObject(DataRow row)
            {
                _row = row;
            }

            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                var rs = _row.Table.Columns.Contains(binder.Name);
                result = rs
                             ? _row[binder.Name] != DBNull.Value ? _row[binder.Name] : null
                             : null;
                return rs;
            }
        }
    }
}