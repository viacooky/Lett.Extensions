using System.Data;
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
    }
}