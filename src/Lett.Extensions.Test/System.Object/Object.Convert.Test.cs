using System;
using System.Collections.Generic;
using System.Text;
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
            Assert.AreEqual(11.To<string>(),"11");
            // string to int
            Assert.AreEqual("11".To<int>(),11);

            

        }

        
    }

    
    public class TestClass1
    {
        public string SS { get; set; }
    }

    public class TestClass2 : TestClass1
    {
        public string SSS { get; set; }
    }

    public class TestClass3
    {
        public string SS { get; set; }
    }
}
