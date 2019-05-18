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
        public void Sort_Test1()
        {
            var s = new[] {"aaa", "bbb","dddd","ccc"};
            s.Sort();
            Assert.AreEqual(s[0],"aaa");
            Assert.AreEqual(s[2],"ccc");
        }
        
        [TestMethod]
        public void Sort_Test2()
        {
            var s = new[] {"aaa", "BBB","DDD","ccc","00"};
            s.Sort(StringComparer.CurrentCultureIgnoreCase);
            Assert.AreEqual(s[0],"00");
            Assert.AreEqual(s[3],"ccc");
            s = new[] {"aa", "AA", "A"};
            s.Sort(StringComparer.Ordinal);
            Assert.AreEqual(s[0],"A");
            Assert.AreEqual(s[1],"AA");
            Assert.AreEqual(s[2],"aa");
            s.Sort(StringComparer.CurrentCulture);
            Assert.AreEqual(s[0],"A");
            Assert.AreEqual(s[1],"aa");
            Assert.AreEqual(s[2],"AA");
        }
        
        [TestMethod]
        public void Sort_Test3()
        {
            var s = new[] {"BB", "aa","DDD","ccc","00"};
            s.Sort(2,3);
            Assert.AreEqual(s[0],"BB");
            Assert.AreEqual(s[1],"aa");
            Assert.AreEqual(s[2],"00");
            Assert.AreEqual(s[3],"ccc");
            Assert.AreEqual(s[4],"DDD");
            
            s = new[] {"BB", "aa","CCC","ccc","00"};
            s.Sort(2,3,StringComparer.CurrentCulture);
            Assert.AreEqual(s[0],"BB");
            Assert.AreEqual(s[1],"aa");
            Assert.AreEqual(s[2],"00");
            Assert.AreEqual(s[3],"ccc");
            Assert.AreEqual(s[4],"CCC");
        }
        
        [TestMethod]
        public void Reverse_Test1()
        {
            var s = new[] {"a", "A","B","b","0"};
            s.Reverse();
            Assert.AreEqual(s[0],"0");
            Assert.AreEqual(s[1],"b");
            Assert.AreEqual(s[2],"B");
            Assert.AreEqual(s[3],"A");
            Assert.AreEqual(s[4],"a");
            
            s = new[] {"a", "A","B","b","0"};
            s.Reverse(2,3);
            Assert.AreEqual(s[0],"a");
            Assert.AreEqual(s[1],"A");
            Assert.AreEqual(s[2],"0");
            Assert.AreEqual(s[3],"b");
            Assert.AreEqual(s[4],"B");
        }
        
    }
}