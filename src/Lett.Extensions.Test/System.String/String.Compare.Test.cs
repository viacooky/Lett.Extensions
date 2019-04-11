using System;
using System.Collections.Generic;
using System.Text;
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
            Assert.IsFalse("/sdf.com".IsUrl());
            Assert.IsFalse("www.sdf.com".IsUrl());
            Assert.IsFalse("www.asdfwww.sdf.com".IsUrl());
        }

        [TestMethod]
        public void IgnoreCaseEquals_Test()
        {
            Assert.IsTrue("aaa".IgnoreCaseEquals("AaA"));
        }
    }
}