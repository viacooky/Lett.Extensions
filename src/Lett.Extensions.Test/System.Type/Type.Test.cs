using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class TypeTest
    {
        [TestMethod]
        public void HasProperty_Test()
        {
            Assert.IsTrue(typeof(Class1).HasProperty("PropertyA"));
            Assert.IsFalse(typeof(Class1).HasProperty("PropertyB"));
        }
    }

    public class Class1
    {
        public  string PropertyA { get; set; }
        private string PropertyB { get; set; }
    }
}