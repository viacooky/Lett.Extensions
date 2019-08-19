using System;
using System.Data;
using System.Linq;

namespace Lett.Extensions
{
    /// <summary>
    ///     DataTable 扩展方法
    /// </summary>
    public static partial class DataTableExtensions
    {
        /// <summary>
        ///     <para>更新</para>
        ///     <remarks>出现异常时，使用 <c>DBNull.Value</c> 进行填充</remarks>
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
        ///     <para>更新</para>
        ///     <remarks>出现异常时，使用 <c>DBNull.Value</c> 进行填充</remarks>
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
        /// dataTable.Update(row=> row["FRowId"].toString().Equals("rowId"), "FName", "this is name");
        /// // it like SQL: UPDATE [table] SET FName = 'this is name' WHERE FRowId = 'rowId'
        ///         ]]>
        ///     </code>
        /// </example>
        public static void Update<T>(this DataTable @this, Func<DataRow, bool> selector, string columnName, T value)
        {
            @this.Update(selector, columnName, (i, row) => value);
        }

        /// <summary>
        ///     <para>更新</para>
        ///     <remarks>出现异常时，使用 <c>DBNull.Value</c> 进行填充</remarks>
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
        /// <typeparam name="T"></typeparam>
        /// <exception cref="ArgumentNullException"><paramref name="columnName" /> is null</exception>
        /// <exception cref="ArgumentNullException"><typeparamref name="T" /> is null</exception>
        /// <exception cref="ArgumentException"><paramref name="columnName" /> not exist</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// _testTable1.Update(row=>true, "FName", (i, row) => $"{i}_{row["FRowId"]}");
        ///         ]]>
        ///     </code>
        /// </example>
        public static void Update<T>(this DataTable @this, Func<DataRow, bool> selector, string columnName, Func<int, DataRow, T> func)
        {
            @this.RowsEnumerable()
                 .Where(selector)
                 .ForEach((index, row) =>
                 {
                     row.BeginEdit();
                     row.SetValue(columnName, func(index, row));
                 });
        }
    }
}