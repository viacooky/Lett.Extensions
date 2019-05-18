using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class ArrayOperationTest
    {
        [TestMethod]
        public void ClearAll_Test()
        {
            var s = new[] {"aaa", "bbb"};
            s.ClearAll();
            Assert.AreEqual(s.Length,2);
            Assert.AreEqual(s[0],null);
            Assert.AreEqual(s[1],null);
        }
        
        [TestMethod]
        public void Sort_Test()
        {
            var s = new[] {"aaa", "bbb","dddd","ccc"};
            s.Sort();
            foreach (var s1 in s) { Console.WriteLine(s1); }
        }
    }
}