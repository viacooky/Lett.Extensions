using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class ObjectCompareTest
    {
        [TestMethod]
        public void IsDBNull_Test()
        {
            Assert.IsFalse("ddd".IsDBNull());
            Assert.IsTrue(DBNull.Value.IsDBNull());

            var value = DBNull.Value;
            Assert.IsTrue(value.IsDBNull());
        }

        [TestMethod]
        public void IsNullOrDBNull_Test()
        {
            Assert.IsFalse("".IsNullOrDbNull());
            Assert.IsTrue(DBNull.Value.IsNullOrDbNull());
            Assert.IsTrue(default(string).IsNullOrDbNull());
            var dt = new DataTable();
            dt.Columns.Add("row_1", typeof(DateTime));
            dt.Columns.Add("row_2", typeof(bool));
            dt.Rows.Add(DBNull.Value, null);
            dt.Rows.Add(null, DBNull.Value);

            Assert.IsTrue(dt.Rows[0]["row_1"].IsNullOrDbNull());
            Assert.IsTrue(dt.Rows[0]["row_2"].IsNullOrDbNull());
            Assert.IsTrue(dt.Rows[1]["row_1"].IsNullOrDbNull());
            Assert.IsTrue(dt.Rows[1]["row_2"].IsNullOrDbNull());

            var rs = GetTestUnitInfo(true);
            Assert.IsTrue(rs.IsNullOrDbNull());
            var rs2 = GetTestUnitInfo(false);
            Assert.IsFalse(rs2.IsNullOrDbNull());
            Assert.IsTrue(rs2?.UnitId.IsNullOrDbNull() ?? false);
            Assert.IsTrue(rs2?.UnitNumber.IsNullOrDbNull() ?? false);
            Assert.IsFalse(rs2?.UnitName.IsNullOrDbNull() ?? true);
        }

        private UnitInfo? GetTestUnitInfo(bool isNull = false)
        {
            if (isNull) return null;
            return new UnitInfo
            {
                UnitId     = DBNull.Value,
                UnitName   = DateTime.Now,
                UnitNumber = null,
            };
        }


        private struct UnitInfo
        {
            /// <summary>
            /// 单位ID
            /// </summary>
            public object UnitId;

            /// <summary>
            /// 单位代码
            /// </summary>
            public object UnitNumber;

            /// <summary>
            /// 单位名称
            /// </summary>
            public object UnitName;
        }

        [TestMethod]
        public void In_Test()
        {
            var dtItems = new[] {new DateTime(2018, 1, 1), new DateTime(2019, 1, 1, 9, 10, 1), DateTime.Today};

            var dt = new DateTime(2019, 5, 25, 1, 1, 1);
            Assert.IsFalse(dt.In(dtItems));
            var dt2 = DateTime.Today;
            Assert.IsTrue(dt2.In(dtItems));

            var intItems = new[] {1, 2, 33, -1};
            Assert.IsTrue(33.In(intItems));
            Assert.IsFalse(0.In(intItems));

            var    stringItems = new[] {"a", "b", null};
            var    s           = "a";
            string s2          = null;
            Assert.IsTrue(s.In(stringItems));
            Assert.IsTrue(s2.In(stringItems));


            string[] stringItems2 = null;
            var      s3           = "a";
            Assert.IsFalse(s3.In(stringItems2));

            var typeItems = new[] {typeof(string), typeof(int), typeof(decimal)};
            var t         = typeof(long);
            Assert.IsFalse(t.In(typeItems));
            var t2 = typeof(string);
            Assert.IsTrue(t2.In(typeItems));
        }

        [TestMethod]
        public void In_Test2()
        {
            var strItems = new[] {"a", "A", "b"};
            var s        = "B";
            Assert.IsTrue(s.In(strItems, StringComparer.CurrentCultureIgnoreCase));
            Assert.IsFalse(s.In(strItems, StringComparer.CurrentCulture));

            var dtItems = new[] {new DateTime(2018, 1, 1), new DateTime(2019, 1, 1, 9, 10, 1), DateTime.Today};

            var dt = new DateTime(2019, 5, 25, 1, 1, 1);
            Assert.IsTrue(dt.In(dtItems, new MyComparer()));
        }

        [TestMethod]
        public void InParams_Test()
        {
            var rs = "a".InParams("A", "a");
            Assert.IsTrue(rs);
            string s = null;
            rs = s.InParams("a");
            Assert.IsFalse(rs);
        }

        [TestMethod]
        public void InParams_Test2()
        {
            var rs = "a".InParams(StringComparer.CurrentCultureIgnoreCase, "A", "B");
            Assert.IsTrue(rs);
            rs = "a".InParams(StringComparer.Ordinal, "A", "B", null);
            Assert.IsFalse(rs);
            rs = "a".InParams(StringComparer.Ordinal, null, null);
            Assert.IsFalse(rs);
        }

        [TestMethod]
        public void IsClass_Test()
        {
            var obj1 = new MyClass();
            Assert.IsTrue(obj1.IsClass());

            var obj2 = 12;
            Assert.IsFalse(obj2.IsClass());

            var obj3 = 11L;
            Assert.IsFalse(obj3.IsClass());

            object obj4 = null;
            Assert.IsFalse(obj4.IsClass());
        }

        [TestMethod]
        public void IsArray_Test()
        {
            var obj1 = new[] {"1", "2"};
            Assert.IsTrue(obj1.IsArray());
            var obj2 = new List<string> {"1", "2"};
            Assert.IsFalse(obj2.IsArray());
            object obj3 = null;
            Assert.IsFalse(obj3.IsArray());
            var obj4 = new MyClass();
            Assert.IsFalse(obj4.IsArray());
        }

        [TestMethod]
        public void IsSerializable_Test()
        {
            var obj1 = new[] {"1", "2"};
            Assert.IsTrue(obj1.IsSerializable());
            var obj2 = new List<string> {"1", "2"};
            Assert.IsTrue(obj2.IsSerializable());
            object obj3 = null;
            Assert.IsFalse(obj3.IsSerializable());
            var obj4 = new MyClass();
            Assert.IsFalse(obj4.IsSerializable());
            var obj5 = new MySerializableClass();
            Assert.IsTrue(obj5.IsSerializable());
        }

        [TestMethod]
        public void IsEnum_Test()
        {
            var obj1 = MyEnum.None;
            Assert.IsTrue(obj1.IsEnum());

            var obj2 = 122;
            Assert.IsFalse(obj2.IsEnum());
        }

        [TestMethod]
        public void IsValueType_Test()
        {
            var obj1 = 12;
            Assert.IsTrue(obj1.IsValueType());
            var obj2 = "";
            Assert.IsFalse(obj2.IsValueType());
            var obj3 = new MyClass();
            Assert.IsFalse(obj3.IsValueType());
            var obj4 = new MyStruct();
            Assert.IsTrue(obj4.IsValueType());
            var obj5 = new DateTime();
            Assert.IsTrue(obj5.IsValueType());
        }

        [TestMethod]
        public void NotIn_Test1()
        {
            var dtItems = new[] {new DateTime(2018, 1, 1), new DateTime(2019, 1, 1, 9, 10, 1), DateTime.Today};
            var dt2     = DateTime.Today;
            Assert.IsFalse(dt2.NotIn(dtItems));

            var    stringItems = new[] {"a", "b", null};
            var    s           = "a";
            string s2          = null;
            Assert.IsFalse(s.NotIn(stringItems));
            Assert.IsFalse(s.NotIn(stringItems));

            string[] stringItems2 = null;
            var      s3           = "a";
            Assert.IsTrue(s3.NotIn(stringItems2));
        }

        [TestMethod]
        public void NotIn_Test2()
        {
            var dtItems = new[] {new DateTime(2018, 1, 1), new DateTime(2019, 1, 1, 9, 10, 1), DateTime.Today};
            var dt      = new DateTime(2019, 5, 25, 1, 1, 1);

            Assert.IsFalse(dt.NotIn(dtItems, new MyComparer()));
        }

        [TestMethod]
        public void NotInParams_Test1()
        {
            var rs = "a".NotInParams("A", "a");
            Assert.IsFalse(rs);
        }

        [TestMethod]
        public void NotInParams_Test2()
        {
            var rs1 = "a".NotInParams(StringComparer.CurrentCultureIgnoreCase, "A", "B");
            var rs2 = "a".NotInParams(StringComparer.Ordinal, "A", "B");
            var rs3 = "a".NotInParams(StringComparer.Ordinal, null);
            Assert.IsFalse(rs1);
            Assert.IsTrue(rs2);
            Assert.IsTrue(rs3);
        }

        private class MyComparer : IEqualityComparer<DateTime>
        {
            public bool Equals(DateTime x, DateTime y)
            {
                return x.Year.Equals(y.Year);
            }

            public int GetHashCode(DateTime obj)
            {
                return obj.GetHashCode();
            }
        }

        private class MyClass
        {
            public string Name { get; set; }
        }

        [Serializable]
        private class MySerializableClass
        {
            public string Name { get; set; }
        }

        private enum MyEnum
        {
            None
        }

        private struct MyStruct
        {
            public string Name { get; set; }
        }
    }
}