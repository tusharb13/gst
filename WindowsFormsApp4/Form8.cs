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
            if(textBox1.Visible==true)
            {
                string text = textBox1.Text.ToString();
                GetAddress(text);
            }
            else if(dateTimePicker1.Visible==true)
            {

            }
        }

        void GetAddress(String searchName)
        {
            using(var reader = new StreamReader(@"C:\MyCSV\invoice.csv"))
            {
                                
            while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    break;                             
                }
                while (!reader.EndOfStream)
                {
                    var lineCount = File.ReadLines(@"C:\MyCSV\invoice.csv").Count();
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    for (int i = 0,index=0; i < lineCount; i++)
                    {   
                                      
                        if (values[0].Equals(searchName))
                        {
                            string a = values[1].ToString();
                            dataGridView1.Rows[index].Cells[0].Value = values[1].ToString();
                            dataGridView1.Rows.Add();
                            index++;
                            break;
                        }

                    }
                }
            }   
    
        }
    }
}
