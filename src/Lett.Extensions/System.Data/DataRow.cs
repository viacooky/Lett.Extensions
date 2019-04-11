using System;
using System.Data;

namespace Lett.Extensions
{
    public static partial class Extensions
    {
        /// <summary>
        ///     获取当前行中某个列的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="columnName">列名</param>
        /// <returns></returns>
        public static T Cell<T>(this DataRow @this, string columnName)
        {
            return @this.Cell(columnName, default(T));
        }

        /// <summary>
        ///     获取当前行中某个列的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="columnName">列名</param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static T Cell<T>(this DataRow @this, string columnName, Func<T> func)
        {
            return @this.Cell(columnName, func.Invoke());
        }

        /// <summary>
        ///     获取当前行中某个列的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <param name="columnName">列名</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static T Cell<T>(this DataRow @this, string columnName, T defaultValue)
        {
            return @this.Table.Columns.Contains(columnName)
                ? @this[columnName].To(defaultValue)
                : defaultValue;
        }
    }
}