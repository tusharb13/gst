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
		public Form8()
		{
			InitializeComponent();
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
				customerSearch(text);
			}
            else if(radioButton2.Checked==true)
            {
                string text = textBox1.Text.ToString();
                productSearch(text);
            }
			else if(dateTimePicker1.Visible==true)
			{
                textBox1.Visible = false;
                string text = dateTimePicker1.Text.ToString();
                dateSearch(text);
               
            }
		}

		void customerSearch(String searchName)
		{
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            using (var reader = new StreamReader(@"C:\MyCSV\invoice.csv"))
			{

				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					break;
				}
				int index = 0;
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					var values = line.Split(',');
					var abc = values[0];
					if (values[0].Equals(searchName))
					{
						dataGridView1.Rows.Add();
						dataGridView1.Rows[index].Cells[0].Value = values[0].ToString();
                        dataGridView1.Rows[index].Cells[1].Value = values[1].ToString();
                        dataGridView1.Rows[index].Cells[2].Value = values[2].ToString();
                        dataGridView1.Rows[index].Cells[3].Value = values[3].ToString();
                        dataGridView1.Rows[index].Cells[4].Value = values[4].ToString();
                        dataGridView1.Rows[index].Cells[5].Value = values[5].ToString();
                        dataGridView1.Rows[index].Cells[6].Value = values[9].ToString();
                        
                        index++;
						
					}

				}
			}
		}

        void productSearch(String text)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            using (var reader = new StreamReader(@"C:\MyCSV\invoice.csv"))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    break;
                }
                int index = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    var abc = values[0];
                    if (values[1].Equals(text))
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[index].Cells[0].Value = values[0].ToString();
                        dataGridView1.Rows[index].Cells[1].Value = values[1].ToString();
                        dataGridView1.Rows[index].Cells[2].Value = values[2].ToString();
                        dataGridView1.Rows[index].Cells[3].Value = values[3].ToString();
                        dataGridView1.Rows[index].Cells[4].Value = values[4].ToString();
                        dataGridView1.Rows[index].Cells[5].Value = values[5].ToString();
                        dataGridView1.Rows[index].Cells[6].Value = values[9].ToString();

                        index++;

                    }

                }
            }
        }

        void dateSearch(string text)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            using (var reader = new StreamReader(@"C:\MyCSV\invoice.csv"))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    break;
                }
                int index = 0;
                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (line.Contains(text))
                    {

                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[index].Cells[0].Value = values[0].ToString();
                        dataGridView1.Rows[index].Cells[1].Value = values[1].ToString();
                        dataGridView1.Rows[index].Cells[2].Value = values[2].ToString();
                        dataGridView1.Rows[index].Cells[3].Value = values[3].ToString();
                        dataGridView1.Rows[index].Cells[4].Value = values[4].ToString();
                        dataGridView1.Rows[index].Cells[5].Value = values[5].ToString();
                        dataGridView1.Rows[index].Cells[6].Value = values[9].ToString();
                        index++;

                    }

                }
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
