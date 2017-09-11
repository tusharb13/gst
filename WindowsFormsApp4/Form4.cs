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
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var sw = new StreamWriter(sfd.FileName))
                    {
                        var writer = new CsvWriter(sw);
                        if (new FileInfo(sfd.FileName).Length == 0)
                            writer.WriteHeader(typeof(items));
                        foreach (items i in itemsBindingSource.DataSource as List<items>)
                        {
                            writer.WriteRecord(i);
                        }
                    }
                    MessageBox.Show("Entered succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            itemsBindingSource.DataSource = new List<items>();
        }
    }
}
