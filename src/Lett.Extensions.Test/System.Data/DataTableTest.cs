using System.Data;
using System.Linq;
using Lett.Extensions.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class DataTableTest
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
        public void ZeroRows_Test()
        {
            // 空行Datatable情况
            Assert.IsFalse(_testTable1.HasRows());
            Assert.ThrowsException<LettExtensionsDataTableException>(() => _testTable1.FirstRow());
            Assert.ThrowsException<LettExtensionsDataTableException>(() => _testTable1.LastRow());
        }

        [TestMethod]
        public void HasRows_Test()
        {
            // 添加行
            Enumerable.Range(0, 10).ToList().ForEach(index => { _testTable1.Rows.Add($"RowId_{index}", $"Name_{index}"); });
            Assert.IsTrue(_testTable1.HasRows());
            Assert.AreEqual(_testTable1.FirstRow()["FRowId"].ToString(), "RowId_0");
            Assert.AreEqual(_testTable1.LastRow()["FRowId"].ToString(), "RowId_9");
        }
    }
}