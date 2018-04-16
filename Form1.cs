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
            string dataName = dataGridView1.CurrentRow.Cells["Data"].FormattedValue.ToString();

            Process.Start("CMD.exe", "/C" + fileName + " " + dataName);
            

        }
        private void run_cmd2()
        {
            string fileName = @"C:\\Users\\NOO\\KAIRA-DATA\\plot_2d_spectrum.py";
            string dataName = dataGridView1.CurrentRow.Cells["Data"].FormattedValue.ToString();


            Process.Start("CMD.exe", "/K" + fileName + " " + dataName);
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

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
