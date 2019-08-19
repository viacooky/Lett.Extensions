using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class GuidTest
    {
        [TestMethod]
        public void IfTrue_Test()
        {
            var s = Guid.Empty;
            s = s.GetNewGuidIfEmpty();
            Assert.AreNotEqual(Guid.Empty, s);
        }
    }
}