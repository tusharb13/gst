using CsvHelper;
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

namespace WindowsFormsApp4
{
	public partial class Form3 : Form
	{
        public BindingSource customerbindingsource;
        customerRegistration csr = new customerRegistration();
        public TextBox textbox1;
        public TextBox textbox2;
        public TextBox textbox3;
        public TextBox textbox4;
        public TextBox textbox5;
        public TextBox textbox6;
        public TextBox textbox7;
        public TextBox textbox8;
        public Form3()
		{
			InitializeComponent();
            customerbindingsource = customerBindingSource;
            textbox1 = textBox1;
            textbox2 = textBox2;
            textbox3 = textBox3;
            textbox4 = textBox4;
            textbox5 = textBox5;
            textbox6 = textBox6;
            textbox7 = textBox7;
            textbox8 = textBox8;

            csr.Init(this);
            //dataGridView1.DataBindings.Add(nameof(DataGrid.BackgroundColor), this, nameof(Control.BackColor));
        }

		
		private void button1_Click(object sender, EventArgs e)
		{

            csr.saveCustomer();
		}

		private void Form3_Load(object sender, EventArgs e)
		{
			customerBindingSource.DataSource = new List<customer>();
			
		}

        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
