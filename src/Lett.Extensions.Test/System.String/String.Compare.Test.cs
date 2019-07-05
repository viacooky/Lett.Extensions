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
        public void IsNullOrEmpty_Test()
        {
            Assert.IsTrue(string.Empty.IsNullOrEmpty());
            Assert.IsFalse(" ".IsNullOrEmpty());
            Assert.IsTrue(default(string).IsNullOrEmpty());
            string aa = null;
            Assert.IsTrue(aa.IsNullOrEmpty());
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


        [TestMethod]
        public void IsLike_Test()
        {
            var test1 = "abcdefg\r\nabcdefghijk";
            Assert.IsTrue(test1.IsLike("abc*"));
            Assert.IsTrue(test1.IsLike("a*"));
            Assert.IsTrue(test1.IsLike("*ijk"));
            Assert.IsTrue(test1.IsLike("abc*fg*"));

            var test2 = "aaaaa*bbbb*ccccc";
            Assert.IsTrue(test2.IsLike(@"*b\*c*"));


            var test3 = "aaaa*bbbbb";
            Assert.IsTrue(test3.IsLike("aaaa*bbbbb"));

            var test4 = "abcdef<<";
            Assert.IsTrue(test4.IsLike(@"*\<\<"));
            Assert.IsTrue(test4.IsLike(@"*"));
            Assert.IsTrue(test4.IsLike(test4));


            var test5 = "";
            Assert.IsTrue(test5.IsLike(""));
            Assert.IsTrue(test5.IsLike("*"));
            Assert.IsFalse(test5.IsLike("abc*"));

            string test6 = null;
            Assert.IsFalse(test6.IsLike(null));
            Assert.IsTrue(test5.IsLike("*"));
        }

        [TestMethod]
        public void IsEmpty_Test()
        {
            var a = "";
            var b = " ";
            Assert.IsTrue(a.IsEmpty());
            Assert.IsFalse(b.IsEmpty());
        }

        [TestMethod]
        public void IsWhiteSpace_Test()
        {
            var a = "";
            var b = " ";
            var c = "\r";
            var d = "\t";
            var e = "\n";
            var f = "\r \t";
            Assert.IsTrue(a.IsWhiteSpace());
            Assert.IsTrue(b.IsWhiteSpace());
            Assert.IsTrue(c.IsWhiteSpace());
            Assert.IsTrue(d.IsWhiteSpace());
            Assert.IsTrue(e.IsWhiteSpace());
            Assert.IsTrue(f.IsWhiteSpace());
        }
    }
}