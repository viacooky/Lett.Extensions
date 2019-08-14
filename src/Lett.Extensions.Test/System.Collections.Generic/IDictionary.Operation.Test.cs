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
        public void AddOrUpdateRange_Test()
        {
            var dict1    = new Dictionary<string, int> {{"a", 1}, {"b", 2}};
            var sameDict = new Dictionary<string, int> {{"a", 3}, {"b", 4}, {"c", 5}};
            dict1.AddOrUpdateRange(sameDict);
            Assert.AreEqual(3, dict1.Count);
            Assert.AreEqual(3, dict1["a"]);
            Assert.AreEqual(4, dict1["b"]);
            Assert.AreEqual(5, dict1["c"]);
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

        [TestMethod]
        public void AddRange_Test()
        {
            var dict     = new Dictionary<string, int> {{"a", 1}, {"b", 2}};
            var sameDict = new Dictionary<string, int> {{"a", 1}, {"b", 2}};
            Assert.ThrowsException<ArgumentException>(() => dict.AddRange(sameDict));

            var appendDict = new Dictionary<string, int> {{"c", 3}, {"d", 4}};
            dict.AddRange(appendDict);
            Assert.AreEqual(4, dict.Count);
            Assert.AreEqual(1, dict["a"]);
            Assert.AreEqual(2, dict["b"]);
            Assert.AreEqual(3, dict["c"]);
            Assert.AreEqual(4, dict["d"]);
        }

        [TestMethod]
        public void AddRangeParams_Test()
        {
            var dict = new Dictionary<string, int> {{"a", 1}, {"b", 2}};
            dict.AddRangeParams(new KeyValuePair<string, int>("c", 3), new KeyValuePair<string, int>("d", 4));
            Assert.AreEqual(4, dict.Count);
            Assert.AreEqual(1, dict["a"]);
            Assert.AreEqual(2, dict["b"]);
            Assert.AreEqual(3, dict["c"]);
            Assert.AreEqual(4, dict["d"]);

            Assert.ThrowsException<ArgumentException>(() => dict.AddRangeParams(new KeyValuePair<string, int>("c", 3), new KeyValuePair<string, int>("d", 4)));
        }
    }
}