using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class Int64CompareTest
    {
        [TestMethod]
        public void IsEven_Test()
        {
            Assert.IsTrue(0L.IsEven());
            Assert.IsTrue(2L.IsEven());
            Assert.IsFalse(1L.IsEven());
            Assert.IsFalse((-1L).IsEven());
        }
        
        [TestMethod]
        public void IsOdd_Test()
        {
            Assert.IsTrue(1L.IsOdd());
            Assert.IsTrue((-1L).IsOdd());
            Assert.IsFalse(2L.IsOdd());
            Assert.IsFalse(0L.IsOdd());
        }

        [TestMethod]
        public void IsInRange_Test()
        {
            Assert.IsTrue(10L.IsInRange(0,10));
            Assert.IsTrue(0L.IsInRange(-1,1));
            Assert.IsFalse(1L.IsInRange(2,3));
            Assert.IsFalse((-1L).IsInRange(0,10));
        }

    }
}