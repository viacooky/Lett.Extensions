﻿using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class EnumerableTest
    {
        [TestMethod]
        public void IsNullOrEmpty_Test()
        {
            var arr = new[] {"aa", "bb"};
            Assert.IsFalse(arr.IsNullOrEmpty());
            var arr2 = new string[] { };
            Assert.IsTrue(arr2.IsNullOrEmpty());
            arr2 = null;
            Assert.IsTrue(arr2.IsNullOrEmpty());
        }

        [TestMethod]
        public void ContainsAny_Test()
        {
            var arr    = new[] {"aa", "bb"};
            var match  = new[] {"aa"};
            var match2 = new[] {"aa", "bb"};
            Assert.IsTrue(arr.ContainsAny(match));
            Assert.IsFalse(arr.ContainsAll(match));
            Assert.IsTrue(arr.ContainsAny(match2));
            Assert.IsTrue(arr.ContainsAll(match2));
        }

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
    }
}