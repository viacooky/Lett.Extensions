using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class DateTimeOperationTest
    {
        [TestMethod]
        public void RemoveTimePart_Test()
        {
            var dt = new DateTime(2019, 4, 1, 21, 11, 11, 123);
            dt = dt.RemoveTimePart();
            Assert.AreEqual(dt.Year,2019);
            Assert.AreEqual(dt.Month,4);
            Assert.AreEqual(dt.Day,1);
            Assert.AreEqual(dt.Hour,0);
            Assert.AreEqual(dt.Minute,0);
            Assert.AreEqual(dt.Second,0);
            Assert.AreEqual(dt.Millisecond,0);
        }
    }
}