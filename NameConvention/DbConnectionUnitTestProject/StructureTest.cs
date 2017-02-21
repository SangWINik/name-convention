using System;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameConvention.db_features;

namespace DbConnectionUnitTestProject
{
    [TestClass]
    public class StructureTest
    {
        [TestMethod]
        public void TestStructureInitialization()
        {
            SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=Door_Production;" + "Integrated Security=true");
            DbStructure structure = new DbStructure();
            structure.FillStructure(conn);
            Console.WriteLine(structure.DataBaseName + "\n");
            foreach (var tab in structure.Tables)
            {
                Console.WriteLine(tab.Name);
            }
        }
    }
}
