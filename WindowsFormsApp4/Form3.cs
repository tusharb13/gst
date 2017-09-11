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
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
            var x = customerBindingSource.DataSource as List<customer>;
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv", ValidateNames = true })
			{
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					using (var sw = new StreamWriter(sfd.FileName,true))
					{
						var writer = new CsvWriter(sw);
                        if (new FileInfo(sfd.FileName).Length == 0)
							writer.WriteHeader(typeof(customer));
						
						foreach (customer c in customerBindingSource.DataSource as List<customer>)
						{
							
							writer.WriteRecord(c);
						}
					}
					MessageBox.Show("Entered succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

			}
		}

		private void Form3_Load(object sender, EventArgs e)
		{
			customerBindingSource.DataSource = new List<customer>();
			
		}
	}
}
