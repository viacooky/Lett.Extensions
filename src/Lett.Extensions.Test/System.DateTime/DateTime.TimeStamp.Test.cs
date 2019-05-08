using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class DateTimeTimeStampTest
    {
        private readonly DateTime _testDateTime = new DateTime(2019, 4, 1, 11, 11, 11);

        [TestMethod]
        public void DateTimeTimeStamp_Test()
        {
            Assert.AreEqual(_testDateTime.GetTotalDays(), 17987.466099537036);
            Assert.AreEqual(_testDateTime.GetTotalHours(), 431699.18638888886);
            Assert.AreEqual(_testDateTime.GetTotalMinutes(), 25901951.183333334);
            Assert.AreEqual(_testDateTime.GetTotalSeconds(), 1554117071);
            Assert.AreEqual(_testDateTime.GetTotalMilliseconds(), 1554117071000);
        }
    }
}