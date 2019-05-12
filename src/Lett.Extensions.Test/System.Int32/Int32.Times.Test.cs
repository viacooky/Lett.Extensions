using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class Int32TimesTest
    {
        [TestMethod]
        public void Times_Test()
        {
            var rs = 0;
            10.Times(() => rs += 1);
            Assert.AreEqual(rs, 10);

            var rs2 = 0;
            10.Times(i => rs2 += i);
            Assert.AreEqual(rs2, 45);
        }
    }
}