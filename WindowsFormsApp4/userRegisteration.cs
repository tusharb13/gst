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
    class userRegisteration
    {
        BindingSource userBindingSource;
        public void Init(BindingSource a)
        {
            userBindingSource = a;
        }
        public void addUser()
        {
           
            var FileName = @"C:\MyCSV\user.csv";
            if (!Directory.Exists(@"C:\MyCSV\"))
            {
                Directory.CreateDirectory(@"C:\MyCSV\");
            }

            using (var sw = new StreamWriter(FileName))
            {
                var writer = new CsvWriter(sw);
                if (new FileInfo(FileName).Length == 0)
                    writer.WriteHeader(typeof(user));
                foreach (user u in userBindingSource.DataSource as List<user>)
                {
                    writer.WriteRecord(u);
                }
            }
            MessageBox.Show("Entered succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void readUser(Form7 f7)
        {
            using (StreamReader sr = new StreamReader(@"C:\MyCSV\user.csv"))
            {
                var csv = new CsvReader(sr);
                f7.userbindingsource.DataSource = csv.GetRecords<user>();
                sr.Close();
            }
        }

        public void editUser(Form7 f7)
        {
            var ls = f7.userbindingsource.List;
            var FileName = @"C:\MyCSV\user.csv";
            if (!Directory.Exists(@"C:\MyCSV\"))
            {
                Directory.CreateDirectory(@"C:\MyCSV\");
            }
            using (var sw = new StreamWriter(FileName))
            {
                var writer = new CsvWriter(sw);
                writer.WriteHeader(typeof(user));
                foreach (user c in ls)
                {
                    writer.WriteRecord(c);
                }
            }
            MessageBox.Show("Entered succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        


    }
}
