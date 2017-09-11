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
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "CSV|*.csv", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var sr = new StreamReader(new FileStream(ofd.FileName, FileMode.Open));
                    var csv = new CsvReader(sr);
                    itemsBindingSource.DataSource = csv.GetRecords<items>();
                    sr.Close();

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var ls = this.itemsBindingSource.List;
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var sw = new StreamWriter(sfd.FileName))
                    {
                        var writer = new CsvWriter(sw);
                        if (new FileInfo(sfd.FileName).Length == 0)
                            writer.WriteHeader(typeof(items));
                        foreach (items c in ls)
                        {
                            writer.WriteRecord(c);
                        }
                    }
                    MessageBox.Show("Entered succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }
    }
}
