﻿using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            dataGridView1.DataBindings.Add(nameof(DataGrid.BackgroundColor), this, nameof(Control.BackColor));
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ls = this.userBindingSource.List;
            var FileName = @"C:\MyCSV\user.csv";
            if (!Directory.Exists(@"C:\MyCSV\"))
            {
                Directory.CreateDirectory(@"C:\MyCSV\");
            }
            using (var sw = new StreamWriter(FileName))
            {
                var writer = new CsvWriter(sw);
                writer.WriteHeader(typeof(user));
                foreach (user c in ls)
                {
                    writer.WriteRecord(c);
                }
            }
            MessageBox.Show("Entered succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        public void read()
        {
            using (StreamReader sr = new StreamReader(@"C:\MyCSV\user.csv"))
            {
                var csv = new CsvReader(sr);
                userBindingSource.DataSource = csv.GetRecords<user>();
                sr.Close();
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            read();
     
        }
    }
}
