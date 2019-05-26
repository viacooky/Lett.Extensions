using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    // ReSharper disable once InconsistentNaming
    public class IDictionaryTest
    {
        [TestMethod]
        public void ContainsKeyAny_Test()
        {
            var dict  = new Dictionary<string, object> {{"1", "1"}, {"2", "2"}, {"3", "3"}, {"4", "4"}};
            var keys  = new[] {"6"};
            var keys2 = new List<string> {"1"};
            Assert.IsFalse(dict.ContainsKeyAnyParams(keys));
            Assert.IsTrue(dict.ContainsKeyAny(keys2));

            Dictionary<string, object> dict2 = null;
            Assert.ThrowsException<ArgumentNullException>(() => dict2.ContainsKeyAnyParams(keys));

            List<string> keys3 = null;
            Assert.ThrowsException<ArgumentNullException>(() => dict.ContainsKeyAny(keys3));

            Assert.ThrowsException<ArgumentNullException>(() => dict.ContainsKeyAnyParams(null));

            Assert.IsTrue(dict.ContainsKeyAnyParams("1", "2"));
        }

        [TestMethod]
        public void ContainsKeyAll_Test()
        {
            var dict  = new Dictionary<string, object> {{"1", "1"}, {"2", "2"}, {"3", "3"}, {"4", "4"}};
            var keys  = new[] {"6"};
            var keys2 = new List<string> {"1", "2", "3", "4"};
            Assert.IsFalse(dict.ContainsKeyAllParams(keys));
            Assert.IsTrue(dict.ContainsKeyAll(keys2));

            Dictionary<string, object> dict2 = null;
            Assert.ThrowsException<ArgumentNullException>(() => dict2.ContainsKeyAllParams(keys));

            List<string> keys3 = null;
            Assert.ThrowsException<ArgumentNullException>(() => dict.ContainsKeyAll(keys3));

            Assert.ThrowsException<ArgumentNullException>(() => dict.ContainsKeyAllParams(null));

            Assert.IsTrue(dict.ContainsKeyAllParams("1", "2", "3", "4"));
        }

        [TestMethod]
        public void ContainsValueAny_Test()
        {
            var dict    = new Dictionary<string, object> {{"Key1", "1Value"}, {"Key2", "2Value"}, {"Key3", "3Value"}, {"Key4", "4Value"}};
            var values  = new List<string> {"1Value"};
            var values2 = new List<string> {"6666Value"};

            Dictionary<string, object> dict2 = null;

            Assert.IsTrue(dict.ContainsValueAny(values));
            Assert.IsFalse(dict.ContainsValueAny(values2));
            Assert.IsTrue(dict.ContainsValueAnyParams("1Value"));

            Assert.ThrowsException<ArgumentNullException>(() => dict2.ContainsKeyAll(values));
            Assert.ThrowsException<ArgumentNullException>(() => dict.ContainsKeyAllParams(null));
        }

        [TestMethod]
        public void ContainsValueAll_Test()
        {
            var dict   = new Dictionary<string, object> {{"Key1", "1Value"}, {"Key2", "2Value"}, {"Key3", "3Value"}, {"Key4", "4Value"}};
            var values = new List<string> {"1Value", "2Value", "3Value", "4Value"};
            var values2 = new List<string>
            {
                "1Value",
                "2Value",
                "3Value",
                "4Value",
                "6666Value"
            };

            Dictionary<string, object> dict2 = null;

            Assert.IsTrue(dict.ContainsValueAll(values));
            Assert.IsFalse(dict.ContainsValueAll(values2));
            Assert.IsTrue(dict.ContainsValueAllParams("1Value", "2Value", "3Value", "4Value"));
            Assert.IsFalse(dict.ContainsValueAllParams("1Value", "2Value", "3Value", "4Value", "6666Value"));

            Assert.ThrowsException<ArgumentNullException>(() => dict2.ContainsValueAll(values));
            Assert.ThrowsException<ArgumentNullException>(() => dict.ContainsValueAllParams(null));
        }
    }
}