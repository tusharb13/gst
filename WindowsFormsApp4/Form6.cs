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
    public partial class Form6 : Form
    {
        public BindingSource itemsbindingsource;
        itemsRegistration itsr = new itemsRegistration();
        public Form6()
        {
            InitializeComponent();
            itemsbindingsource = bindingSource1;
            dataGridView1.DataBindings.Add(nameof(DataGrid.BackgroundColor), this, nameof(Control.BackColor));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            itsr.editItems(this);
            
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            itsr.readItems(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

       
    }
}
