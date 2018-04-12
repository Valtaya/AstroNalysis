using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            string plot_1d = "F:\\Documents\\HDIP Project\\KAIRA\\KAIRA-UIT-DAT-506\\plot_1d_spectrum.py";
            string plot_2d = "F:\\Documents\\HDIP Project\\KAIRA\\KAIRA-UIT-DAT-506\\plot_2d_spectrum.py";

            // 1. Instantiate the connection
            SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=Northwind;Integrated Security=SSPI");
            SqlDataReader rdr = null;
            try
            {
                // 2. Open the connection
                conn.Open();
                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand("select * from ilofar", conn);
                //
                // 4. Use the connection
                //
                // get query results
                rdr = cmd.ExecuteReader();
                // print the CustomerID of each record
                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0]);
                }
            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }
                // 5. Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
