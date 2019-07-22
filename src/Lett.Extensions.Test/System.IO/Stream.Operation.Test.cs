using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class StreamOperationTest
    {
        [TestInitialize]
        public void Startup()
        {
            var testDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestText");
            if (Directory.Exists(testDir)) Directory.Delete(testDir, true);
        }

        [TestCleanup]
        public void Clean()
        {
            var testDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestText");
            if (Directory.Exists(testDir)) Directory.Delete(testDir, true);
        }

        [TestMethod]
        public void SaveToFile_Test()
        {
            var source = "abcd";
            var path   = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestText", "1.txt");
            using (var ms = new MemoryStream(source.ToBytes())) { ms.SaveToFile(path); }

            using (var ms = new MemoryStream(source.ToBytes())) { ms.SaveToFile(path); }

            var rs = File.ReadAllText(path);
            Assert.AreEqual(rs, source);

            using (var ms = new MemoryStream(source.ToBytes())) { ms.SaveToFile(path, FileMode.Append); }

            var rs2 = File.ReadAllText(path);
            Assert.AreEqual(rs2, $"{source}{source}");

            using (var ms = new MemoryStream(source.ToBytes())) { ms.SaveToFile(path, FileMode.Append, 1); }

            var rs3 = File.ReadAllText(path);
            Assert.AreEqual(rs3, $"{source}{source}{source}");
        }
    }
}