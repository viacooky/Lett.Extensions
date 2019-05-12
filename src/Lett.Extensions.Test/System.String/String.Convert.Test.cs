using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class StringConvertTest
    {
        [TestMethod]
        public void ToXmlDocument_Test()
        {
            var source = "<item><name>wrench</name></item>";
            var rs = source.ToXmlDocument();
            Assert.AreEqual(rs.InnerText,"wrench");
        }


        [TestMethod]
        public void ToBytes_Test()
        {
            var source = "abcd";
            var rs = source.ToBytes();
            Assert.AreEqual(rs.ToString(Encoding.UTF8),source);
            var rs2 = source.ToBytes(Encoding.Unicode);
            Assert.AreEqual(rs2.ToString(Encoding.Unicode),source);
            Assert.AreNotEqual(rs2.ToString(Encoding.UTF8),source);
            
        }

    }
}