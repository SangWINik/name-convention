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
        private List<Table> _tables = new List<Table>();
        private string _dataBaseName;
        private SqlConnection connection;

        public List<Table> Tables
        {
            get { return _tables; }
            set { _tables = value; }
        }

        public string DataBaseName
        {
            get { return _dataBaseName; }
            set { _dataBaseName = value; }
        }

        public SqlConnection Connection
        {
            get { return connection; }
        }


        public void FillStructure(SqlConnection conn)
        {
            connection = conn;
            if (connection.State != System.Data.ConnectionState.Open) connection.Open();
            if (_tables.Count != 0) _tables.Clear();

            //Визначення назви бази даних
            SqlCommand com = new SqlCommand("SELECT db_name()", conn);
            _dataBaseName = com.ExecuteScalar().ToString();

            //Визначення назв таблиць
            string Query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";
            SqlCommand command = new SqlCommand(Query, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader[0].ToString() != "sysdiagrams") //Пропускаєм системну таблицю
                {
                    Table tmp = new Table(reader[0].ToString());
                    _tables.Add(tmp);
                }
            }
            reader.Close();

            //Визначення назв колонок в таблицях
            foreach (var tab in _tables)
            {
                string q = "select COLUMN_NAME from information_schema.columns where table_name = '" + tab.Name + "';";
                SqlCommand comm = new SqlCommand(q, conn);
                SqlDataReader r = comm.ExecuteReader();
                while (r.Read())
                {
                    tab.Columns.Add(new Column(r[0].ToString()));
                }
                r.Close();
            }
        }

        public void RenameDataBase(string new_name)
        {
            string QueryString = "ALTER DATABASE " + _dataBaseName + " MODIFY NAME = " + new_name;
            SqlCommand command = new SqlCommand(QueryString, connection);
            try
            {
                //connection.Open();
                command.ExecuteNonQuery();
                //connection.Close();
            }
            catch (Exception ex) { }
        }
    }
}
