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


        [TestMethod]
        public void AppendPrefixIfNotExist_Test()
        {
            var str1 = "aa";
            var rs1  = str1.AppendPrefixIfNotExist("t_");
            Assert.AreEqual(rs1, "t_aa");
            var str2 = "T_bb";
            var rs2  = str2.AppendPrefixIfNotExist("t_");
            Assert.AreEqual(rs2, "T_bb");
            var str3 = "T_bb";
            var rs3  = str3.AppendPrefixIfNotExist("t_", StringComparison.Ordinal);
            Assert.AreEqual(rs3, "t_T_bb");


            Assert.ThrowsException<ArgumentNullException>(() => "T_cc".AppendPrefixIfNotExist(null));
            Assert.ThrowsException<ArgumentNullException>(() => default(string).AppendPrefixIfNotExist("d"));
        }

        [TestMethod]
        public void AppendSuffixIfNotExist_Test()
        {
            var str1 = "aa";
            var rs1  = str1.AppendSuffixIfNotExist("_t");
            Assert.AreEqual(rs1, "aa_t");
            var str2 = "bb_T";
            var rs2  = str2.AppendSuffixIfNotExist("_t");
            Assert.AreEqual(rs2, "bb_T");
            var str3 = "cc_T";
            var rs3  = str3.AppendSuffixIfNotExist("_t", StringComparison.Ordinal);
            Assert.AreEqual(rs3, "cc_T_t");


            Assert.ThrowsException<ArgumentNullException>(() => "cc_T".AppendSuffixIfNotExist(null));
            Assert.ThrowsException<ArgumentNullException>(() => default(string).AppendSuffixIfNotExist("_t"));
        }

        [TestMethod]
        public void RemovePrefix_Test()
        {
            Assert.AreEqual("t_table".RemovePrefix("T_"), "table");
            Assert.AreEqual("t_table".RemovePrefix("T_", StringComparison.Ordinal), "t_table");
            Assert.AreEqual("t_table".RemovePrefix("aaaaaaaaaaa", StringComparison.Ordinal), "t_table");
            Assert.AreEqual("t_table".RemovePrefix("T_TABLE"), "");

            Assert.ThrowsException<ArgumentNullException>(() => "t_table".RemovePrefix(null));
            Assert.ThrowsException<ArgumentNullException>(() => default(string).RemovePrefix("ddd"));
        }

        [TestMethod]
        public void RemoveSuffix_Test()
        {
            Assert.AreEqual("logo.jpg".RemoveSuffix(".JPg"), "logo");
            Assert.AreEqual("logo.jpg".RemoveSuffix(".JPG", StringComparison.Ordinal), "logo.jpg");
            Assert.AreEqual("logo.jpg".RemoveSuffix("aaaaaaaa"), "logo.jpg");
            Assert.AreEqual("logo.jpg".RemoveSuffix("LoGO.jpG"), "");

            Assert.ThrowsException<ArgumentNullException>(() => "logo.jpg".RemoveSuffix(null));
            Assert.ThrowsException<ArgumentNullException>(() => default(string).RemoveSuffix("dddd"));
        }
    }
}