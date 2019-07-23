using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class ObjectOperationTest
    {
        [TestInitialize]
        public void StartUp()
        {
            var dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ObjectTest");
            if(!Directory.Exists(dir)) Directory.Delete(dir,true);
        }
        
        [TestCleanup]
        public void Clean()
        {
            var dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ObjectTest");
            if(!Directory.Exists(dir)) Directory.Delete(dir,true);
        }
        
        
        [TestMethod]
        public void Pipe_Test()
        {
            var obj1 = new MyClass();
            var rs = obj1.Pipe(o => { o.Name += "pipe1"; })
                         .Pipe(o => { o.Name += "_pipe2"; })
                         .Pipe(o => { o.Name += "_pipe3"; })
                         .Pipe(o => { o.Name += "_pipe4"; })
                         .Pipe(o => { o.Name += "_pipe5"; });

            Assert.AreEqual(rs.Name, "pipe1_pipe2_pipe3_pipe4_pipe5");

            obj1 = new MyClass();
            var rs2 = obj1.Pipe(o => { o.Name += "pipe1"; })
                          .Pipe(o => { o.Name += "_pipe2"; })
                          .Pipe(o => { o.Name += "_pipe3"; })
                          .Pipe(o => { o.Name += "_pipe4"; })
                          .Pipe(o => { o.Name += "_pipe5"; })
                          .Pipe(o => o.Name.Replace("pipe", "")); // pipe func
            Assert.AreEqual(rs2, "1_2_3_4_5");
        }

        [Serializable]
        private class MyClass
        {
            public string Name { get; set; }
        }

        [TestMethod]
        public void SaveAsFile_Test1()
        {
            var source = new MyClass {Name = "abd"};
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ObjectTest", "1.bin");
            source.SaveAsFile(path, FileMode.Create, new BinaryFormatter());
            var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            var rs = fs.Deserialize<MyClass>();
            Assert.AreEqual(rs.Name, "abd");
        }
        
        [TestMethod]
        public void SaveAsFile_Test2()
        {
            var source = "abc";
            var path   = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ObjectTest", "2.bin");
            source.SaveAsFile(path, FileMode.Create);
            var fs = path.AsFileStream_Read();
            var rs = fs.Deserialize<string>();
            Assert.AreEqual(rs, "abc");
        }
    }
}