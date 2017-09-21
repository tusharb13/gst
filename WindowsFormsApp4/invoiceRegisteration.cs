using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    class invoiceRegisteration
    {
        Form2 Obj;
        
        public void Init(Form2 obj)
        {
            Obj = obj;
            ;
        }

       

        public void saveInvoice()
        {
            var FileName = @"C:\MyCSV\invoice.csv";
            if (!Directory.Exists(@"C:\MyCSV\"))
            {
                Directory.CreateDirectory(@"C:\MyCSV\");
            }
            var nolines = 0;
            using (var sw = new StreamWriter(FileName, true))
            {
                var writer = new CsvWriter(sw);
                if (new FileInfo(FileName).Length == 0)
                    writer.WriteHeader(typeof(invoice));
                foreach (invoice i in Obj.invoicebindingsource.DataSource as List<invoice>)
                {
                    writer.WriteRecord(i);
                    nolines += 1;
                }
            }
            bool firstLine = true;
            List<string> ls = new List<string>();
            var x = File.ReadAllLines(FileName);
            var firsttime = false;
            if ((nolines + 1) == x.Length)
                firsttime = true;
            if (firsttime)
            {
                foreach (var line in x)
                {
                    if (firstLine)
                    {
                        ls.Add("CustomerName," + line + ",Date,TotalPrice");
                        firstLine = false;
                    }
                    else
                    {
                        ls.Add(Obj.combobox1.Text.ToString() + "," + line + ",\"" + Obj.datetimepicker1.Text.ToString() + "\"," + Obj.textbox2.Text.ToString());
                    }
                }
            }
            else
            {
                for (int i = 0; i < x.Length; ++i)
                {
                    if (i < (x.Length - nolines))
                    {
                        ls.Add(x[i]);
                    }
                    else
                    {
                        ls.Add(Obj.combobox1.Text.ToString() + "," + x[i] + ",\"" + Obj.datetimepicker1.Text.ToString() + "\"," + Obj.textbox2.Text.ToString());
                    }
                }
            }
            File.WriteAllLines(FileName, ls);
            MessageBox.Show("Entered succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void computeSum()
        {
            var y = Obj.datagridview1.RowCount - 1;
            float sum = 0;
            for (int i = 0; i < y; ++i)
            {
                sum += float.Parse(Obj.datagridview1.Rows[i].Cells[4].Value.ToString());
            }
            Obj.textbox2.Text = sum.ToString();
        }

        public void fillLabel()
        {
            using (StreamReader sr = new StreamReader((@"C:\MyCSV\user.csv")))
            {

                if (!sr.EndOfStream)
                    sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine(); //.Trim('"');
                    string[] values = line.Split(',');
                    Obj.label1obj.Text = values[1].Trim('"');
                    Obj.label2obj.Text = values[2].Trim('"') + "," + values[3].Trim('"');

                }
            }

        }

        public void populateCombo()
        {
            using (StreamReader sr = new StreamReader((@"C:\MyCSV\customer.csv")))
            {

                if (!sr.EndOfStream)
                    sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine(); //.Trim('"');
                    string[] values = line.Split(',');
                    Obj.combobox1.Items.Add(values[1].Trim('"'));


                }
            }
        }

        public void comboBoxIndexChange()
        {
            using (StreamReader sr = new StreamReader((@"C:\MyCSV\customer.csv")))
            {

                if (!sr.EndOfStream)
                    sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine(); //.Trim('"');
                    string[] values = line.Split(',');

                    if (Obj.combobox1.Text == values[1])
                    {
                        Obj.textbox1.Text = Convert.ToString(values[2]);
                        Obj.textbox3.Text = values[4].ToString();
                        Obj.textbox4.Text = values[5].ToString();
                    }


                }
            }
        }

        public void autoFillGrid(DataGridViewEditingControlShowingEventArgs e)
        {
            string titleText = Obj.datagridview1.Columns[0].HeaderText;
            if (titleText.Equals("ProductName"))
            {
                TextBox autoText = e.Control as TextBox;
                if (autoText != null)
                {
                    autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
                    autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
                    addItems(DataCollection);
                    autoText.AutoCompleteCustomSource = DataCollection;
                }
            }
        }

        public void addItems(AutoCompleteStringCollection col)
        {
            using (StreamReader sr = new StreamReader((@"C:\MyCSV\items.csv")))
            {

                if (!sr.EndOfStream)
                    sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine(); //.Trim('"');
                    string[] values = line.Split(',');
                    col.Add(values[1].ToString());


                }
            }
        }



    }


}
