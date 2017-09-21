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
	public partial class Form2 : Form
	{
		bool useChanged;
        Bitmap bmp;
        invoiceRegisteration isr = new invoiceRegisteration();

        public ComboBox combobox1;
        public TextBox textbox1;
        public TextBox textbox2;
        public TextBox textbox3;
        public TextBox textbox4;
        public Label label1obj;
        public Label label2obj;
        public BindingSource invoicebindingsource;
        public DateTimePicker datetimepicker1;
        public DataGridView  datagridview1;

        public Form2()
		{
			useChanged = false;
			InitializeComponent();
            dataGridView1.DataBindings.Add(nameof(DataGrid.BackgroundColor), this, nameof(Control.BackColor));

            combobox1 = comboBox1;
            invoicebindingsource = invoiceBindingSource;
            datetimepicker1 = dateTimePicker1;
            datagridview1 = dataGridView1;
            textbox1 = textBox1;
            textbox2 = textBox2;
            textbox3 = textBox3;
            textbox4 = textBox4;
            label1obj = label1;
            label2obj = label2;

            isr.Init(this);
            isr.fillLabel();
			isr.populateCombo();

            useChanged = true;

		}

		private void customerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Hide();
			Form3 f3 = new Form3();
            f3.Location = this.Location;
			f3.Show();

		}

		private void itemToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Hide();
			Form4 f4 = new Form4();
            f4.Location = this.Location;
			f4.Show();

		}

		private void itemToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.Hide();
			Form6 f6 = new Form6();
            f6.Location= this.Location;
            f6.Show();
		}

		private void sellerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Hide();
			Form7 f7 = new Form7();
            f7.Location = this.Location;
            f7.Show();

		}

        private void invoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 f8 = new Form8();
            f8.Location = this.Location;
            f8.Show();


        }

        private void customerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f5 = new Form5();
            f5.Location = this.Location;
            f5.Show();
        }


        private void button1_Click(object sender, EventArgs e)
		{
            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(this.Size.Width, this.Size.Height,g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y,0,0,this.Size);
            printPreviewDialog1.ShowDialog();

		}

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }





        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
            isr.comboBoxIndexChange();
			
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		   
		}

		private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
            isr.autoFillGrid(e);
		}

        

		private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (useChanged)
			{
				DataGridView a = sender as DataGridView;
				
				if (a.CurrentCellAddress.X == 0)
				{
					useChanged = false;
					// start
					using (StreamReader sr = new StreamReader((@"C:\MyCSV\items.csv")))
					{
						if (!sr.EndOfStream)
							sr.ReadLine();
						while (!sr.EndOfStream)
						{
							string line = sr.ReadLine(); //.Trim('"');
							string[] values = line.Split(',');
							if (Convert.ToString(dataGridView1.Rows[a.CurrentCellAddress.Y].Cells[0].Value) == values[1])
							{                                                             
															 
								dataGridView1.Rows[a.CurrentCellAddress.Y].Cells[1].Value = values[2];
								dataGridView1.Rows[a.CurrentCellAddress.Y].Cells[2].Value = values[3];
								var abc = a.CurrentCellAddress.X;
								var ab = a.CurrentCellAddress.Y;
								break;
							   // (float.Parse(values[2]) + (float.Parse(values[2]) * float.Parse(values[3]) / 100));
							}
							
						}
					   
					}
					useChanged = true;
					// end
				}
				else if (a.CurrentCellAddress.X == 3)
				{
                    useChanged = false;
                    var unitPrice = float.Parse(dataGridView1.Rows[a.CurrentCellAddress.Y].Cells[1].Value.ToString());
                    var gst = float.Parse(dataGridView1.Rows[a.CurrentCellAddress.Y].Cells[2].Value.ToString());
                    var quantity = float.Parse(dataGridView1.Rows[a.CurrentCellAddress.Y].Cells[3].Value.ToString());
                    dataGridView1.Rows[a.CurrentCellAddress.Y].Cells[4].Value = quantity*(unitPrice+(unitPrice*gst/100));
                    useChanged = true;
                    isr.computeSum();
				}
			}
		}

        

		

        
        private void Form2_Load(object sender, EventArgs e)
        {
            invoiceBindingSource.DataSource = new List<invoice>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isr.saveInvoice();
        }

        

       
    }
}
