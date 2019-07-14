using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class EnumerableOperationTest
    {
        [TestMethod]
        public void ForEach_Test()
        {
            var arr = new[] {"aa", "bb"};
            var rs  = new Dictionary<int, string>();
            arr.ForEach((index, str) => rs.Add(index, str));
            Assert.AreEqual(rs.Count, 2);
            Assert.AreEqual(rs[0], "aa");
            Assert.AreEqual(rs[1], "bb");

            var strList = new List<string> {"aa", "bb"};
            var rs2     = new Dictionary<int, string>();
            strList.ForEach((index, str) => rs2.Add(index, str));
            Assert.AreEqual(rs2.Count, 2);
            Assert.AreEqual(rs2[0], "aa");
            Assert.AreEqual(rs2[1], "bb");
        }

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

        [TestMethod]
        public void Distinct_Test()
        {
            var input = new List<MyClass> {new MyClass {Age = 2, Name = "a"}, new MyClass {Age = 2, Name = "A"}, new MyClass {Age = 2, Name = "b"}};

            var rs1 = input.Distinct(s => s.Name, StringComparer.OrdinalIgnoreCase)
                           .ToList();

            Assert.AreEqual(2, rs1.Count);
            Assert.AreEqual("a", rs1[0].Name);


            var rs2 = input.Distinct(s => s.Age, EqualityComparer<int>.Default)
                           .ToList();
            Assert.AreEqual(1, rs2.Count);
            Assert.AreEqual("a", rs2[0]);
        }

        private class MyClass
        {
            public string Name { get; set; }
            public int    Age  { get; set; }
        }
    }
}