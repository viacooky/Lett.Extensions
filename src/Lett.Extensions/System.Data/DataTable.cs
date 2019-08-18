using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Lett.Extensions
{
    /// <summary>
    ///     DataTable 扩展方法
    /// </summary>
    public static class DataTableExtensions
    {
        /// <summary>
        ///     <para><see cref="DataTable" /> 支持的数据类型</para>
        ///     <remarks>
        ///         参考：<a>https://docs.microsoft.com/zh-cn/dotnet/api/system.data.datacolumn.datatype?view=netcore-2.0</a>
        ///     </remarks>
        /// </summary>
        public static readonly Type[] SupportedDataTypes =
        {
            typeof(bool),
            typeof(byte),
            typeof(char),
            typeof(DateTime),
            typeof(decimal),
            typeof(double),
            typeof(Guid),
            typeof(short),
            typeof(int),
            typeof(long),
            typeof(sbyte),
            typeof(float),
            typeof(string),
            typeof(TimeSpan),
            typeof(ushort),
            typeof(uint),
            typeof(ulong),
            typeof(byte[])
        };

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
        /// <exception cref="ArgumentException">当前DataTable没有行</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// dataTable.FirstRow();
        ///         ]]>
        ///     </code>
        /// </example>
        public static DataRow FirstRow(this DataTable @this)
        {
            if (!@this.HasRows()) throw new ArgumentException("当前DataTable没有行");
            return @this.Rows[0];
        }

        /// <summary>
        ///     获取末行
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">当前DataTable没有行</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// dataTable.LastRow();
        ///         ]]>
        ///     </code>
        /// </example>
        public static DataRow LastRow(this DataTable @this)
        {
            if (!@this.HasRows()) throw new ArgumentException("当前DataTable没有行");
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
        /// <exception cref="ArgumentException">DataTable中不包含<paramref name="columnName" /></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var columnType = dt.GetColumnDataType("columnName");
        ///         ]]>
        ///     </code>
        /// </example>
        public static Type GetColumnDataType(this DataTable @this, string columnName)
        {
            if (!@this.Columns.Contains(columnName)) throw new ArgumentException($"DataTable中不包含Column:{columnName}");
            return @this.Columns[columnName].DataType;
        }

        /// <summary>
        ///     获取Column的数据类型
        /// </summary>
        /// <param name="this"></param>
        /// <param name="index">索引</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index" /> 索引超出了数组范围</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var columnType = dataTable.GetColumnDataType(-1);
        ///         ]]>
        ///     </code>
        /// </example>
        public static Type GetColumnDataType(this DataTable @this, int index)
        {
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index), $"{nameof(index)} out of range");
            if (@this.Columns.Count - 1 < index) throw new ArgumentOutOfRangeException(nameof(index), $"{nameof(index)} out of range");
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
        ///     <para>转换为动态对象集合</para>
        ///     <para>值为 <see cref="DBNull.Value" /> 转换为 Null </para>
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
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
        /// dt.Rows.Add("strVal2", new DateTime(2019, 4, 2), 122.23m, DBNull.Value, null);
        /// var rs = dt.ToDynamicObjects().ToList();
        /// 
        /// // rs[0].col1 == "strVal"
        /// // rs[0].col2 == new DateTime(2019, 4, 1)
        /// // rs[1].col3 == 122.23m
        /// // rs[1].col4 is null
        /// // rs[1].col5 is null
        ///         ]]>
        ///     </code>
        /// </example>
        public static IEnumerable<dynamic> ToDynamicObjects(this DataTable @this)
        {
            return @this.RowsEnumerable().Select(row => row.ToDynamicObject());
        }

        /// <summary>
        ///     更新
        /// </summary>
        /// <param name="this"></param>
        /// <param name="columnName">列名</param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="ArgumentNullException"><paramref name="columnName" /> is null</exception>
        /// <exception cref="ArgumentNullException"><typeparamref name="T" /> is null</exception>
        /// <exception cref="ArgumentException"><paramref name="columnName" /> not exist</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// _testTable1.Update("FName", "a");
        /// // it like SQL: UPDATE [table] set FName = 'a'
        ///         ]]>
        ///     </code>
        /// </example>
        public static void Update<T>(this DataTable @this, string columnName, T value)
        {
            @this.Update(row => true, columnName, value);
        }

        /// <summary>
        ///     更新
        /// </summary>
        /// <param name="this"></param>
        /// <param name="selector"><see cref="DataRow" /> 选择器</param>
        /// <param name="columnName">列名</param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="ArgumentNullException"><paramref name="columnName" /> is null</exception>
        /// <exception cref="ArgumentNullException"><typeparamref name="T" /> is null</exception>
        /// <exception cref="ArgumentException"><paramref name="columnName" /> not exist</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// _testTable1.Update(row => row["FRowId"].ToString().Equals("RowId_3"), "FInt_Col", "a");
        /// // it like SQL: UPDATE [table] SET FInt_Col = FRowId WHERE FRowId = 'RowId_3'
        ///         ]]>
        ///     </code>
        /// </example>
        public static void Update<T>(this DataTable @this, Func<DataRow, bool> selector, string columnName, T value)
        {
            @this.Update(selector, columnName, value, true, false);
        }

        /// <summary>
        ///     更新
        /// </summary>
        /// <param name="this"></param>
        /// <param name="selector"><see cref="DataRow" /> 选择器</param>
        /// <param name="columnName">列名</param>
        /// <param name="value"></param>
        /// <param name="isDefaultDbNull">出现异常时，使用 <c>DBNull.Value</c> 进行填充</param>
        /// <param name="isAcceptChanges">是否在更新完成后 使用 <c>isAcceptChanges</c></param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="ArgumentNullException"><paramref name="columnName" /> is null</exception>
        /// <exception cref="ArgumentNullException"><typeparamref name="T" /> is null</exception>
        /// <exception cref="ArgumentException"><paramref name="columnName" /> not exist</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// dataTable.Update(row=> row["FRowId"].toString().Equals("rowId"), "FName", "this is name", true, false);
        /// // it like SQL: UPDATE [table] SET FName = 'this is name' WHERE FRowId = 'rowId'
        ///         ]]>
        ///     </code>
        /// </example>
        public static void Update<T>(this DataTable @this, Func<DataRow, bool> selector, string columnName, T value, bool isDefaultDbNull, bool isAcceptChanges)
        {
            @this.RowsEnumerable()
                 .Where(selector)
                 .ForEach(row =>
                 {
                     row.BeginEdit();
                     row.SetValue(columnName, value, isDefaultDbNull);
                 });
            if (isAcceptChanges) @this.AcceptChanges();
        }

        /// <summary>
        ///     更新
        /// </summary>
        /// <param name="this"></param>
        /// <param name="selector"><see cref="DataRow" /> 选择器</param>
        /// <param name="columnName">列名</param>
        /// <param name="func">
        ///     <para>委托方法</para>
        ///     <remarks>
        ///         DataRow: 当前 <see cref="DataRow" />
        ///     </remarks>
        /// </param>
        /// <param name="isDefaultDbNull">出现异常时，使用 <c>DBNull.Value</c> 进行填充</param>
        /// <param name="isAcceptChanges">是否在更新完成后 使用 <c>isAcceptChanges</c></param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="ArgumentNullException"><paramref name="columnName" /> is null</exception>
        /// <exception cref="ArgumentNullException"><typeparamref name="T" /> is null</exception>
        /// <exception cref="ArgumentException"><paramref name="columnName" /> not exist</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// _testTable1.Update(row => row["FRowId"].toString().Equals("aaa"), "FName", row => $"{row["FRowId"]}", true, false);
        /// // it like SQL: UPDATE [table] SET FName = FRowId WHERE FRowId = 'aaa'
        ///         ]]>
        ///     </code>
        /// </example>
        public static void Update<T>(this DataTable @this, Func<DataRow, bool> selector, string columnName, Func<DataRow, T> func, bool isDefaultDbNull, bool isAcceptChanges)
        {
            @this.RowsEnumerable()
                 .Where(selector)
                 .ForEach((index, row) =>
                 {
                     row.BeginEdit();
                     row.SetValue(columnName, func(row), isDefaultDbNull);
                 });
            if (isAcceptChanges) @this.AcceptChanges();
        }

        /// <summary>
        ///     更新
        /// </summary>
        /// <param name="this"></param>
        /// <param name="selector"><see cref="DataRow" /> 选择器</param>
        /// <param name="columnName">列名</param>
        /// <param name="func">
        ///     <para>委托方法</para>
        ///     <remarks>
        ///         int: index  <br />
        ///         DataRow: 当前 <see cref="DataRow" />
        ///     </remarks>
        /// </param>
        /// <param name="isDefaultDbNull">出现异常时，使用 <c>DBNull.Value</c> 进行填充</param>
        /// <param name="isAcceptChanges">是否在更新完成后 使用 <c>isAcceptChanges</c></param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="ArgumentNullException"><paramref name="columnName" /> is null</exception>
        /// <exception cref="ArgumentNullException"><typeparamref name="T" /> is null</exception>
        /// <exception cref="ArgumentException"><paramref name="columnName" /> not exist</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// _testTable1.Update(row=>true, "FName", (i, row) => $"{i}_{row["FRowId"]}", true, false);
        ///         ]]>
        ///     </code>
        /// </example>
        public static void Update<T>(this DataTable @this, Func<DataRow, bool> selector, string columnName, Func<int, DataRow, T> func, bool isDefaultDbNull, bool isAcceptChanges)
        {
            @this.RowsEnumerable()
                 .Where(selector)
                 .ForEach((index, row) =>
                 {
                     row.BeginEdit();
                     row.SetValue(columnName, func(index, row), isDefaultDbNull);
                 });
            if (isAcceptChanges) @this.AcceptChanges();
        }
    }
}