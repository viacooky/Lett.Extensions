using System.Collections.Generic;
using System.Data;
using System.Linq;
using Lett.Extensions.Exceptions;

namespace Lett.Extensions
{
    public static partial class Extensions
    {
        /// <summary>
        ///     是否存在数据行
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static bool HasRows(this DataTable @this)
        {
            return @this.Rows.Count > 0;
        }

        /// <summary>
        ///     获取首行
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static DataRow FirstRow(this DataTable @this)
        {
            if (!@this.HasRows()) throw new LettExtensionsDataTableException("当前DataTable没有行");
            return @this.Rows[0];
        }

        /// <summary>
        ///     获取末行
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static DataRow LastRow(this DataTable @this)
        {
            if (!@this.HasRows()) throw new LettExtensionsDataTableException("当前DataTable没有行");
            return @this.Rows[@this.Rows.Count - 1];
        }

        /// <summary>
        /// 获取DataRow可枚举对象
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static IEnumerable<DataRow> RowsEnumerable(this DataTable @this)
        {
            return @this.Rows.Cast<DataRow>();
        }
    }
}