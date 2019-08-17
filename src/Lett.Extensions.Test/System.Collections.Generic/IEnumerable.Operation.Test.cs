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

            List<string> strList3 = null;
            // ReSharper disable once CollectionNeverQueried.Local
            var rs3 = new Dictionary<int, string>();
            // ReSharper disable once ExpressionIsAlwaysNull
            Assert.ThrowsException<ArgumentNullException>(() => { strList3.ForEach((index, str) => rs3.Add(index, str)); });

            var strList4 = new List<string> {"aa", "bb"};
            Assert.ThrowsException<ArgumentNullException>(() => { strList4.ForEach(null as Action<int, string>); });
        }

        [TestMethod]
        public void ForEach_Test2()
        {
            var arr = new[] {"aa", "bb"};
            var rs  = new List<string>();
            arr.Select(s => s).ForEach(str => rs.Add(str));
            Assert.AreEqual(2, rs.Count);
            Assert.AreEqual("aa", rs[0]);
            Assert.AreEqual("bb", rs[1]);

            string[] arr2 = null;
            // ReSharper disable once CollectionNeverQueried.Local
            var rs2 = new List<string>();
            // ReSharper disable once AssignNullToNotNullAttribute
            Assert.ThrowsException<ArgumentNullException>(() => arr2.Select(s => s).ForEach(str => rs2.Add(str)));

            var arr3 = new[] {"aa", "bb"};
            Assert.ThrowsException<ArgumentNullException>(() => { arr3.ForEach(null as Action<string>); });
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
            Assert.AreEqual("a", rs2[0].Name);
        }

        [TestMethod]
        public void SplitBlock_Test()
        {
            var s = new[] {1, 2, 3, 4, 5, 6, 7};
            Assert.AreEqual(7, s.SplitBlock(1).Count());
            Assert.AreEqual(4, s.SplitBlock(2).Count());
            Assert.AreEqual(3, s.SplitBlock(3).Count());
            Assert.AreEqual(2, s.SplitBlock(4).Count());
            Assert.AreEqual(1, s.SplitBlock(7).Count());
            Assert.AreEqual(1, s.SplitBlock(8).Count());
            Assert.AreEqual(2, s.SplitBlock(5).Count());
            Assert.ThrowsException<ArgumentException>(() => s.SplitBlock(-1));
            Assert.ThrowsException<ArgumentException>(() => s.SplitBlock(0));

            // ReSharper disable once CollectionNeverUpdated.Local
            var s2 = new List<string>();
            Assert.AreEqual(0, s2.SplitBlock(3).Count());
        }

        private class MyClass
        {
            public string Name { get; set; }
            public int    Age  { get; set; }
        }
    }
}