using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class StringCompareTest
    {
        [TestMethod]
        public void IsEmail_Test()
        {
            Assert.IsTrue("abc@qqq.com".IsEmail());
            Assert.IsFalse("abc@qqq#.com".IsEmail());
            Assert.IsTrue("abc@qqqabc.acdk.com".IsEmail());
            Assert.IsFalse("abc@qqqabc@acdk.com".IsEmail());
        }

        [TestMethod]
        public void IsUpper_Test()
        {
            Assert.IsTrue("ABC".IsUpper());
            Assert.IsFalse("ABd".IsUpper());
            Assert.IsFalse("ccc".IsUpper());
        }

        [TestMethod]
        public void IsLower_Test()
        {
            Assert.IsTrue("abcddd".IsLower());
            Assert.IsFalse("abDD".IsLower());
            Assert.IsFalse("DDDD".IsLower());
        }

        [TestMethod]
        public void IsUrl_Test()
        {
            Assert.IsTrue("http://sdf.com".IsUrl());
            Assert.IsTrue("https://sdf.com".IsUrl());
            Assert.IsTrue("ftp://sdf.com".IsUrl());
            Assert.IsTrue("http://sdf.c.dddd.cccc.saaa.com".IsUrl());
            Assert.IsTrue("aaaadd://sdf.com".IsUrl());
            Assert.IsFalse("sdf.com".IsUrl());
            Assert.IsFalse("www.sdf.com".IsUrl());
            Assert.IsFalse("www.asdfwww.sdf.com".IsUrl());
        }

        [TestMethod]
        public void IgnoreCaseEquals_Test()
        {
            Assert.IsTrue("aaa".IgnoreCaseEquals("AaA"));
        }

        [TestMethod]
        public void IsNullOrWhiteSpace_Test()
        {
            Assert.IsTrue("   ".IsNullOrWhiteSpace());  // space
            Assert.IsTrue("    ".IsNullOrWhiteSpace()); // tab
            Assert.IsTrue("\r".IsNullOrWhiteSpace());   // \r
            Assert.IsTrue("\n".IsNullOrWhiteSpace());   // \n
            Assert.IsTrue("\r\n".IsNullOrWhiteSpace()); // \r\n
            Assert.IsTrue("\t".IsNullOrWhiteSpace());   // \t
        }

        [TestMethod]
        public void ContainsAll_Test()
        {
            var a = "aaabbbccc";
            var b = new[] {"aaa", "bbb"};
            Assert.IsTrue(a.ContainsAll(b));
            var c = new[] {"a", "b", "c"};
            Assert.IsTrue(a.ContainsAll(c));
            var d = new List<string> {"aaa", "bbb", "c"};
            Assert.IsTrue(a.ContainsAll(d));
            var e = new List<string> {"aaa", "bbb", "d"};
            Assert.IsFalse(a.ContainsAll(e));
            var f = new[] {"AAA", "bbb"};
            Assert.IsFalse(a.ContainsAll(f, StringComparison.Ordinal));
        }

        [TestMethod]
        public void ContainsAny_Test()
        {
            var a = "aaabbbccc";
            var b = new[] {"a", "dd", "eee"};
            Assert.IsTrue(a.ContainsAny(b));
            var c = new[] {"A", "dddd"};
            Assert.IsTrue(a.ContainsAny(c));
            var d = new[] {"A", "B"};
            Assert.IsFalse(a.ContainsAny(d, StringComparison.Ordinal));
        }
    }
}