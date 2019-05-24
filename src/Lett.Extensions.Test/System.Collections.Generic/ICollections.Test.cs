using System.Collections.Generic;
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
            var list = new List<string> {"aa", "bb"};
            list.AddIfNotContains("cc");
            list.AddIfNotContains("aa");
            Assert.AreEqual(list.Count, 3);
            Assert.AreEqual(list[0], "aa");
            Assert.AreEqual(list[1], "bb");
            Assert.AreEqual(list[2], "cc");
        }

        [TestMethod]
        public void AddIfNotContains_Test2()
        {
            var list       = new List<string> {"aa", "bb"};
            var appendList = new[] {"cc", "aa"};
            list.AddIfNotContains(appendList);
            Assert.AreEqual(list.Count, 3);
            Assert.AreEqual(list[0], "aa");
            Assert.AreEqual(list[1], "bb");
            Assert.AreEqual(list[2], "cc");
        }
    }
}