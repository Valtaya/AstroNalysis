using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}
