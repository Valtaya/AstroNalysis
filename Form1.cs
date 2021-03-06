﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
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
            //string dataName = dataGridView1.CurrentRow.Cells["Data"].FormattedValue.ToString();

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                string dataName = dataGridView1.CurrentRow.Cells["Data"].FormattedValue.ToString();
                Process.Start("CMD.exe", "/K" + fileName + " " + dataName);
            }
            else
            {
                Process.Start("CMD.exe", "/K" + fileName + " " + textBox1.Text);
            }


        }
        private void run_cmd2()
        {
            string fileName = @"C:\\Users\\NOO\\KAIRA-DATA\\plot_2d_spectrum.py";
            //string dataName = dataGridView1.CurrentRow.Cells["Data"].FormattedValue.ToString();

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                string dataName = dataGridView1.CurrentRow.Cells["Data"].FormattedValue.ToString();
                Process.Start("CMD.exe", "/K" + fileName + " " + dataName);
            }
            else
            {
                Process.Start("CMD.exe", "/K" + fileName + " " + textBox1.Text);
            }
            
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
        //This entry describes a control that "displays a dialog box that prompts the user to open a file"
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        //browse
        private void button4_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    //display path in text box
                    textBox1.Text = openFileDialog1.FileName;
                    string text = File.ReadAllText(file);
                    size = text.Length;
                }
                catch (IOException)
                {
                }
            }
            Console.WriteLine(size); // <-- Shows file size in debugging mode.
            Console.WriteLine(result); // <-- For debugging use.
        }
        //browse textbox
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*textBox1.KeyPress += (sndr, ev) =>
            {
                if (ev.KeyChar.Equals((char)13))
                {
                    button4_Click(sender, e);// call your method for action on enter
                    ev.Handled = true; // suppress default handling
                   
                }
            };*/
            

        }
        //download
        private void button5_Click(object sender, EventArgs e)
        {
            using (var client = new WebClient())
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                WebClient wc = new WebClient();
                string path = dataGridView1.CurrentRow.Cells["Data"].FormattedValue.ToString();
                string file = dataGridView1.CurrentRow.Cells["File"].FormattedValue.ToString();

                client.DownloadFile(path, desktopPath + "/" + file);
                
            }
            MessageBox.Show("Download complete");


        }
        //search
        private void button6_Click(object sender, EventArgs e)
        {
            string text = textBox2.Text;
            //create DataTable object:
            DataTable dt = new DataTable();
            //create an instance from DataBaseConnection() class:
            DataBaseConnection DB = new DataBaseConnection();

            //call to the OpenConnection() method:
            DB.OpenConnection();
            dt = DB.Search(text);
            dataGridView1.DataSource = dt;
            DB.CloseConnection();
        }
        //search textbox
        public void textBox2_TextChanged(object sender, EventArgs e)
        {
            //allow enter key to call button press for search
            textBox2.KeyPress += (sndr, ev) =>
            {
                if (ev.KeyChar.Equals((char)13))
                {
                    button6_Click(sender, e);// call your method for action on enter
                    ev.Handled = true; // suppress default handling

                }
            };
        }
        private void textBoxFile_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length != 0)
            {
                textBox1.Text = files[0];
            }
        }
    }
}
