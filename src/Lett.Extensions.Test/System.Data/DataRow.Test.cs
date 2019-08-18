using System;
using System.Data;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class DataRowTest
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
        public void Cell_Test()
        {
            _testTable1.Rows.Clear();
            Enumerable.Range(0, 10).ToList().ForEach(index => { _testTable1.Rows.Add($"RowId_{index}", $"Name_{index}"); });

            var firstRow = _testTable1.RowsEnumerable().FirstOrDefault();
            // 存在的列
            Assert.AreEqual(firstRow.Cell<string>("FRowId").GetType(), typeof(string));
            Assert.AreNotEqual(firstRow.Cell<string>("FRowId"), default);
            // 不存在的列
            Assert.AreEqual(firstRow.Cell<string>("NotExistColumn"), default);
            // 不存在的列 , 默认值
            Assert.AreEqual(firstRow.Cell("NotExistColumn", "abc"), "abc");
            // 不存在的列 , 默认值 委托
            Assert.AreEqual(firstRow.Cell("NotExistColumn", () => "func return value"), "func return value");
        }

        [TestMethod]
        public void Cell_Test2()
        {
            _testTable1.Columns.Add("FLongCol", typeof(long));
            _testTable1.Rows.Clear();
            10.Times(index => _testTable1.Rows.Add($"RowId_{index}", $"Name_{index}", Convert.ToInt16(index)));
            var a = _testTable1.FirstRow().Cell<string>("FLongCol");
            Assert.AreEqual("0", a);
        }

        [TestMethod]
        public void ToEntity_Test()
        {
            var dt = new DataTable();
            dt.Columns.AddRange(new[] {"PublicField1", "Property1", "AutoProperty1", "notExistField"});
            dt.Rows.Add("publicFieldValue", "PropertyValue", "AutoProperty1Value", "notExistFieldValue");

            var rs = dt.Rows[0].ToEntity<TestClass1>();
            Assert.AreEqual(rs.PublicField1, "publicFieldValue");
            Assert.AreEqual(rs.Property1, "PropertyValue");
            Assert.AreEqual(rs.AutoProperty1, "AutoProperty1Value");
        }

        [TestMethod]
        public void ToEntity_Test2()
        {
            var dt = new DataTable();

            dt.Columns.AddRange(new[] {"PublicField1", "Property1", "AutoProperty1", "notExistField"});
            dt.Rows.Add("publicFieldValue", "PropertyValue", "AutoProperty1Value", "notExistFieldValue");
            var rs = dt.Rows[0].ToEntity<TestClass1>((row, newClass) =>
            {
                newClass.Property1    = row.Cell<string>("Property1");
                newClass.PublicField1 = row.Cell<string>("PublicField1");
                return newClass;
            });
            Assert.AreEqual(rs.Property1, "PropertyValue");
            Assert.AreEqual(rs.PublicField1, "publicFieldValue");
            Assert.AreEqual(rs.AutoProperty1, null);
        }

        [TestMethod]
        public void ToDynamicObject_Test()
        {
            var dt = new DataTable();
            dt.Columns.Add("col1", typeof(string));
            dt.Columns.Add("col2", typeof(DateTime));
            dt.Columns.Add("col3", typeof(decimal));
            dt.Columns.Add("col4", typeof(string));
            dt.Columns.Add("col5", typeof(string));
            dt.Rows.Add("strVal", new DateTime(2019, 4, 1), 100.23m, DBNull.Value, null);

            var rs = dt.Rows[0].ToDynamicObject();
            Assert.AreEqual(rs.col1, "strVal");
            Assert.AreEqual(rs.col2, new DateTime(2019, 4, 1));
            Assert.AreEqual(rs.col3, 100.23m);
            Assert.IsNull(rs.col4);
            Assert.IsNull(rs.col5);
        }

        [TestMethod]
        public void HasColumn_Test()
        {
            _testTable1.Rows.Clear();
            10.Times(index => _testTable1.Rows.Add($"RowId_{index}", $"Name_{index}"));
            var row = _testTable1.FirstRow();
            Assert.IsTrue(row.HasColumn("FRowId"));
            Assert.IsFalse(row.HasColumn("FDDDD"));
        }

        [TestMethod]
        public void Set_Test()
        {
            _testTable1.Columns.Add("FBoolCol", typeof(bool));
            _testTable1.Columns.Add("FGuidCol", typeof(Guid));

            _testTable1.Rows.Clear();
            10.Times(index => _testTable1.Rows.Add($"RowId_{index}", $"Name_{index}"));
            var row = _testTable1.Rows[0];
            row.SetValue("FBoolCol", "true2");
            Assert.AreEqual(DBNull.Value, row["FBoolCol"]);
            Assert.ThrowsException<ArgumentException>(() => row.SetValue("FBoolCol", "dsadfk", false));


            var row2 = _testTable1.Rows[1];
            var guid = Guid.NewGuid();
            row2.SetValue("FGuidCol", guid);
            Assert.AreEqual(guid, row2["FGuidCol"]);

            var row3 = _testTable1.Rows[2];
            var s    = Guid.NewGuid().ToString();
            row3.SetValue("FGuidCol", s);
            Assert.AreEqual(Guid.Parse(s), row3["FGuidCol"]);
        }

        private class TestClass1
        {
            public string PublicField1;

            public string Property1 { get; set; }

            public string AutoProperty1 { get; set; }
        }
    }
}