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
        private List<Column> _columns = new List<Column>(); 

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
    }
}
