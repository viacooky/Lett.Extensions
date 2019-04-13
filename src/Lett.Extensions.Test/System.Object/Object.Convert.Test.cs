using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class ObjectConvertTest
    {
        [TestMethod]
        public void To_Test()
        {
            // valueType
            // int to string
            Assert.AreEqual(11.To<string>(), "11");
            // string to int
            Assert.AreEqual("11".To<int>(), 11);
        }
    }
}