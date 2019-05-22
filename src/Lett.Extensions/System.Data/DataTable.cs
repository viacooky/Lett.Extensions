using System;
using System.Collections.Generic;
using System.Data;
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
    }
}