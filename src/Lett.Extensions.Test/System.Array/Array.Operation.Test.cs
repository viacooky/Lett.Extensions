using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class ArrayOperationTest
    {
        [TestMethod]
        public void ClearAll_Test()
        {
            var s = new[] {"aaa", "bbb"};
            s.ClearAll();
            Assert.AreEqual(s.Length, 2);
            Assert.AreEqual(s[0], null);
            Assert.AreEqual(s[1], null);

            var s2 = new [] {11, 22};
            s2.ClearAll();
            Assert.AreEqual(s2.Length, 2);
            Assert.AreEqual(s2[0],0);
            Assert.AreEqual(s2[1],0);
        }

        [TestMethod]
        public void Sort_Test1()
        {
            var s = new[] {"a", "b", "d", "c"};
            s.Sort();
            Assert.AreEqual(s[0], "a");
            Assert.AreEqual(s[1], "b");
            Assert.AreEqual(s[2], "c");
            Assert.AreEqual(s[3], "d");
        }

        [TestMethod]
        public void Sort_Test2()
        {
            var s = new[] {"aaa", "BBB", "DDD", "ccc", "00"};
            s.Sort(StringComparer.CurrentCultureIgnoreCase);
            Assert.AreEqual(s[0], "00");
            Assert.AreEqual(s[3], "ccc");
            s = new[] {"aa", "AA", "A"};
            s.Sort(StringComparer.Ordinal);
            Assert.AreEqual(s[0], "A");
            Assert.AreEqual(s[1], "AA");
            Assert.AreEqual(s[2], "aa");
            s.Sort(StringComparer.CurrentCulture);
            Assert.AreEqual(s[0], "A");
            Assert.AreEqual(s[1], "aa");
            Assert.AreEqual(s[2], "AA");
        }

        [TestMethod]
        public void Sort_Test3()
        {
            var s = new[] {"BB", "aa", "DDD", "ccc", "00"};
            s.Sort(2, 3);
            Assert.AreEqual(s[0], "BB");
            Assert.AreEqual(s[1], "aa");
            Assert.AreEqual(s[2], "00");
            Assert.AreEqual(s[3], "ccc");
            Assert.AreEqual(s[4], "DDD");

            s = new[] {"BB", "aa", "CCC", "ccc", "00"};
            s.Sort(2, 3, StringComparer.CurrentCulture);
            Assert.AreEqual(s[0], "BB");
            Assert.AreEqual(s[1], "aa");
            Assert.AreEqual(s[2], "00");
            Assert.AreEqual(s[3], "ccc");
            Assert.AreEqual(s[4], "CCC");
        }

        [TestMethod]
        public void Reverse_Test1()
        {
            var s = new[] {"a", "A", "B", "b", "0"};
            s.Reverse();
            Assert.AreEqual(s[0], "0");
            Assert.AreEqual(s[1], "b");
            Assert.AreEqual(s[2], "B");
            Assert.AreEqual(s[3], "A");
            Assert.AreEqual(s[4], "a");

            s = new[] {"a", "A", "B", "b", "0"};
            s.Reverse(2, 3);
            Assert.AreEqual(s[0], "a");
            Assert.AreEqual(s[1], "A");
            Assert.AreEqual(s[2], "0");
            Assert.AreEqual(s[3], "b");
            Assert.AreEqual(s[4], "B");
        }


        [TestMethod]
        public void Find_Test()
        {
            var s  = new[] {"aa", "aaaa", "bb", "bbbb"};
            var rs = s.Find(s1 => s1.Length == 2);
            Assert.AreEqual(rs, "aa");
            var rs2 = s.Find(s1 => s1.Length == 3);
            Assert.AreEqual(rs2, null);
        }

        [TestMethod]
        public void FindLast_Test()
        {
            var s  = new[] {"aa", "aaaa", "bb", "bbbb"};
            var rs = s.FindLast(s1 => s1.Length == 2);
            Assert.AreEqual(rs, "bb");
            var rs2 = s.FindLast(s1 => s1.Length == 3);
            Assert.AreEqual(rs2, null);
        }

        [TestMethod]
        public void FindAll_Test()
        {
            var s  = new[] {"aa", "aaaa", "bb", "bbbb"};
            var rs = s.FindAll(s1 => s1.Length == 2);
            Assert.AreEqual(rs.Length, 2);
            var rs2 = s.FindAll(s1 => s1.Length == 3);
            Assert.AreEqual(rs2.Length, 0);
        }

        [TestMethod]
        public void FindIndex_Test()
        {
            var s  = new[] {"aa", "aaa", "bb", "bb", "bbb", "ccc"};
            var rs = s.FindIndex(s1 => s1.Length == 2);
            Assert.AreEqual(rs, 0);
            var rs2 = s.FindIndex(1, s1 => s1.Length == 2);
            Assert.AreEqual(rs2, 2);
            var rs3 = s.FindIndex(1, 3, s1 => s1.Length == 2);
            Assert.AreEqual(rs3, 2);

            var rs4 = new[] {"a", "aa", "bb", "aaa"}.FindIndex(ss => ss.Length == 2);
            Assert.AreEqual(rs4,1);

            var rs5 = new[] {"a", "aa", "bb", "aaa"}.FindIndex(2,ss => ss.Length == 2);
            Assert.AreEqual(rs5,2);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new[] {"a", "aa", "bb", "aaa"}.FindIndex(99, ss => ss.Length == 2));

            var rs6 = new[] {"a", "aa", "bb", "aaa"}.FindIndex(1,2,ss => ss.Length == 2);
            Assert.AreEqual(rs6,1);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new[] {"a", "aa", "bb", "aaa"}.FindIndex(0, 99, ss => ss.Length == 2));

        }

        [TestMethod]
        public void FindLastIndex_Test()
        {
            var s  = new[] {"aa", "aaa", "bb", "bb", "bbb", "ccc"};
            var rs = s.FindLastIndex(s1 => s1.StartsWith("b"));
            Assert.AreEqual(rs, 4);
            var rs2 = s.FindLastIndex(1, s1 => s1.StartsWith("a"));
            Assert.AreEqual(rs2, 1);

            var rs1 = new[] {"a", "aa", "b", "bb", "bbb", "c"}.FindLastIndex(4, 3, s1 => s1.StartsWith("b")); 
            Assert.AreEqual(rs1,4);
        }

        [TestMethod]
        public void ForEach_Test()
        {
            var s  = new[] {"aa", "aaa", "bb", "bb", "bbb", "ccc"};
            var rs = new List<string>();
            s.ForEach(s1 => rs.Add(s1));
            Assert.AreEqual(rs.Count, 6);

            var rs2 = new List<string>();
            s.ForEach((i, s1) => rs2.Add($"{s1}-{i}"));
            Assert.AreEqual(rs2.Count, 6);
            Assert.AreEqual(rs2[0], "aa-0");
        }
    }
}