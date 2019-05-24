using System;
using System.Collections.Generic;
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
        public void In_Test()
        {
            var dtItems = new[]
            {
                new DateTime(2018, 1, 1),
                new DateTime(2019, 1, 1, 9, 10, 1),
                DateTime.Today
            };

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

            var dtItems = new[]
            {
                new DateTime(2018, 1, 1),
                new DateTime(2019, 1, 1, 9, 10, 1),
                DateTime.Today
            };

            var dt = new DateTime(2019, 5, 25, 1, 1, 1);
            Assert.IsTrue(dt.In(dtItems, new MyComparer()));
        }


        public class MyComparer : IEqualityComparer<DateTime>
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
    }
}