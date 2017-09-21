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
	public partial class Form8 : Form
	{
        search sea = new search();
        public DataGridView datagridview1;
		public Form8()
		{   
			InitializeComponent();
            datagridview1 = dataGridView1;
            sea.Init(this);
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			if(radioButton1.Checked)
			{
                dateTimePicker1.Visible = false;
				label1.Text = "Enter Customer Name";
				label1.Show();
				textBox1.Show();
			}
		}

		private void Form8_Load(object sender, EventArgs e)
		{
			label1.Hide();
			textBox1.Hide();
			dateTimePicker1.Hide();

		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton2.Checked)
			{
                dateTimePicker1.Visible = false;
                label1.Text = "Enter Product Name";
				label1.Show();
				textBox1.Show();
			}
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton3.Checked)
			{
				label1.Text = "Enter Date";
				label1.Show();
				dateTimePicker1.Show();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			
			if(radioButton1.Checked==true)
			{
				string text = textBox1.Text.ToString();
				sea.customerSearch(text);
			}
            else if(radioButton2.Checked==true)
            {
                string text = textBox1.Text.ToString();
                sea.productSearch(text);
            }
			else if(dateTimePicker1.Visible==true)
			{
                textBox1.Visible = false;
                string text = dateTimePicker1.Text.ToString();
                sea.dateSearch(text);
               
            }
		}

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
