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
    class customerRegistration
    {
        Form3 Obj;

        public void Init(Form3 obj)
        {
            Obj = obj;
            
        }

        public void saveCustomer()
        {
            var x = Obj.customerbindingsource.DataSource as List<customer>;

            var FileName = @"C:\MyCSV\customer.csv";
            if (!Directory.Exists(@"C:\MyCSV\"))
            {
                Directory.CreateDirectory(@"C:\MyCSV\");
            }
            using (var sw = new StreamWriter(FileName, true))
            {
                var writer = new CsvWriter(sw);
                if (new FileInfo(FileName).Length == 0)
                    writer.WriteHeader(typeof(customer));

                foreach (customer c in Obj.customerbindingsource.DataSource as List<customer>)
                {

                    writer.WriteRecord(c);
                }
            }
            MessageBox.Show("Entered succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void readCustomer(Form5 f5)
        {
            using (StreamReader sr = new StreamReader(@"C:\MyCSV\customer.csv"))
            {
                var csv = new CsvReader(sr);
                f5.customerbindingsource.DataSource = csv.GetRecords<customer>();
                sr.Close();
            }
        }

        public void editCustomer(Form5 f5)
        {
            var ls = f5.customerbindingsource.List;
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
    }
}
