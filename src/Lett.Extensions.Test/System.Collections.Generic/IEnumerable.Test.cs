using System.Threading;
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

        [TestMethod]
        public void ContainsAny_Test()
        {
            var testArr = new[] {"aa", "bb"};
            var match = new[] {"aa"};
            var match2 = new[] {"aa", "bb"};
            Assert.IsTrue(testArr.ContainsAny(match));
            Assert.IsFalse(testArr.ContainsAll(match));
            Assert.IsTrue(testArr.ContainsAny(match2));
            Assert.IsTrue(testArr.ContainsAll(match2));
        }
    }
}