using System;
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
            MySqlDataAdapter da = new MySqlDataAdapter("select * from ilofar", conn);

            da.Fill(dt);
            return dt;
        }

        //string plot_1d = "C:\\Users\\NOO\\KAIRA-DATA\\plot_1d_spectrum.py";
        //string plot_2d = "C:\\Users\\NOO\\KAIRA-DATA\\plot_2d_spectrum.py";

        /*private void run_cmd(string cmd, string args)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "C:\\Users\\NOO\\KAIRA-DATA\\plot_1d_spectrum.py";
            start.Arguments = string.Format("{0} {1}", cmd, args);
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.Write(result);
                }
            }
        }*/


    }
}
