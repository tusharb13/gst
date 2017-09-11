using CsvHelper;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() {Filter="CSV|*.csv", ValidateNames=true })
            {
                if(sfd.ShowDialog()==DialogResult.OK)
                {   using (var sw = new StreamWriter(sfd.FileName))
                    {
                        var writer = new CsvWriter(sw);
                        writer.WriteHeader(typeof(user));
                        foreach(user u in userBindingSource.DataSource as List<user>)
                        {
                            writer.WriteRecord(u);
                        }
                    }
                    MessageBox.Show("Entered succesfully","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }

            } 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userBindingSource.DataSource = new List<user>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f6 = new Form6();
            f6.Show();
        }
    }
}
