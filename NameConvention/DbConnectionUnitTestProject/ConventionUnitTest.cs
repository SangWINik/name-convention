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
            Convention con = new Convention("conv", "", ":tName:_:MainPart:Column", "", false);
            Console.WriteLine(con.GetColumnName("Color", "Door"));
        }
    }
}
