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

		public Form3()
		{
			InitializeComponent();
            customerbindingsource = customerBindingSource;
            csr.Init(this);
            dataGridView1.DataBindings.Add(nameof(DataGrid.BackgroundColor), this, nameof(Control.BackColor));
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
    }
}
