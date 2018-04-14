using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAnalysis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //button click event:
        //Check
        private void button1_Click(object sender, EventArgs e)
        {
            //create DataTable object:
            DataTable dt = new DataTable();
            //create an instance from DataBaseConnection() class:
            DataBaseConnection DB = new DataBaseConnection();

            //call to the OpenConnection() method:
            DB.OpenConnection();
            dt = DB.ReadValue();
            dataGridView1.DataSource = dt;
            DB.CloseConnection();
        }
        private void run_cmd1()
        {
            string fileName = @"C:\\Users\\NOO\\KAIRA-DATA\\plot_1d_spectrum.py";
            string dataName = @"C:\\Users\\NOO\\KAIRA-DATA\\20140430_144604_sst_rcu000.dat";
            //string test = "SELECT Data FROM ilofar WHERE ID=" + ;
            

            Process.Start("CMD.exe", "/C" + fileName + " " + dataName);
            
            
            
            /*Process p = new Process();
            p.StartInfo = new ProcessStartInfo("CMD.exe", "/C" + fileName + " 20140430_144604_sst_rcu000.dat")
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            p.Start();

            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            Console.WriteLine(output);

            Console.ReadLine();*/
        }
        private void run_cmd2()
        {
            string fileName = @"C:\\Users\\NOO\\KAIRA-DATA\\plot_2d_spectrum.py";

            Process.Start("CMD.exe", "/C" + fileName + " C:\\Users\\NOO\\KAIRA-DATA\\20140430_144604_sst_rcu000.dat");
        }
        //1D Plot:
        private void button2_Click(object sender, EventArgs e)
        {
            run_cmd1();
        }
        //2D Plot:
        private void button3_Click(object sender, EventArgs e)
        {
            run_cmd2();
        }
    }
}
