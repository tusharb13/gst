using CsvHelper;
//using DGVPrinterHelper;
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
using WindowsFormsApp4.Properties;

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
        private Bitmap bitmap;

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
            
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

		}

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Image img = Resources.logo;
            e.Graphics.DrawImage(img, 300, 0,img.Width,img.Height);
            e.Graphics.DrawString("Date :" + DateTime.Now, new Font("Arial", 12, FontStyle.Regular),Brushes.Black,new Point(20,90));
            e.Graphics.DrawString("" + label1.Text, new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(400, 130));
            e.Graphics.DrawString("" + label2.Text, new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(300, 160));
            e.Graphics.DrawString("Customer Name :" + combobox1.Text, new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(20, 230));
            e.Graphics.DrawString("Designation :" + textbox1.Text, new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(20, 300));
            e.Graphics.DrawString("Street :" + textbox3.Text, new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(475, 230));
            e.Graphics.DrawString("City :" + textbox4.Text, new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(475,300));

            //Resize DataGridView to full height.
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height;

            //Create a Bitmap and draw the DataGridView on it.
            bitmap = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));

            //Resize DataGridView back to original height.
            dataGridView1.Height = height;
            e.Graphics.DrawImage(bitmap, 20, 400);
            e.Graphics.DrawString("Total Price :" + textbox2.Text, new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(625, 450));

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
		  		DataGridView dgv = sender as DataGridView;
				
				if (dgv.CurrentCellAddress.X == 0)
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
							if (Convert.ToString(dataGridView1.Rows[dgv.CurrentCellAddress.Y].Cells[0].Value) == values[1])
							{                                                             
															 
								dataGridView1.Rows[dgv.CurrentCellAddress.Y].Cells[1].Value = values[2];
								dataGridView1.Rows[dgv.CurrentCellAddress.Y].Cells[2].Value = values[3];
								
								break;
							   
							}
							
						}
					   
					}
					useChanged = true;
					// end
				}
				else if (dgv.CurrentCellAddress.X == 3)
				{   
                    useChanged = false;
                    try
                    {
                        var unitPrice = float.Parse(dataGridView1.Rows[dgv.CurrentCellAddress.Y].Cells[1].Value.ToString());
                        var gst = float.Parse(dataGridView1.Rows[dgv.CurrentCellAddress.Y].Cells[2].Value.ToString());
                        var quantity = float.Parse(dataGridView1.Rows[dgv.CurrentCellAddress.Y].Cells[3].Value.ToString());
                        dataGridView1.Rows[dgv.CurrentCellAddress.Y].Cells[4].Value = quantity * (unitPrice + (unitPrice * gst / 100));
                        useChanged = true;
                        isr.computeSum();
                    }
                    catch(Exception str)
                    {
                        MessageBox.Show("Invalid Values");
                    }
                    
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
