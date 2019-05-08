using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class Int32CompareTest
    {
        [TestMethod]
        public void IsEven_Test()
        {
            Assert.IsTrue(0.IsEven());
            Assert.IsTrue(2.IsEven());
            Assert.IsFalse(1.IsEven());
            Assert.IsFalse((-1).IsEven());
        }

        [TestMethod]
        public void IsOdd_Test()
        {
            Assert.IsTrue(1.IsOdd());
            Assert.IsTrue((-1).IsOdd());
            Assert.IsFalse(2.IsOdd());
            Assert.IsFalse(0.IsOdd());
        }

        [TestMethod]
        public void IsInRange_Test()
        {
            Assert.IsTrue(10.IsInRange(0, 10));
            Assert.IsTrue(0.IsInRange(-1, 1));
            Assert.IsFalse(1.IsInRange(2, 3));
            Assert.IsFalse((-1).IsInRange(0, 10));
        }
    }
}