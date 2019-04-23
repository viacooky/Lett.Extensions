using System;
using System.Data;
using System.Linq;
using Lett.Extensions.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class DataTableTest
    {
        private DataTable _testTable1;


        [TestInitialize]
        public void Init()
        {
            _testTable1 = new DataTable();
            _testTable1.Columns.Add("FRowId", typeof(string));
            _testTable1.Columns.Add("FName", typeof(string));
        }

        [TestMethod]
        public void ZeroRows_Test()
        {
            // 空行Datatable情况
            _testTable1.Rows.Clear();
            Assert.IsFalse(_testTable1.HasRows());
            Assert.ThrowsException<LettExtensionsDataTableException>(() => _testTable1.FirstRow());
            Assert.ThrowsException<LettExtensionsDataTableException>(() => _testTable1.LastRow());
        }

        [TestMethod]
        public void HasRows_Test()
        {
            // 添加行
            _testTable1.Rows.Clear();
            Enumerable.Range(0, 10).ToList().ForEach(index => { _testTable1.Rows.Add($"RowId_{index}", $"Name_{index}"); });
            Assert.IsTrue(_testTable1.HasRows());
            Assert.AreEqual(_testTable1.FirstRow()["FRowId"].ToString(), "RowId_0");
            Assert.AreEqual(_testTable1.LastRow()["FRowId"].ToString(), "RowId_9");
        }

        [TestMethod]
        public void RowsEnumerable_Test()
        {
            _testTable1.Rows.Clear();
            Assert.IsNull(_testTable1.RowsEnumerable().FirstOrDefault());
            // 添加行
            Enumerable.Range(0, 10).ToList().ForEach(index => { _testTable1.Rows.Add($"RowId_{index}", $"Name_{index}"); });
            var tmp = _testTable1.RowsEnumerable().FirstOrDefault();
            Assert.IsNotNull(tmp);
            var tmp2 = _testTable1.RowsEnumerable().Where(s => s.Cell<string>("FRowId").Equals("RowId_3"));
            Assert.AreEqual(tmp2.Count(), 1);
        }


        [TestMethod]
        public void ColumnEnumerable_Test()
        {
            Assert.AreEqual(_testTable1.Columns.Count,_testTable1.ColumnsEnumerable().Count());
            Assert.AreEqual(_testTable1.Columns[0].ColumnName, _testTable1.ColumnsEnumerable().FirstOrDefault()?.ColumnName);
            Assert.AreEqual(_testTable1.Columns[_testTable1.Columns.Count - 1].ColumnName, _testTable1.ColumnsEnumerable().LastOrDefault()?.ColumnName);
        }

        [TestMethod]
        public void GetColumnDataType_Test_1()
        {
            var dt = new DataTable();
            dt.Columns.Add("Col_String", typeof(string));
            dt.Columns.Add("Col_Int", typeof(int));
            dt.Columns.Add("Col_Double", typeof(double));
            dt.Columns.Add("Col_Float", typeof(float));
            dt.Columns.Add("Col_Decimal", typeof(decimal));
            dt.Columns.Add("Col_Bool", typeof(bool));
            dt.Columns.Add("Col_DateTime", typeof(DateTime));


            Assert.AreEqual(dt.GetColumnDataType("Col_String"),typeof(string));
            Assert.AreEqual(dt.GetColumnDataType("col_string"),typeof(string));
            Assert.AreEqual(dt.GetColumnDataType("Col_Int"),typeof(int));
            Assert.AreEqual(dt.GetColumnDataType("Col_Double"),typeof(double));
            Assert.AreEqual(dt.GetColumnDataType("Col_Float"),typeof(float));
            Assert.AreEqual(dt.GetColumnDataType("Col_Decimal"),typeof(decimal));
            Assert.AreEqual(dt.GetColumnDataType("Col_Bool"),typeof(bool));
            Assert.AreEqual(dt.GetColumnDataType("Col_DateTime"),typeof(DateTime));

            Assert.ThrowsException<LettExtensionsDataTableException>(() => { dt.GetColumnDataType("not_Exist"); });
        }


        [TestMethod]
        public void GetColumnDataType_Test_2()
        {
            var dt = new DataTable();
            dt.Columns.Add("Col_String", typeof(string));
            dt.Columns.Add("Col_Int", typeof(int));
            dt.Columns.Add("Col_Double", typeof(double));
            dt.Columns.Add("Col_Float", typeof(float));
            dt.Columns.Add("Col_Decimal", typeof(decimal));
            dt.Columns.Add("Col_Bool", typeof(bool));
            dt.Columns.Add("Col_DateTime", typeof(DateTime));


            Assert.AreEqual(dt.GetColumnDataType(0),typeof(string));
            Assert.AreEqual(dt.GetColumnDataType(1),typeof(int));
            Assert.AreEqual(dt.GetColumnDataType(2),typeof(double));
            Assert.AreEqual(dt.GetColumnDataType(3),typeof(float));
            Assert.AreEqual(dt.GetColumnDataType(4),typeof(decimal));
            Assert.AreEqual(dt.GetColumnDataType(5),typeof(bool));
            Assert.AreEqual(dt.GetColumnDataType(6),typeof(DateTime));

            Assert.ThrowsException<LettExtensionsDataTableException>(() => { dt.GetColumnDataType(-1); });
            Assert.ThrowsException<LettExtensionsDataTableException>(() => { dt.GetColumnDataType(7); });
        }

    }
}