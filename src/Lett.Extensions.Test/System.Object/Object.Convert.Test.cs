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
            Assert.AreEqual(11.To<string>(), "11");
            // string to int
            Assert.AreEqual("11".To<int>(), 11);

            Assert.AreEqual("2018-01-01 23:59:59".To<DateTime>(), new DateTime(2018, 1, 1, 23, 59, 59));
        }
    }
}