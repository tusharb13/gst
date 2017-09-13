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
		public Form2()
		{
			useChanged = false;
			InitializeComponent();
            dataGridView1.DataBindings.Add(nameof(DataGrid.BackgroundColor),this,nameof(Control.BackColor));
            fillLabel();
			populateCombo();
			useChanged = true;
		}

		private void customerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Hide();
			Form3 f3 = new Form3();
			f3.Show();

		}

		private void itemToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Hide();
			Form4 f4 = new Form4();
			f4.Show();

		}

		private void itemToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.Hide();
			Form6 f6 = new Form6();
			f6.Show();
		}

		private void sellerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Hide();
			Form7 f7 = new Form7();
			f7.Show();

		}

		private void button1_Click(object sender, EventArgs e)
		{
            printDialog1.Document = printDocument1;
            if(printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }

		}

		public void fillLabel()
		{
			using (StreamReader sr = new StreamReader((@"C:\MyCSV\customer.csv")))
			{

				if (!sr.EndOfStream)
					sr.ReadLine();
				while (!sr.EndOfStream)
				{
					string line = sr.ReadLine(); //.Trim('"');
					string[] values = line.Split(',');
					label1.Text = values[1].Trim('"');
					label2.Text = values[2].Trim('"');

				}
			}

		}

		public void populateCombo()
		{
			using (StreamReader sr = new StreamReader((@"C:\MyCSV\user.csv")))
			{

				if (!sr.EndOfStream)
					sr.ReadLine();
				while (!sr.EndOfStream)
				{
					string line = sr.ReadLine(); //.Trim('"');
					string[] values = line.Split(',');
					comboBox1.Items.Add(values[1].Trim('"'));
				   

				}
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			using (StreamReader sr = new StreamReader((@"C:\MyCSV\user.csv")))
			{

				if (!sr.EndOfStream)
					sr.ReadLine();
				while (!sr.EndOfStream)
				{
					string line = sr.ReadLine(); //.Trim('"');
					string[] values = line.Split(',');
					
					if(comboBox1.Text == values[1])
					{
						textBox1.Text = Convert.ToString(values[2]);
					}


				}
			}
			
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		   
		}

		private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			string titleText = dataGridView1.Columns[0].HeaderText;
			if (titleText.Equals("ProductName"))
			{
				TextBox autoText = e.Control as TextBox;
				if (autoText != null)
				{
					autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
					autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
					AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
					addItems(DataCollection);
					autoText.AutoCompleteCustomSource = DataCollection;
				}
			}
		}
		public void addItems(AutoCompleteStringCollection col)
		{
			using (StreamReader sr = new StreamReader((@"C:\MyCSV\items.csv")))
			{

				if (!sr.EndOfStream)
					sr.ReadLine();
				while (!sr.EndOfStream)
				{
					string line = sr.ReadLine(); //.Trim('"');
					string[] values = line.Split(',');
					col.Add(values[1].ToString());
					

				}
			}
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
                    computeSum();
				}
			}
		}

        void computeSum()
        {
            var y = dataGridView1.RowCount - 1;
            float sum = 0;
            for (int i=0;i<y;++i)
            {
                sum += float.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
            }
            this.textBox2.Text = sum.ToString();
        }

		private void Form2_Load(object sender, EventArgs e)
		{

		}

        private void customerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 f5 = new Form5();
            f5.Show();
        }
    }
}
