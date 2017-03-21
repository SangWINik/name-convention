using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameConvention.db_features;

namespace DbConnectionUnitTestProject
{
    [TestClass]
    public class ConventionUnitTest
    {
        [TestMethod]
        public void ColumnTestMethod()
        {
            Convention con = new Convention("conv", "", ":TName:_:MainPart:_Column", "", false);
            Console.WriteLine(con.GetColumnName("Color", "Door"));
        }

        [TestMethod]
        public void TableTestMethod()
        {
            Convention con = new Convention("conv", ":MainPart:__++__:mainPart:", ":tName:_:MainPart:Column", "", true);
            Console.WriteLine(con.GetTableName("Doors"));
        }

        [TestMethod]
        public void PrimaryKeyTestMethod()
        {
            Convention con = new Convention("conv", ":MainPart:__++__:mainPart:", ":tName:_:MainPart:Column", ":TName:_ID", true);
            Console.WriteLine(con.GetPrimaryKeyName("ID", "Door"));
        }
    }
}
