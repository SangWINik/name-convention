using System;
using System.Data.SqlClient;
using System.Linq;
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

        [TestMethod]
        public void TestPKRename()
        {
            SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=Door_Production;" + "Integrated Security=true");
            DbStructure structure = new DbStructure();
            structure.FillStructure(conn);
            Table t = structure.Tables.FirstOrDefault(x => x.Name == "Door");
            t.RenameColumnPK("Door_ID", conn);
        }
    }
}
