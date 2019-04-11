using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class EnumTest
    {
        [TestMethod]
        public void GetDescription_Test()
        {
            Assert.AreEqual(MyEnum.EnumValue0.GetDescription(), "这里是EnumValue0的说明");
            Assert.AreEqual(MyEnum.EnumValue1.GetDescription(), "这里是EnumValue1的说明");
        }

        [TestMethod]
        public void GetEnumDescription_Test()
        {
            Assert.AreEqual(20.GetEnumDescription(typeof(MyEnum)), "这里是EnumValue20的说明");
            // 异常情况，返回null
            Assert.IsNull(20.GetEnumDescription(typeof(MyEnum2)));
            Assert.IsNull(20.GetEnumDescription(typeof(string)));
        }
    }

    public enum MyEnum
    {
        [System.ComponentModel.Description("这里是EnumValue0的说明")]
        EnumValue0 = 0,

        [System.ComponentModel.Description("这里是EnumValue1的说明")]
        EnumValue1 = 1,

        [System.ComponentModel.Description("这里是EnumValue20的说明")]
        EnumValue20 = 20
    }

    public enum MyEnum2
    {
        [System.ComponentModel.Description("这里是Enum2Value0的说明")]
        Enum2Value0 = 100
    }
}