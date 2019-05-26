using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class DateTimeCompareTest
    {
        [TestMethod]
        public void ToStartOfDay_Test()
        {
            var dt            = new DateTime(2019, 4, 1);
            var startDateTime = new DateTime(2019, 4, 1, 1, 1, 1);
            var endDateTime   = new DateTime(2019, 4, 1);
            Assert.IsFalse(dt.IsBetween(startDateTime, endDateTime));
        }

        [TestMethod]
        public void IsToday_Test()
        {
            var dt = DateTime.Now;
            Assert.IsTrue(dt.IsToday());
            var dt2 = new DateTime(2019, 1, 1);
            Assert.IsFalse(dt2.IsToday());
        }

        [TestMethod]
        public void IsWeekDay_Test()
        {
            var dt = new DateTime(2019, 5, 4);
            Assert.IsFalse(dt.IsWeekDay());
            var dt2 = new DateTime(2019, 5, 1);
            Assert.IsTrue(dt2.IsWeekDay());
        }

        [TestMethod]
        public void IsZeroTime_Test()
        {
            var dt = new DateTime(2019, 5, 4, 1, 1, 1);
            Assert.IsFalse(dt.IsZeroTime());
            var dt2 = new DateTime(2019, 5, 4);
            Assert.IsTrue(dt2.IsZeroTime());
        }
        
    }
}