using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameConvention.db_features
{
    public class Table
    {
        private string _name;
        private List<Column> _columns; 

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<Column> Columns
        {
            get { return _columns; }
            set { _columns = value; }
        }

        public Table(string name)
        {
            _name = name;
        }

        public void Rename(string newName, SqlConnection conn)
        {
            //string QueryString = "ALTER TABLE " + _name + " RENAME TO " + newName + ";";
            string QueryString = "sp_rename '" + _name + "', '" + newName + "';";
            SqlCommand command = new SqlCommand(QueryString, conn);
            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex) { }
        }

        public void RenameColumn(Column col, string newName, SqlConnection conn)
        {
            //string QueryString = "ALTER TABLE " + _name + " RENAME COLUMN " + col.Name + " TO " + newName + ";";
            string QueryString = "sp_rename '" + _name + "." + col.Name + "', '" + newName + "', '" + "'COLUMN';";
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
