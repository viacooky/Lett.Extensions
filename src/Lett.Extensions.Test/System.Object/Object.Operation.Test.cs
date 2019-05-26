using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class ObjectOperationTest
    {
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

        private class MyClass
        {
            public string Name { get; set; }
        }
    }
}