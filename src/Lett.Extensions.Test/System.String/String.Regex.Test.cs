using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class StringRegexTest
    {
        [TestMethod]
        public void RegexIsMatch_Test()
        {
            var source = "abcdefg\r\nabcdefghijk";
            Assert.IsTrue(source.RegexIsMatch(@"^abc.*\r$", RegexOptions.Multiline));
            Assert.IsTrue(source.RegexIsMatch(@"^abc.*ijk$", RegexOptions.Singleline));
        }

        [TestMethod]
        public void RegexMatch_Test()
        {
            var test1 = "aaaabaaaabaaaa";
            var match = test1.RegexMatch("b");
            Assert.IsTrue(match.Success);
            var match2 = test1.RegexMatch("c");
            Assert.IsFalse(match2.Success);
        }

        [TestMethod]
        public void RegexMatches_Test()
        {
            var test1   = "aaaabaaaabaaaa";
            var matches = test1.RegexMatches(@"aaaab");
            Assert.AreEqual(matches.Count, 2);
        }

        [TestMethod]
        public void RegexSplit_Test()
        {
            var test1 = "aaaa.bbbb.cccc";
            var rs    = test1.RegexSplit(@"\.");
            Assert.AreEqual(rs.Length, 3);
            Assert.AreEqual(rs[0], "aaaa");
            Assert.AreEqual(rs[1], "bbbb");
            Assert.AreEqual(rs[2], "cccc");
        }

        [TestMethod]
        public void RegexSplit2_Test()
        {
            var test1 = "aaaa.bbbb.cccc";
            var rs    = test1.RegexReplace(@"\.", "@");
            Assert.AreEqual(rs, "aaaa@bbbb@cccc");

            var rs2 = test1.RegexReplace(@"\.", match => match.Value + "@");
            Assert.AreEqual(rs2, "aaaa.@bbbb.@cccc");
        }
    }
}