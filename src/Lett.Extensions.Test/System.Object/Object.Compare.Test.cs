using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class ObjectCompareTest
    {
        [TestMethod]
        public void IsDBNull_Test()
        {
            Assert.IsFalse("ddd".IsDBNull());
            Assert.IsTrue(DBNull.Value.IsDBNull());

            var value = DBNull.Value;
            Assert.IsTrue(value.IsDBNull());
        }
    }
}