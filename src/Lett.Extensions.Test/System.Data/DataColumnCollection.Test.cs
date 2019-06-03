using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lett.Extensions.Test
{
    [TestClass]
    public class DataColumnCollectionTest
    {
        [TestMethod]
        public void AddRange_Test()
        {
            var dt       = new DataTable();
            var colNames = new[] {"Field1", "Field2", "Field3"};
            dt.Columns.AddRange(colNames);

            Assert.AreEqual(dt.Columns.Count, 3);
            Assert.AreEqual(dt.Columns[0].ColumnName, colNames[0]);
            Assert.AreEqual(dt.Columns[1].ColumnName, colNames[1]);
            Assert.AreEqual(dt.Columns[2].ColumnName, colNames[2]);
        }

        [TestMethod]
        public void AddRangeParams_Test()
        {
            var dt = new DataTable();
            dt.Columns.AddRangeParams("Field1", "Field2", "Field3");
            Assert.AreEqual(dt.Columns.Count, 3);
            Assert.AreEqual(dt.Columns[0].ColumnName, "Field1");
            Assert.AreEqual(dt.Columns[1].ColumnName, "Field2");
            Assert.AreEqual(dt.Columns[2].ColumnName, "Field3");
        }
    }
}