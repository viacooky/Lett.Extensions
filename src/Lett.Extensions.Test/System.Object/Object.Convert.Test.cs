using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class ObjectConvertTest
    {
        [TestMethod]
        public void To_Test()
        {
            // valueType
            // int to string
            var intVar = 11;
            Assert.AreEqual(intVar.To<string>(), "11");
            // string to int
            Assert.AreEqual("11".To<int>(), 11);

            var dateTimeStr = "2018-01-01 23:59:59";
            Assert.AreEqual(dateTimeStr.To<DateTime>(), new DateTime(2018, 1, 1, 23, 59, 59));
        }

        [TestMethod]
        public void To_Test2()
        {
            var dateTimeStr = "2018-01-01 23:59:59xxxxxxxx"; // will be fail
            var expected    = new DateTime(2019, 4, 1);
            Assert.AreEqual(expected, dateTimeStr.To(() => new DateTime(2019, 4, 1)));
        }

        [TestMethod]
        public void To_Test3()
        {
            var dateTimeStr = "2018-01-01 23:59:59xxxxxxxx"; // will be fail
            var expected    = new DateTime(2019, 4, 1);
            Assert.AreEqual(expected, dateTimeStr.To(new DateTime(2019, 4, 1)));
        }

        [TestMethod]
        public void DeepClone_Test()
        {
            var obj = new MyClass {Name = "aa"};
            var rs  = obj.DeepClone();
            Assert.AreNotEqual(obj.GetHashCode(), rs.GetHashCode());
            Assert.AreEqual(obj.Name, rs.Name);
        }

        [Serializable]
        private class MyClass
        {
            public string Name { get; set; }
        }
    }
}