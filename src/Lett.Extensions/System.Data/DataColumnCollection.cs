using System.Collections.Generic;
using System.Data;

namespace Lett.Extensions
{
    /// <summary>
    ///     DataColumnCollection 扩展方法
    /// </summary>
    public static class DataColumnCollectionExtensions
    {
        /// <summary>
        ///     批量增加 DataColumn
        /// </summary>
        /// <param name="this"></param>
        /// <param name="columnNames">列名集合</param>
        /// <exception cref="DuplicateNameException"><paramref name="columnNames" />有特殊列名</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var dt       = new DataTable();
        /// var colNames = new[] {"Field1", "Field2", "Field3"};
        /// dt.Columns.AddRange(colNames);
        /// // dt.Columns == {"Field1", "Field2", "Field3"}
        ///         ]]>
        ///     </code>
        /// </example>
        public static void AddRange(this DataColumnCollection @this, IEnumerable<string> columnNames)
        {
            foreach (var columnName in columnNames) @this.Add(columnName);
        }
    }
}