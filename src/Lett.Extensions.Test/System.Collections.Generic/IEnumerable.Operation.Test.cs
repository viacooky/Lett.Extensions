using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class EnumerableOperationTest
    {
        [TestMethod]
        public void BuildString_Test()
        {
            var input = new List<string> {"aa", "bb", "cc", "dd"};
            var rs    = input.ToFormatString("[{0}]", s => new object[] {s});
            Assert.AreEqual(rs, "[aa][bb][cc][dd]");

            var input2 = new Dictionary<string, object> {{"key1", 1}, {"key2", "value2"}, {"key3", "value3"}};

            var rs2 = input2.ToFormatString("[{0} - {1}]\r\n",
                                            pair => new[] {pair.Key, pair.Value, "ddd"});
            Assert.AreEqual("[key1 - 1]\r\n[key2 - value2]\r\n[key3 - value3]\r\n", rs2);

            Assert.ThrowsException<ArgumentNullException>(() => input2.ToFormatString(null, pair => new object[] {pair.Key}));
        }
    }
}