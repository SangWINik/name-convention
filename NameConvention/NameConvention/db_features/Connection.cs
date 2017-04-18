using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameConvention.db_features
{
    public static class Connector
    {
        public static string Name;
        public static string Password;
        public static string Db_name;

        public static SqlConnection GetConnection(string name, string password, string db_name)
        {
            if (db_name == "")
                throw new Exception("Заповніть необхідні поля");
            Name = name;
            Password = password;
            Db_name = db_name;
            SqlConnection conn;
            try
            {
                if (name == "")
                {
                    conn =
                        new SqlConnection("Data Source=(local);Initial Catalog=" + db_name + ";" +
                                          "Integrated Security=true");
                }
                else
                {
                    conn =
                        new SqlConnection("Server=127.0.0.1;Database=" + db_name + ";User Id=" + name + "; Password=" +
                                          password + ";");
                }
            }
            catch (Exception ex)
            {
                conn = null;
            }
            return conn;
        }
    }
}
