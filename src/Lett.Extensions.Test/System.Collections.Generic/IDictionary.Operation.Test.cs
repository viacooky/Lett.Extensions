using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    // ReSharper disable once InconsistentNaming
    public class IDictionaryOperationTest
    {
        [TestMethod]
        public void AddOrUpdateTest()
        {
            var dict1 = new Dictionary<string, int> {{"a", 1}, {"b", 2}};
            dict1.AddOrUpdate("a", 3);
            dict1.AddOrUpdate("c", 3);
            Assert.AreEqual(3, dict1["a"]);
            Assert.AreEqual(3, dict1["c"]);

            var dict2 = new Dictionary<string, int> {{"a", 1}, {"b", 2}};
            dict2.AddOrUpdate(new KeyValuePair<string, int>("a", 3));
            dict2.AddOrUpdate(new KeyValuePair<string, int>("c", 3));
            Assert.AreEqual(3, dict2["a"]);
            Assert.AreEqual(3, dict2["c"]);

            var readOnlyDict = new ReadOnlyDictionary<string, int>(new Dictionary<string, int> {{"a", 1}, {"b", 2}});
            Assert.ThrowsException<NotSupportedException>(() => readOnlyDict.AddOrUpdate("a", 3));
            Assert.ThrowsException<NotSupportedException>(() => readOnlyDict.AddOrUpdate("c", 3));
            Assert.ThrowsException<ArgumentNullException>(() => readOnlyDict.AddOrUpdate(null, 3));
        }

        [TestMethod]
        public void GetOrUpdateTest()
        {
            var dict = new Dictionary<string, int> {{"a", 1}, {"b", 2}};
            var rs   = dict.GetOrUpdate("c", 3);
            Assert.AreEqual(3, rs);
            Assert.AreEqual(3, dict["c"]);

            var rs2 = dict.GetOrUpdate("a", 0);
            Assert.AreEqual(1, rs2);
            Assert.AreEqual(1, dict["a"]);

            var readOnlyDict = new ReadOnlyDictionary<string, int>(new Dictionary<string, int> {{"a", 1}, {"b", 2}});
            Assert.ThrowsException<NotSupportedException>(() => readOnlyDict.GetOrUpdate("c", 3));
            Assert.ThrowsException<ArgumentNullException>(() => readOnlyDict.AddOrUpdate(null, 3));
        }
    }
}