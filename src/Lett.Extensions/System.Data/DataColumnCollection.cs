using System.Data;

namespace Lett.Extensions
{
    public static partial class Extensions
    {
        /// <summary>
        ///     批量增加 DataColumn
        /// </summary>
        /// <param name="this"></param>
        /// <param name="columnNames">列名数组</param>
        public static void AddRange(this DataColumnCollection @this, string[] columnNames)
        {
            foreach (var columnName in columnNames) @this.Add(columnName);
        }
    }
}