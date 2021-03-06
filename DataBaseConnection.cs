﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;
using System.IO;

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
        public DataTable ReadValue()
        {
            DataTable dt = new DataTable();
            
            MySqlDataAdapter da = new MySqlDataAdapter("select ID, Name, File , Data from ilofar", conn);

            da.Fill(dt);
            return dt;
        }
        public DataTable Search(string text)
        {
            string search = "SELECT ID, Name, File, Data FROM ilofar WHERE ID LIKE '%" + text + "%' OR Name LIKE '%" + text + "%' OR Data LIKE '%" + text + "%'";
            DataTable dt = new DataTable();

            MySqlDataAdapter da = new MySqlDataAdapter(search, conn);

            da.Fill(dt);
            return dt;
        }

        
    }
}
