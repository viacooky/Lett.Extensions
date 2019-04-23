﻿using System;
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
        /// <exception cref="LettExtensionsDataTableException"></exception>
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
        /// <exception cref="LettExtensionsDataTableException"></exception>
        /// <returns></returns>
        public static DataRow LastRow(this DataTable @this)
        {
            if (!@this.HasRows()) throw new LettExtensionsDataTableException("当前DataTable没有行");
            return @this.Rows[@this.Rows.Count - 1];
        }

        /// <summary>
        ///     获取DataRow可枚举对象
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static IEnumerable<DataRow> RowsEnumerable(this DataTable @this)
        {
            return @this.Rows.Cast<DataRow>();
        }

        /// <summary>
        ///     获取DataColumn可枚举对象
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static IEnumerable<DataColumn> ColumnsEnumerable(this DataTable @this)
        {
            return @this.Columns.Cast<DataColumn>();
        }

        /// <summary>
        ///     获取Column的数据类型
        /// </summary>
        /// <param name="this"></param>
        /// <param name="columnName">列名</param>
        /// <exception cref="LettExtensionsDataTableException"></exception>
        /// <returns></returns>
        public static Type GetColumnDataType(this DataTable @this, string columnName)
        {
            if (!@this.Columns.Contains(columnName)) throw new LettExtensionsDataTableException(@"DataTable中不包含Column:{columnName}");
            return @this.Columns[columnName].DataType;
        }

        /// <summary>
        ///     获取Column的数据类型
        /// </summary>
        /// <param name="this"></param>
        /// <param name="index">索引</param>
        /// <exception cref="LettExtensionsDataTableException"></exception>
        /// <returns></returns>
        public static Type GetColumnDataType(this DataTable @this, int index)
        {
            if (index < 0) throw new LettExtensionsDataTableException("索引超出了数组范围");
            if (@this.Columns.Count - 1 < index) throw new LettExtensionsDataTableException("索引超出了数组范围");
            return @this.Columns[index].DataType;
        }
    }
}