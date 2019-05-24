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
            var dt = new DateTime(2019,4,1);
            var startDateTime =new DateTime(2019,4,1,1,1,1);
            var endDateTime =new DateTime(2019,4,1);
            Assert.IsFalse(dt.IsBetween(startDateTime, endDateTime));
        }

    }
}