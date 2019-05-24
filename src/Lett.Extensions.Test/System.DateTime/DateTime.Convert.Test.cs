using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class DateTimeConvertTest
    {
        [TestMethod]
        public void ToStartOfDay_Test()
        {
            var dt = new DateTime(2019, 4, 1, 21, 11, 11, 123);
            var rs = dt.StartOfDay();
            Assert.AreEqual(rs.Year, 2019);
            Assert.AreEqual(rs.Month, 4);
            Assert.AreEqual(rs.Day, 1);
            Assert.AreEqual(rs.Hour, 0);
            Assert.AreEqual(rs.Minute, 0);
            Assert.AreEqual(rs.Second, 0);
            Assert.AreEqual(rs.Millisecond, 0);
        }

        [TestMethod]
        public void ToEndOfDay_Test()
        {
            var dt = new DateTime(2019, 4, 1, 1, 2, 3);
            var rs = dt.EndOfDay();
            Assert.AreEqual(rs.Year, 2019);
            Assert.AreEqual(rs.Month, 4);
            Assert.AreEqual(rs.Day, 1);
            Assert.AreEqual(rs.Hour, 23);
            Assert.AreEqual(rs.Minute, 59);
            Assert.AreEqual(rs.Second, 59);
            Assert.AreEqual(rs.Millisecond, 999);
        }

        [TestMethod]
        public void SetTime_Test()
        {
            var dt = new DateTime(2019, 4, 1, 1, 2, 3);
            var rs = dt.SetTime(0, 0, 0);
            Assert.AreEqual(rs.Year, 2019);
            Assert.AreEqual(rs.Month, 4);
            Assert.AreEqual(rs.Day, 1);
            Assert.AreEqual(rs.Hour, 0);
            Assert.AreEqual(rs.Minute, 0);
            Assert.AreEqual(rs.Second, 0);
            Assert.AreEqual(rs.Millisecond, 0);

            var dt2 = new DateTime(2019, 4, 1, 1, 2, 3);
            var rs2 = dt2.SetTime(23, 11, 11, 999);
            Assert.AreEqual(rs2.Year, 2019);
            Assert.AreEqual(rs2.Month, 4);
            Assert.AreEqual(rs2.Day, 1);
            Assert.AreEqual(rs2.Hour, 23);
            Assert.AreEqual(rs2.Minute, 11);
            Assert.AreEqual(rs2.Second, 11);
            Assert.AreEqual(rs2.Millisecond, 999);

            var dt3 = new DateTime(2019, 4, 1, 1, 2, 3);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => dt3.SetTime(44, 23, 23));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => dt3.SetTime(-1, 23, 23));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => dt3.SetTime(23, 23, 23, 9999));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => dt3.SetTime(23, 23, 23, -999));
        }

        [TestMethod]
        public void StartOfWeek_Test()
        {
            var dt = new DateTime(2019, 4, 1, 1, 2, 3);
            var rs = dt.StartOfWeek(DayOfWeek.Sunday); // 2019-03-31 00:00:00
            Assert.AreEqual(rs.Year, 2019);
            Assert.AreEqual(rs.Month, 3);
            Assert.AreEqual(rs.Day, 31);
            Assert.AreEqual(rs.Hour, 0);
            Assert.AreEqual(rs.Minute, 0);
            Assert.AreEqual(rs.Second, 0);
            Assert.AreEqual(rs.Millisecond, 0);

            var dt2 = new DateTime(2019, 4, 1, 1, 2, 3);
            var rs2 = dt2.StartOfWeek(DayOfWeek.Friday); // 2019-03-29
            Assert.AreEqual(rs2.Year, 2019);
            Assert.AreEqual(rs2.Month, 3);
            Assert.AreEqual(rs2.Day, 29);
            Assert.AreEqual(rs2.Hour, 0);
            Assert.AreEqual(rs2.Minute, 0);
            Assert.AreEqual(rs2.Second, 0);
            Assert.AreEqual(rs2.Millisecond, 0);
        }

        [TestMethod]
        public void EndOfWeek_Test()
        {
            var dt = new DateTime(2019, 4, 1, 1, 2, 3);
            var rs = dt.EndOfWeek(DayOfWeek.Sunday); // 2019-04-06 23:59:59.999
            Assert.AreEqual(rs.Year, 2019);
            Assert.AreEqual(rs.Month, 4);
            Assert.AreEqual(rs.Day, 6);
            Assert.AreEqual(rs.Hour, 23);
            Assert.AreEqual(rs.Minute, 59);
            Assert.AreEqual(rs.Second, 59);
            Assert.AreEqual(rs.Millisecond, 999);

            var dt2 = new DateTime(2019, 4, 1, 1, 2, 3);
            var rs2 = dt.EndOfWeek(DayOfWeek.Friday); // 2019-04-04 23:59:59.999
            Assert.AreEqual(rs2.Year, 2019);
            Assert.AreEqual(rs2.Month, 4);
            Assert.AreEqual(rs2.Day, 4);
            Assert.AreEqual(rs2.Hour, 23);
            Assert.AreEqual(rs2.Minute, 59);
            Assert.AreEqual(rs2.Second, 59);
            Assert.AreEqual(rs2.Millisecond, 999);
        }

        [TestMethod]
        public void StartOfMonth_Test()
        {
            var dt = new DateTime(2019, 4, 12, 1, 2, 3);
            var rs = dt.StartOfMonth();
            Assert.AreEqual(rs.Year, 2019);
            Assert.AreEqual(rs.Month, 4);
            Assert.AreEqual(rs.Day, 1);
            Assert.AreEqual(rs.Hour,0);
            Assert.AreEqual(rs.Minute,0);
            Assert.AreEqual(rs.Second,0);
            Assert.AreEqual(rs.Millisecond,0);
        }

        [TestMethod]
        public void EndOfMonth_Test()
        {
            var dt = new DateTime(2019, 4, 12, 1, 2, 3);
            var rs = dt.EndOfMonth();
            Assert.AreEqual(rs.Year, 2019);
            Assert.AreEqual(rs.Month, 4);
            Assert.AreEqual(rs.Day, 30);
            Assert.AreEqual(rs.Hour,23);
            Assert.AreEqual(rs.Minute,59);
            Assert.AreEqual(rs.Second,59);
            Assert.AreEqual(rs.Millisecond,999);
        }

        [TestMethod]
        public void StartOfYear_Test()
        {
            var dt = new DateTime(2019, 4, 12, 1, 2, 3);
            var rs = dt.StartOfYear();
            Assert.AreEqual(rs.Year, 2019);
            Assert.AreEqual(rs.Month, 1);
            Assert.AreEqual(rs.Day, 1);
            Assert.AreEqual(rs.Hour,0);
            Assert.AreEqual(rs.Minute,0);
            Assert.AreEqual(rs.Second,0);
            Assert.AreEqual(rs.Millisecond,000);
        }

        [TestMethod]
        public void EndOfYear_Test()
        {
            var dt = new DateTime(2019, 4, 12, 1, 2, 3);
            var rs = dt.EndOfYear();
            Assert.AreEqual(rs.Year, 2019);
            Assert.AreEqual(rs.Month, 12);
            Assert.AreEqual(rs.Day, 31);
            Assert.AreEqual(rs.Hour,23);
            Assert.AreEqual(rs.Minute,59);
            Assert.AreEqual(rs.Second,59);
            Assert.AreEqual(rs.Millisecond,999);
        }
    }
}