using System.Data;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class DataRowTest
    {
        private DataTable _testTable1;


        [TestInitialize]
        public void Init()
        {
            _testTable1 = new DataTable();
            _testTable1.Columns.Add("FRowId", typeof(string));
            _testTable1.Columns.Add("FName", typeof(string));
        }

        [TestMethod]
        public void Cell_Test()
        {
            _testTable1.Rows.Clear();
            Enumerable.Range(0, 10).ToList().ForEach(index => { _testTable1.Rows.Add($"RowId_{index}", $"Name_{index}"); });

            var firstRow = _testTable1.RowsEnumerable().FirstOrDefault();
            // 存在的列
            Assert.AreEqual(firstRow.Cell<string>("FRowId").GetType(), typeof(string));
            Assert.AreNotEqual(firstRow.Cell<string>("FRowId"), default);
            // 不存在的列
            Assert.AreEqual(firstRow.Cell<string>("NotExistColumn"), default);
            // 不存在的列 , 默认值
            Assert.AreEqual(firstRow.Cell("NotExistColumn", "abc"), "abc");
            // 不存在的列 , 默认值 委托
            Assert.AreEqual(firstRow.Cell("NotExistColumn", () => "func return value"), "func return value");
        }
    }
}