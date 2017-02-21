using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameConvention.db_features
{
    public class DbStructure
    {
        private List<Table> _tables;
        private SqlConnection connection;

        public List<Table> Tables
        {
            get { return _tables; }
            set { _tables = value; }
        }

        public void FillStructure(SqlConnection conn)
        {
            connection = conn;
            connection.Open();
            string Query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";
            SqlCommand command = new SqlCommand(Query, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader[0]!= "sysdiagrams") //Пропускаєм системну таблицю
                    _tables.Add(new Table(reader[0].ToString()));
            }
        }
    }
}
