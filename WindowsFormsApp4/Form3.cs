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
		public Form3()
		{
			InitializeComponent();
            dataGridView1.DataBindings.Add(nameof(DataGrid.BackgroundColor), this, nameof(Control.BackColor));
        }

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
            var x = customerBindingSource.DataSource as List<customer>;
            
            var FileName = @"C:\MyCSV\customer.csv";
            if (!Directory.Exists(@"C:\MyCSV\"))
            {
                Directory.CreateDirectory(@"C:\MyCSV\");
            }
            using (var sw = new StreamWriter(FileName,true))
			{
				var writer = new CsvWriter(sw);
                if (new FileInfo(FileName).Length == 0)
					writer.WriteHeader(typeof(customer));
						
				foreach (customer c in customerBindingSource.DataSource as List<customer>)
				{
							
					writer.WriteRecord(c);
				}
			}
			MessageBox.Show("Entered succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
				
		}

		private void Form3_Load(object sender, EventArgs e)
		{
			customerBindingSource.DataSource = new List<customer>();
			
		}

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
