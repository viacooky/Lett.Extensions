using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class EnumerableTest
    {
        [TestMethod]
        public void IsNullOrEmpty_Test()
        {
            var testArr = new[] {"aa", "bb"};
            Assert.IsFalse(testArr.IsNullOrEmpty());
            var testArr2 = new string[] { };
            Assert.IsTrue(testArr2.IsNullOrEmpty());
            testArr2 = null;
            Assert.IsTrue(testArr2.IsNullOrEmpty());
        }
    }
}