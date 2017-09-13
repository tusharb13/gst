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
        public Form5()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader (@"C:\MyCSV\customer.csv")  )
            {
                var csv = new CsvReader(sr);
                customerBindingSource.DataSource = csv.GetRecords<customer>();
                sr.Close();
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            customerBindingSource.DataSource = new List<customer>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            var ls = this.customerBindingSource.List;
            var FileName = @"C:\MyCSV\customer.csv";
            if (!Directory.Exists(@"C:\MyCSV\"))
            {
                Directory.CreateDirectory(@"C:\MyCSV\");
            }
            using (var sw = new StreamWriter(FileName))
                    {
                        var writer = new CsvWriter(sw);
                        writer.WriteHeader(typeof(customer));
                        foreach (customer c in ls)
                        {
                            writer.WriteRecord(c);
                        }
                    }
                    MessageBox.Show("Entered succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
