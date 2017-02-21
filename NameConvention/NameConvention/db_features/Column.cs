using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameConvention.db_features
{
    public class Column
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public void Rename(string newName, SqlConnection conn)
        {
            string QueryString = "";
            SqlCommand command = new SqlCommand(QueryString, conn);
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex) { }
        }
    }
}
