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
            Assert.AreEqual(dt.ToString_Year(),"2019");
            Assert.AreEqual(dt.ToString_ShortYear(),"19");
            Assert.AreEqual(dt.ToString_Month(),"2019-04");
            Assert.AreEqual(dt.ToString_ShortMonth(),"19-4");
            Assert.AreEqual(dt.ToString_Day(),"2019-04-01");
            Assert.AreEqual(dt.ToString_ShortDay(),"19-4-1");
            Assert.AreEqual(dt.ToString_Time(), "21:11:11");
            Assert.AreEqual(dt.ToString_ShortTime(), "09:11:11 PM");
            Assert.AreEqual(dt.ToString_Base(),"2019-04-01 21:11:11");
            Assert.AreEqual(dt.ToString_Full(),"2019-04-01 21:11:11.1230000");
        }
    }
}