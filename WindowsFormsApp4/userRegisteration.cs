using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApp4
{
    class userRegisteration
    {
        //BindingSource userBindingSource;
        Form1 Obj;
        public void Init(Form1 obj)
        {
            Obj = obj;

        }
        public void addUser()
        {
            if (validateAdd() == 1)
            {
                var FileName = @"C:\MyCSV\user.csv";
                using (var sw = new StreamWriter(FileName))
                {
                    var writer = new CsvWriter(sw);

                    writer.Configuration.HasHeaderRecord = false;
                    if (new FileInfo(FileName).Length == 0)

                        writer.Configuration.HasHeaderRecord = true;

                    List<user> ls = new List<user>();
                    ls.Add(new user(Obj.textbox2.Text, Obj.textbox3.Text, Obj.textbox4.Text, Obj.textbox5.Text, Obj.textbox6.Text, Obj.textbox7.Text, Obj.textbox8.Text, Obj.textbox9.Text, Obj.textbox10.Text, Obj.textbox11.Text, Obj.textbox12.Text, Obj.textbox13.Text, Obj.textbox14.Text, Obj.textbox15.Text));
                    writer.WriteRecords(ls);

                }
            MessageBox.Show("Entered succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Obj.buttonSave.Hide();
            }
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
            if (validateEdit(ls) == 1)
            {
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

        private int validateEdit(IList ls)
        {
            var length = ls.Count;
            float n;
            if (length == 1)
            {
                for (int i = 0; i < length; ++i)
                {
                    bool isNumericCompany = float.TryParse((ls[i] as user).Company, out n);
                    bool isNumericStreet = float.TryParse((ls[i] as user).Street, out n);
                    bool isNumericCity = float.TryParse((ls[i] as user).City, out n);
                    bool isNumericPIN = float.TryParse((ls[i] as user).PIN, out n);
                    bool isNumericState = float.TryParse((ls[i] as user).State, out n);
                    bool isNumericCountry = float.TryParse((ls[i] as user).Country, out n);
                    bool isNumericLocation = float.TryParse((ls[i] as user).Location, out n);
                    bool isNumericEmail = float.TryParse((ls[i] as user).email, out n);
                    bool isNumericPhone = float.TryParse((ls[i] as user).Phone, out n);
                    bool isNumericGSTIN = float.TryParse((ls[i] as user).GSTIN, out n);
                    bool isNumericBname = float.TryParse((ls[i] as user).BankName, out n);
                    bool isNumericBaccNo = float.TryParse((ls[i] as user).AccountNumber, out n);
                    bool isNumericBranch = float.TryParse((ls[i] as user).Branch, out n);
                    bool isNumericIFSC = float.TryParse((ls[i] as user).IFSCCode, out n);

                    if (isNumericCompany)
                    {
                        MessageBox.Show("Company can not be numeric");
                        return 0;
                    }
                    else if (isNumericCity)
                    {
                        MessageBox.Show("City can not be numeric");
                        return 0;
                    }
                    else if (!isNumericPIN)
                    {
                        MessageBox.Show("PIN should be numeric");
                        return 0;
                    }
                    else if (isNumericState)
                    {
                        MessageBox.Show("State can not be numeric");
                        return 0;
                    }
                    else if (isNumericCountry)
                    {
                        MessageBox.Show("Country can not be numeric");
                        return 0;
                    }
                    else if (isNumericEmail)
                    {
                        MessageBox.Show("Email can not be numeric");
                        return 0;
                    }
                    else if (!isNumericPhone)
                    {
                        MessageBox.Show("Phone should be numeric");
                        return 0;
                    }
                    else if (isNumericBname)
                    {
                        MessageBox.Show("Bank Name can not be numeric");
                        return 0;
                    }
                    else if (isNumericBranch)
                    {
                        MessageBox.Show("Branch can not be numeric");
                        return 0;
                    }


                    else if ((ls[i] as user).Company == null || (ls[i] as user).City == null || (ls[i] as user).Street == null || (ls[i] as user).PIN == null || (ls[i] as user).State == null || (ls[i] as user).Country == null || (ls[i] as user).Location == null || (ls[i] as user).email == null || (ls[i] as user).Phone == null || (ls[i] as user).GSTIN == null|| (ls[i] as user).BankName == null|| (ls[i] as user).AccountNumber == null|| (ls[i] as user).Branch == null|| (ls[i] as user).IFSCCode == null)
                    {
                        MessageBox.Show("Fields can not be empty");
                        return 0;
                    }
                }
            }
        
            
            return 1;
        }

        public int validateAdd()
        {
            float n;
            bool isNumericCompany = float.TryParse(Obj.textbox2.Text, out n);
            bool isNumericStreet = float.TryParse(Obj.textbox3.Text, out n);
            bool isNumericCity = float.TryParse(Obj.textbox4.Text, out n);
            bool isNumericPIN = float.TryParse(Obj.textbox5.Text, out n);
            bool isNumericState = float.TryParse(Obj.textbox6.Text, out n);
            bool isNumericCountry = float.TryParse(Obj.textbox7.Text, out n);
            bool isNumericLocation = float.TryParse(Obj.textbox8.Text, out n);
            bool isNumericEmail = float.TryParse(Obj.textbox9.Text, out n);
            bool isNumericPhone = float.TryParse(Obj.textbox10.Text, out n);
            bool isNumericGSTIN = float.TryParse(Obj.textbox11.Text, out n);
            bool isNumericBName = float.TryParse(Obj.textbox12.Text, out n);
            bool isNumericBAccNo = float.TryParse(Obj.textbox13.Text, out n);
            bool isNumericBranch = float.TryParse(Obj.textbox14.Text, out n);
            bool isNumericIFSC = float.TryParse(Obj.textbox15.Text, out n);

            var FileName = @"C:\MyCSV\user.csv";
            if (!Directory.Exists(@"C:\MyCSV\"))
            {
                Directory.CreateDirectory(@"C:\MyCSV\");
            }

            using (var sw = new StreamWriter(FileName, append: true))
            {
                var writer = new CsvWriter(sw);
                if (new FileInfo(FileName).Length == 0)
                    writer.WriteHeader(typeof(user));
                
            }

            using (StreamReader sr = new StreamReader(@"C:\MyCSV\user.csv"))
            {
                var csv = new CsvReader(sr);
                var records = csv.GetRecords<user>();

                if (records.Count() == 0)
                {
                    if (Obj.textbox2.TextLength == 0)
                    {
                        MessageBox.Show("Company Name can not be empty");
                        return 0;

                    }
                    else if (Obj.textbox3.TextLength == 0)
                    {
                        MessageBox.Show("Street can not be empty");
                        return 0;

                    }
                    else if (Obj.textbox4.TextLength == 0 || isNumericCity)
                    {
                        MessageBox.Show("City can not be empty or numeric");
                        return 0;
                    }
                    else if (Obj.textbox5.TextLength == 0 || !isNumericPIN || Obj.textbox5.TextLength>6|| Obj.textbox5.TextLength < 6)
                    {
                        MessageBox.Show("PIN can not be empty or non numeric and should be of 6 digits");
                        return 0;
                    }
                    else if (Obj.textbox6.TextLength == 0 || isNumericState)
                    {
                        MessageBox.Show("State can not be empty or numeric");
                        return 0;
                    }
                    else if (Obj.textbox7.TextLength == 0 || isNumericCountry)
                    {
                        MessageBox.Show("Country can not be empty or numeric");
                        return 0;
                    }
                    else if (Obj.textbox8.TextLength == 0 )
                    {
                        MessageBox.Show("Location can not be empty");
                        return 0;
                    }
                    //else if (Obj.textbox9.TextLength == 0 )
                    //{
                    //    MessageBox.Show("PIN can not be empty or non numeric");
                    //    return 0;
                    //}
                    else if (Obj.textbox10.TextLength == 0 || !isNumericPhone || Obj.textbox10.TextLength>10|| Obj.textbox10.TextLength < 10)
                    {
                        MessageBox.Show("Phone number can not be empty or non numeric and should be of 10 digits");
                        return 0;
                    }
                    else if (Obj.textbox11.TextLength == 0)
                    {
                        MessageBox.Show("GSTIN can not be empty");
                        return 0;
                    }
                    else if (Obj.textbox12.TextLength == 0 || isNumericBName)
                    {
                        MessageBox.Show("Bank Name can not be empty or numeric");
                        return 0;
                    }
                    else if (Obj.textbox13.TextLength == 0 || !isNumericBAccNo )
                    {
                        MessageBox.Show("Account Number can not be empty or non numeric");
                        return 0;
                    }
                    else if (Obj.textbox14.TextLength == 0)
                    {
                        MessageBox.Show("Branch can not be empty");
                        return 0;
                    }
                    else if (Obj.textbox15.TextLength == 0 )
                    {
                        MessageBox.Show("IFSC Code can not be empty");
                        return 0;
                    }
                    return 1;
                }
            }
            

            return 1;
        }

    }
}
