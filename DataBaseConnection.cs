using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DataAnalysis
{
    class DataBaseConnection
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=astrodata");

        public void OpenConnection()
        {
            conn.Open();
        }
        public void CloseConnection()
        {
            conn.Close();
        }
    }
}
