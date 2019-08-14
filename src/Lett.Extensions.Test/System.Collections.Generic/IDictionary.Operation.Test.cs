using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    // ReSharper disable once InconsistentNaming
    public class IDictionaryOperationTest
    {
        [TestMethod]
        public void AddOrSetTest()
        {
            var dict1 = new Dictionary<string, int> {{"a", 1}, {"b", 2}};
            dict1.AddOrSet("a", 3);
            dict1.AddOrSet("c", 3);
            Assert.AreEqual(3, dict1["a"]);
            Assert.AreEqual(3, dict1["c"]);
            
            var dict2 = new Dictionary<string, int>{{"a",1},{"b",2}};
            dict2.AddOrSet(new KeyValuePair<string, int>("a",3));
            dict2.AddOrSet(new KeyValuePair<string, int>("c",3));
            Assert.AreEqual(3, dict2["a"]);
            Assert.AreEqual(3, dict2["c"]);
        }
    }
}