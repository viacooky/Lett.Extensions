using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    // ReSharper disable once InconsistentNaming
    public class ICollectionsTest
    {
        [TestMethod]
        public void AddIfNotContains_Test1()
        {
            var testList = new[] {"aa", "bb"}.ToList();
            testList.AddIfNotContains("cc");
            testList.AddIfNotContains("aa");
            Assert.AreEqual(testList.Count, 3);
            Assert.AreEqual(testList[0], "aa");
            Assert.AreEqual(testList[1], "bb");
            Assert.AreEqual(testList[2], "cc");
        }

        [TestMethod]
        public void AddIfNotContains_Test2()
        {
            var testList = new[] {"aa", "bb"}.ToList();
            var appList  = new[] {"cc", "aa"};
            testList.AddIfNotContains(appList);
            Assert.AreEqual(testList.Count, 3);
            Assert.AreEqual(testList[0], "aa");
            Assert.AreEqual(testList[1], "bb");
            Assert.AreEqual(testList[2], "cc");
        }
    }
}