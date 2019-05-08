using System.Data;

namespace Lett.Extensions
{
    
    /// <summary>
    /// DataColumnCollection 扩展方法
    /// </summary>
    public static partial class DataColumnCollectionExtensions
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