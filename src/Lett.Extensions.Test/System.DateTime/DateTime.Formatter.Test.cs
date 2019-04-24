using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class DateTimeFormatterTest
    {
        [TestMethod]
        public void DateTimeFormatter_Test()
        {
            var dt = new DateTime(2019, 4, 1, 21, 11, 11,123);
            Assert.AreEqual(dt.ToString_Year(),dt.ToString("yyyy"));
            Assert.AreEqual(dt.ToString_ShortYear(),dt.ToString("yy"));
            Assert.AreEqual(dt.ToString_Month(),dt.ToString("yyyy-MM"));
            Assert.AreEqual(dt.ToString_ShortMonth(),dt.ToString("yy-M"));
            Assert.AreEqual(dt.ToString_Day(),dt.ToString("yyyy-MM-dd"));
            Assert.AreEqual(dt.ToString_ShortDay(),dt.ToString("yy-M-d"));
            Assert.AreEqual(dt.ToString_Time(), dt.ToString("HH:mm:ss"));
            Assert.AreEqual(dt.ToString_ShortTime(), dt.ToString("hh:mm:ss tt"));
            Assert.AreEqual(dt.ToString_Base(),dt.ToString("yyyy-MM-dd HH:mm:ss"));
            Assert.AreEqual(dt.ToString_Full(),dt.ToString("yyyy-MM-dd HH:mm:ss.fffffff"));
        }
    }
}