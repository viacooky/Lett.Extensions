using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class StringEncryptTest
    {
        [TestMethod]
        public void Base64_Test()
        {
            var str1   = "ABCD";
            var base64 = "QUJDRA==";
            Assert.AreEqual(str1.Base64Encode(), base64); // encode
            Assert.AreEqual(base64.Base64Decode(), str1); // decode
        }
    }
}