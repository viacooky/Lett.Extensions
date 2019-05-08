using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class Int64TimesTest
    {
        [TestMethod]
        public void Times_Test()
        {
            var rs = 0L;
            10L.Times(() => rs += 1);
            Assert.AreEqual(rs, 10);

            var rs2 = 0L;
            10L.Times(i => rs2 += i);
            Assert.AreEqual(rs2, 45L);
        }
    }
}