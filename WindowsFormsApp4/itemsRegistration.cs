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
    class itemsRegistration
    {
        Form4 Obj;

        public void Init(Form4 obj)
        {
            Obj = obj;
        }

        public void saveItems()
        {
            var FileName = @"C:\MyCSV\items.csv";
            if (!Directory.Exists(@"C:\MyCSV\"))
            {
                Directory.CreateDirectory(@"C:\MyCSV\");
            }
            using (var sw = new StreamWriter(FileName))
            {
                var writer = new CsvWriter(sw);
                if (new FileInfo(FileName).Length == 0)
                    writer.WriteHeader(typeof(items));
                foreach (items i in Obj.itemsbindingsource.DataSource as List<items>)
                {
                    writer.WriteRecord(i);
                }
            }
            MessageBox.Show("Entered succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void readItems(Form6 f6)
        {
            using (StreamReader sr = new StreamReader(@"C:\MyCSV\items.csv"))
            {
                var csv = new CsvReader(sr);
                f6.itemsbindingsource.DataSource = csv.GetRecords<items>();
                sr.Close();
            }
        }

        public void editItems(Form6 f6)
        {
            var ls = f6.itemsbindingsource.List;
            var FileName = @"C:\MyCSV\items.csv";
            if (!Directory.Exists(@"C:\MyCSV\"))
            {
                Directory.CreateDirectory(@"C:\MyCSV\");
            }
            using (var sw = new StreamWriter(FileName))
            {
                var writer = new CsvWriter(sw);
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
