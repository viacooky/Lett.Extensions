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
            var arr = new[] {"aa", "bb"};
            Assert.IsFalse(arr.IsNullOrEmpty());
            var arr2 = new string[] { };
            Assert.IsTrue(arr2.IsNullOrEmpty());
            arr2 = null;
            Assert.IsTrue(arr2.IsNullOrEmpty());
        }

        [TestMethod]
        public void ContainsAny_Test()
        {
            var arr = new[] {"aa", "bb"};
            var match = new[] {"aa"};
            var match2 = new[] {"aa", "bb"};
            Assert.IsTrue(arr.ContainsAny(match));
            Assert.IsFalse(arr.ContainsAll(match));
            Assert.IsTrue(arr.ContainsAny(match2));
            Assert.IsTrue(arr.ContainsAll(match2));
        }
    }
}