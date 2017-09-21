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
        userRegisteration usr = new userRegisteration();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataBindings.Add(nameof(DataGrid.BackgroundColor), this, nameof(Control.BackColor));
            usr.Init(userBindingSource);
            

        }

        private void button1_Click(object sender, EventArgs e)
        {

            usr.addUser();

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\MyCSV\user.csv"))
            {
                //this.Hide();
                Form1 form = new Form1();
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                Form2 f2 = new Form2();
                f2.Location = this.Location;
                f2.Show();
            }
            else
            { userBindingSource.DataSource = new List<user>(); }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            Form3 f3 = new Form3();
            f3.Location = this.Location;
            f3.Show();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.Location = this.Location;
            f4.Show();
        }

       
    }
}
