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
            var dict = new Dictionary<string, object>
            {
                {"1", "1"}, {"2", "2"}, {"3", "3"}, {"4", "4"},
            };
            var keys  = new[] {"6"};
            var keys2 = new List<string> {"1"};
            Assert.IsFalse(dict.ContainsKeyAny(keys));
            Assert.IsTrue(dict.ContainsKeyAny(keys2));

            Dictionary<string, object> dict2 = null;
            Assert.ThrowsException<ArgumentNullException>(() => dict2.ContainsKeyAny(keys));

            List<string> keys3 = null;
            Assert.ThrowsException<ArgumentNullException>(() => dict.ContainsKeyAny(keys3));
        }

        [TestMethod]
        public void ContainsKeyAll_Test()
        {
            var dict = new Dictionary<string, object>
            {
                {"1", "1"}, {"2", "2"}, {"3", "3"}, {"4", "4"},
            };
            var keys  = new[] {"6"};
            var keys2 = new List<string> {"1", "2", "3", "4"};
            Assert.IsFalse(dict.ContainsKeyAll(keys));
            Assert.IsTrue(dict.ContainsKeyAll(keys2));

            Dictionary<string, object> dict2 = null;
            Assert.ThrowsException<ArgumentNullException>(() => dict2.ContainsKeyAll(keys));

            List<string> keys3 = null;
            Assert.ThrowsException<ArgumentNullException>(() => dict.ContainsKeyAll(keys3));
        }
    }
}