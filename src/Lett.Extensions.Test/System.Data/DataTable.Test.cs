﻿using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
            Assert.ThrowsException<ArgumentException>(() => _testTable1.FirstRow());
            Assert.ThrowsException<ArgumentException>(() => _testTable1.LastRow());
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
            Assert.AreEqual(_testTable1.Columns.Count, _testTable1.ColumnsEnumerable().Count());
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


            Assert.AreEqual(dt.GetColumnDataType("Col_String"), typeof(string));
            Assert.AreEqual(dt.GetColumnDataType("col_string"), typeof(string));
            Assert.AreEqual(dt.GetColumnDataType("Col_Int"), typeof(int));
            Assert.AreEqual(dt.GetColumnDataType("Col_Double"), typeof(double));
            Assert.AreEqual(dt.GetColumnDataType("Col_Float"), typeof(float));
            Assert.AreEqual(dt.GetColumnDataType("Col_Decimal"), typeof(decimal));
            Assert.AreEqual(dt.GetColumnDataType("Col_Bool"), typeof(bool));
            Assert.AreEqual(dt.GetColumnDataType("Col_DateTime"), typeof(DateTime));

            Assert.ThrowsException<ArgumentException>(() => { dt.GetColumnDataType("not_Exist"); });
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


            Assert.AreEqual(dt.GetColumnDataType(0), typeof(string));
            Assert.AreEqual(dt.GetColumnDataType(1), typeof(int));
            Assert.AreEqual(dt.GetColumnDataType(2), typeof(double));
            Assert.AreEqual(dt.GetColumnDataType(3), typeof(float));
            Assert.AreEqual(dt.GetColumnDataType(4), typeof(decimal));
            Assert.AreEqual(dt.GetColumnDataType(5), typeof(bool));
            Assert.AreEqual(dt.GetColumnDataType(6), typeof(DateTime));

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { dt.GetColumnDataType(-1); });
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { dt.GetColumnDataType(7); });
        }


        [TestMethod]
        public void ToEntityList_Test()
        {
            var dt = new DataTable();
            dt.Columns.AddRange(new[] {"PublicField", "Property", "AutoProperty", "notExistField"});
            dt.Rows.Add("publicFieldValue1", "PropertyValue1", "AutoPropertyValue1", "notExistFieldValue1");
            dt.Rows.Add("publicFieldValue2", "PropertyValue2", "AutoPropertyValue2", "notExistFieldValue2");
            dt.Rows.Add("publicFieldValue3", "PropertyValue3", "AutoPropertyValue3", "notExistFieldValue3");

            var rs = dt.ToEntityList<TestClass1>();
            Assert.AreEqual(rs.Count, 3);
            Assert.AreEqual(rs[0].PublicField, "publicFieldValue1");
            Assert.AreEqual(rs[0].AutoProperty, "AutoPropertyValue1");
            Assert.AreEqual(rs[0].Property, "PropertyValue1");
            Assert.AreEqual(rs[1].PublicField, "publicFieldValue2");
            Assert.AreEqual(rs[1].AutoProperty, "AutoPropertyValue2");
            Assert.AreEqual(rs[1].Property, "PropertyValue2");
            Assert.AreEqual(rs[2].PublicField, "publicFieldValue3");
            Assert.AreEqual(rs[2].AutoProperty, "AutoPropertyValue3");
            Assert.AreEqual(rs[2].Property, "PropertyValue3");
        }


        [TestMethod]
        public void ToEntityList_10K_Rows_Test()
        {
            // 10K 
            var dt = new DataTable();
            dt.Columns.AddRange(new[] {"PublicField", "Property", "AutoProperty", "notExistField"});
            var i     = 0;
            var count = 10000;
            while (i < count)
            {
                dt.Rows.Add($"publicFieldValue_{i}", $"PropertyValue_{i}", $"AutoPropertyValue_{i}", $"notExistFieldValue_{i}");
                i++;
            }

            var startTime = DateTime.Now;
            dt.ToEntityList<TestClass1>();
            var usedMilliseconds = (DateTime.Now - startTime).TotalMilliseconds;
            Console.WriteLine($"10K Rows used time: {usedMilliseconds} ms");
        }

        [TestMethod]
        public void ToEntityList_100K_Rows_Test()
        {
            // 100K 
            var dt = new DataTable();
            dt.Columns.AddRange(new[] {"PublicField", "Property", "AutoProperty", "notExistField"});
            var i     = 0;
            var count = 100000;
            while (i < count)
            {
                dt.Rows.Add($"publicFieldValue_{i}", $"PropertyValue_{i}", $"AutoPropertyValue_{i}", $"notExistFieldValue_{i}");
                i++;
            }

            var startTime = DateTime.Now;
            dt.ToEntityList<TestClass1>();
            var usedMilliseconds = (DateTime.Now - startTime).TotalMilliseconds;
            Console.WriteLine($"100K Rows used time: {usedMilliseconds} ms");
        }

        [TestMethod]
        public void ToEntityList_Test2()
        {
            var dt = new DataTable();
            dt.Columns.AddRange(new[] {"PublicField", "Property", "AutoProperty", "notExistField"});
            dt.Rows.Add("publicFieldValue1", "PropertyValue1", "AutoPropertyValue1", "notExistFieldValue1");
            dt.Rows.Add("publicFieldValue2", "PropertyValue2", "AutoPropertyValue2", "notExistFieldValue2");
            dt.Rows.Add("publicFieldValue3", "PropertyValue3", "AutoPropertyValue3", "notExistFieldValue3");

            var rs = dt.ToEntityList<TestClass1>((row, newObj) =>
            {
                newObj.PublicField = row.Cell<string>("PublicField");
                return newObj;
            });
            Assert.AreEqual(rs.Count, 3);
            Assert.AreEqual(rs[0].PublicField, "publicFieldValue1");
            Assert.AreEqual(rs[1].PublicField, "publicFieldValue2");
            Assert.AreEqual(rs[2].PublicField, "publicFieldValue3");
            Assert.AreEqual(rs[0].Property, null);
        }


        [TestMethod]
        public void ToDynamicObjects_Test()
        {
            var dt = new DataTable();
            dt.Columns.Add("col1", typeof(string));
            dt.Columns.Add("col2", typeof(DateTime));
            dt.Columns.Add("col3", typeof(decimal));
            dt.Columns.Add("col4", typeof(string));
            dt.Columns.Add("col5", typeof(string));
            dt.Rows.Add("strVal", new DateTime(2019, 4, 1), 100.23m, DBNull.Value, null);
            dt.Rows.Add("strVal2", new DateTime(2019, 4, 2), 122.23m, DBNull.Value, null);

            var rs = dt.ToDynamicObjects().ToList();
            Assert.AreEqual(rs[0].col1, "strVal");
            Assert.AreEqual(rs[0].col2, new DateTime(2019, 4, 1));
            Assert.AreEqual(rs[1].col3, 122.23m);
            Assert.IsNull(rs[1].col4);
            Assert.IsNull(rs[1].col5);
        }


        [TestMethod]
        public void Update_Test1()
        {
            _testTable1.Rows.Clear();
            10.Times(index => _testTable1.Rows.Add($"RowId_{index}", $"Name_{index}"));
            _testTable1.Update("FName", "a");
            Assert.AreEqual("a", _testTable1.Rows[0]["FName"]);
            Assert.AreEqual("a", _testTable1.Rows[2]["FName"]);
            Assert.AreEqual("a", _testTable1.Rows[9]["FName"]);
        }

        [TestMethod]
        public void Update_Test2()
        {
            _testTable1.Rows.Clear();
            10.Times(index => _testTable1.Rows.Add($"RowId_{index}", $"Name_{index}"));
            _testTable1.Update("FName", "a");
            Assert.AreEqual("a", _testTable1.Rows[0]["FName"]);
            Assert.AreEqual("a", _testTable1.Rows[2]["FName"]);
            Assert.AreEqual("a", _testTable1.Rows[9]["FName"]);

            _testTable1.Rows.Clear();
            _testTable1.Columns.Add("FInt_Col", typeof(int));
            10.Times(index => _testTable1.Rows.Add($"RowId_{index}", $"Name_{index}", index));
            _testTable1.Update("FInt_Col", "a");
            Assert.AreEqual(DBNull.Value, _testTable1.Rows[0]["FInt_Col"]);
            Assert.AreEqual(DBNull.Value, _testTable1.Rows[2]["FInt_Col"]);
            Assert.AreEqual(DBNull.Value, _testTable1.Rows[9]["FInt_Col"]);

            _testTable1.Update(row => row["FRowId"].ToString().Equals("RowId_3"),
                               "FInt_Col", "a");
            Assert.AreEqual(DBNull.Value, _testTable1.Rows[3]["FInt_Col"]);
        }

        [TestMethod]
        public void Update_Test3()
        {
            _testTable1.Rows.Clear();
            10.Times(index => _testTable1.Rows.Add($"RowId_{index}", $"Name_{index}"));

            _testTable1.Update(row => true, "FName", (i, row) => $"{i}_{row["FRowId"]}");
            Assert.AreEqual("3_RowId_3", _testTable1.Rows[3]["FName"].ToString());

            _testTable1.Rows.Clear();
            10.Times(index => _testTable1.Rows.Add($"RowId_{index}", $"Name_{index}"));

            _testTable1.Update(row => true, "FName", (i,row) => $"{row["FRowId"]}");
            Assert.AreEqual("RowId_3", _testTable1.Rows[3]["FName"].ToString());
        }


        #region 测试类 

#pragma warning disable 649
        [SuppressMessage("ReSharper", "ConvertToAutoProperty")]
        [SuppressMessage("ReSharper", "ArrangeAccessorOwnerBody")]
        [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
        private class TestClass1
        {
            private string _field;
            public  string PublicField;

            public string Property
            {
                get { return _field; }
                // ReSharper disable once UnusedMember.Local
                set { _field = value; }
            }

            public string AutoProperty { get; set; }
        }
#pragma warning restore 649

        #endregion
    }
}