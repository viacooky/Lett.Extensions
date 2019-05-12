using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class StringFormatTest
    {
        [TestMethod]
        public void Format_Test()
        {
            var a = "abc {0}".Format("dddd");
            Assert.AreEqual(a, "abc dddd");
            var tmp = "{0}-{1}";
            Assert.AreEqual(tmp.Format("aaa", "bbb"), "aaa-bbb");
        }

        [TestMethod]
        public void Left_Right_Test()
        {
            Assert.AreEqual("1234567890".Left(3), "123");
            Assert.AreEqual("1234567890".Right(3), "890");
            Assert.AreEqual("1234567890".Left(0), "");
            Assert.AreEqual("1234567890".Right(0), "");
            Assert.AreEqual("1234567890".Left(10000), "1234567890");                        // 超过字符串原有长度
            Assert.AreEqual("1234567890".Right(10000), "1234567890");                       // 超过字符串原有长度
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { "dd".Left(-1); });  // length 小于0， 抛出异常
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { "dd".Right(-1); }); // length 小于0， 抛出异常
        }
    }
}