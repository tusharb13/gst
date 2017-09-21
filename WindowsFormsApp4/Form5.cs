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
    public partial class Form5 : Form
    {
        public BindingSource customerbindingsource;
        customerRegistration csr = new customerRegistration();
       
        public Form5()
        {
            InitializeComponent();
            customerbindingsource = customerBindingSource;
            dataGridView1.DataBindings.Add(nameof(DataGrid.BackgroundColor), this, nameof(Control.BackColor));
        }

       private void button2_Click(object sender, EventArgs e)
        {
            csr.editCustomer(this);

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            customerBindingSource.DataSource = new List<customer>();
            csr.readCustomer(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        
    }
}
