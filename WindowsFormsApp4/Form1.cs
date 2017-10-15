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
        public TextBox textbox2;
        public TextBox textbox3;
        public TextBox textbox4;
        public TextBox textbox5;
        public TextBox textbox6;
        public TextBox textbox7;
        public TextBox textbox8;
        public TextBox textbox9;
        public TextBox textbox10;
        public TextBox textbox11;
        public TextBox textbox12;
        public TextBox textbox13;
        public TextBox textbox14;
        public TextBox textbox15;
        public Button buttonSave;
        public Form1()
        {
            InitializeComponent();
            //dataGridView1.DataBindings.Add(nameof(DataGrid.BackgroundColor), this, nameof(Control.BackColor));
            textbox2 = textBox2;
            textbox3 = textBox3;
            textbox4 = textBox4;
            textbox5 = textBox5;
            textbox6 = textBox6;
            textbox7 = textBox7;
            textbox8 = textBox8;
            textbox9 = textBox9;
            textbox10 = textBox10;
            textbox11 = textBox11;
            textbox12 = textBox12;
            textbox13 = textBox13;
            textbox14 = textBox14;
            textbox15 = textBox15;
            buttonSave = button1;
            usr.Init(this);
            

        }

        private void button1_Click(object sender, EventArgs e)
        {

            usr.addUser();

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\MyCSV\user.csv"))
            {
                
                Form1 form = new Form1();
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                this.Hide();
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        
    }
}
