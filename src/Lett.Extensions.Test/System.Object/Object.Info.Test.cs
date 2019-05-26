using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class ObjectInfoTest
    {
        [TestMethod]
        public void GetTypeName_Test()
        {
            var obj1 = new MyClass();
            Assert.AreEqual(obj1.GetTypeName(), "MyClass");
            var obj2 = "";
            Assert.AreEqual(obj2.GetTypeName(), "String");
            var obj3 = new DateTime();
            Assert.AreEqual(obj3.GetTypeName(), "DateTime");
            object obj4 = null;
            Assert.AreEqual(obj4.GetTypeName(), string.Empty);
        }

        private class MyClass
        {
        }
    }
}