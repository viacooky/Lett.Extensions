using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class BooleanTest
    {
        [TestMethod]
        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        public void IfTrue_Test()
        {
            const bool o  = true;
            var        rs = "";
            o.IfTrue(() => rs = "it is true");
            Assert.AreEqual(rs, "it is true");
            Assert.AreEqual(o.IfTrue("it is true"), "it is true");

            const bool o2  = false;
            var        rs2 = "";
            o2.IfTrue(() => rs2 = "it is false");
            Assert.AreNotEqual(rs2, "it is false");
            Assert.AreNotEqual(o2.IfTrue("it is false"), "it is false");
        }

        [TestMethod]
        [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
        public void IfFalse_Test()
        {
            const bool o  = false;
            var        rs = "";
            o.IfFalse(() => rs = "it is false");
            Assert.AreEqual(rs, "it is false");
            Assert.AreEqual(o.IfFalse("it is false"), "it is false");

            var o2  = true;
            var rs2 = "";
            o2.IfFalse(() => rs2 = "it is true");
            Assert.AreNotEqual(rs2, "it is true");
            Assert.AreNotEqual(o2.IfFalse("it is true"), "it is true");
        }
    }
}