using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class DirectoryTest
    {
        [TestMethod]
        public void DirectoryTest1()
        {
            var directoryInfo = new DirectoryInfo("System.IO/TestDirectory");
            var fileInfos = directoryInfo.GetFiles(SearchOption.AllDirectories, "*.json");
            Assert.AreEqual(2,fileInfos.Length);
            
            var fileInfos2 = directoryInfo.GetFiles(SearchOption.TopDirectoryOnly,"*.json");
            Assert.AreEqual(1,fileInfos2.Length);

            var fileInfo3 = directoryInfo.GetFiles(SearchOption.AllDirectories,"*.json", "*.txt");
            Assert.AreEqual(3,fileInfo3.Length);

            var fileInfo5 = directoryInfo.GetFiles(SearchOption.AllDirectories, new[] {"*.*"}, fileInfo => fileInfo.Name.StartsWith("sub"));
            Assert.AreEqual(3,fileInfo5.Length);
        }
    }
}