using System;
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

            var arr    = new[] {"aa", "bb"};
            var addArr = new[] {"cc"};
            Assert.ThrowsException<NotSupportedException>(() => arr.AddIfNotContains(addArr));
        }

        [TestMethod]
        public void AddIfNotContainsParams_Test()
        {
            var list = new List<string> {"aa", "bb"};
            list.AddIfNotContainsParams("cc", "aa");
            Assert.AreEqual(list.Count, 3);
            Assert.AreEqual(list[0], "aa");
            Assert.AreEqual(list[1], "bb");
            Assert.AreEqual(list[2], "cc");

            var arr = new[] {"aa", "bb"};
            Assert.ThrowsException<NotSupportedException>(() => arr.AddIfNotContainsParams("cc", "dd"));
        }

        [TestMethod]
        public void AddRange_Test()
        {
            var list       = new List<string> {"aa", "bb"};
            var appendList = new List<string> {"cc", "aa"};
            list.AddRange(appendList);
            Assert.AreEqual(list.Count, 4);
            Assert.AreEqual(list[0], "aa");
            Assert.AreEqual(list[1], "bb");
            Assert.AreEqual(list[2], "cc");
            Assert.AreEqual(list[3], "aa");

            var arr = new[] {"aa", "bb"};
            Assert.ThrowsException<NotSupportedException>(() => arr.AddRange(appendList));
        }

        [TestMethod]
        public void AddRangeParams_Test()
        {
            var list       = new List<string> {"aa", "bb"};
            list.AddRangeParams("cc", "aa");
            Assert.AreEqual(list.Count, 4);
            Assert.AreEqual(list[0], "aa");
            Assert.AreEqual(list[1], "bb");
            Assert.AreEqual(list[2], "cc");
            Assert.AreEqual(list[3], "aa");
            
            var arr = new[] {"aa", "bb"};
            Assert.ThrowsException<NotSupportedException>(() => arr.AddRangeParams("cc", "aa"));
        }
    }
}