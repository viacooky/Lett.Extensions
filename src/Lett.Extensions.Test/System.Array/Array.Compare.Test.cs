using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class ArrayCompareTest
    {
        [TestMethod]
        public void ContainsIndex_Test()
        {
            var s = new[] {"aaa", "bbb"};
            Assert.IsTrue(s.ContainsIndex(0));
            Assert.IsTrue(s.ContainsIndex(1));
            Assert.IsFalse(s.ContainsIndex(2));
            Assert.IsFalse(s.ContainsIndex(-1));
        }
    }
}