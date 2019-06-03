using System;
using System.Linq;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class XmlDocumentTest
    {
        [TestMethod]
        public void SelectNodesEnumerable_Test()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load("System.Xml.XmlDocument/test.xml");
            var xpath = "/functional/dataSource/storeSource/columns/column";
            var rs = xmlDoc.SelectNodesEnumerable(xpath);
            Assert.AreEqual(rs.ToList()[0]?.Attributes?.GetNamedItem("name").Value, "FRowId");

            Assert.ThrowsException<ArgumentNullException>(() => xmlDoc.SelectNodesEnumerable(null));
            xmlDoc = null;
            Assert.ThrowsException<ArgumentNullException>(() => xmlDoc.SelectNodesEnumerable(xpath));
        }
    }
}