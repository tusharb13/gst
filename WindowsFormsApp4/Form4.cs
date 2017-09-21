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
    public partial class Form4 : Form
    {
        public BindingSource itemsbindingsource;
        itemsRegistration itsr = new itemsRegistration();
        public Form4()
        {
            InitializeComponent();
            itemsbindingsource = itemsBindingSource;
            itsr.Init(this);
            dataGridView1.DataBindings.Add(nameof(DataGrid.BackgroundColor), this, nameof(Control.BackColor));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            itsr.saveItems();               

        }
        

        private void Form4_Load(object sender, EventArgs e)
        {
            itemsBindingSource.DataSource = new List<items>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
