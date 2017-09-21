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
    public partial class Form7 : Form
    {
        public BindingSource userbindingsource;
        userRegisteration usr = new userRegisteration();
        public Form7()
        {
            InitializeComponent();
            userbindingsource = userBindingSource;
            dataGridView1.DataBindings.Add(nameof(DataGrid.BackgroundColor), this, nameof(Control.BackColor));
        }

       private void button2_Click(object sender, EventArgs e)
        {
            usr.editUser(this);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        

        private void Form7_Load(object sender, EventArgs e)
        {
            usr.readUser(this);
     
        }
    }
}
