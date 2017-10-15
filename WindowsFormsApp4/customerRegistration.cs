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
    class customerRegistration
    {
        Form3 Obj;

        public void Init(Form3 obj)
        {
            Obj = obj;
            
        }

        public void saveCustomer()
        {
            if (validateAdd() == 1)
            {
                var FileName = @"C:\MyCSV\customer.csv";
                
                using (var sw = new StreamWriter(FileName, append: true))
                {
                    var writer = new CsvWriter(sw);

                    writer.Configuration.HasHeaderRecord = false;
                    if (new FileInfo(FileName).Length == 0)
                        //writer.WriteHeader(typeof(user));
                        writer.Configuration.HasHeaderRecord = true;

                    List<customer> ls = new List<customer>();
                    ls.Add(new customer(Obj.textbox1.Text, Obj.textbox2.Text, Obj.textbox3.Text, Obj.textbox4.Text, Obj.textbox5.Text, Obj.textbox6.Text, Obj.textbox7.Text, Obj.textbox8.Text));
                    writer.WriteRecords(ls);

                }
                MessageBox.Show("Entered succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Obj.textbox1.Clear();
                Obj.textbox2.Clear();
                Obj.textbox3.Clear();
                Obj.textbox4.Clear();
                Obj.textbox5.Clear();
                Obj.textbox6.Clear();
                Obj.textbox7.Clear();
                Obj.textbox8.Clear();

            }

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
            if (validateEdit(ls) == 1)
            {
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

        private int validateEdit(IList ls)
        {
            var length = ls.Count;
            float n;
            if (length == 1)
            {
                for (int i = 0; i < length; ++i)
                {
                    bool isNumericCustomerName = float.TryParse((ls[i] as customer).CustomerName, out n);
                    bool isNumericDesignation = float.TryParse((ls[i] as customer).Designation, out n);
                    bool isNumericDepartment = float.TryParse((ls[i] as customer).Department, out n);
                    bool isNumericCity = float.TryParse((ls[i] as customer).City, out n);
                    bool isNumericPIN = float.TryParse((ls[i] as customer).PIN, out n);
                    bool isNumericPIFO = float.TryParse((ls[i] as customer).PaymentInFavourOf, out n);

                    if (isNumericCustomerName)
                    {
                        MessageBox.Show("Customer Name can not be numeric");
                        return 0;
                    }
                    else if (isNumericDesignation)
                    {
                        MessageBox.Show("Designtaion can not be numeric");
                        return 0;
                    }
                    else if (isNumericDepartment)
                    {
                        MessageBox.Show("Department can not be numeric");
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
                    else if (isNumericPIFO)
                    {
                        MessageBox.Show("Payment in favor of can not be numeric");
                        return 0;
                    }
                    else if ((ls[i] as customer).CustomerID == null || (ls[i] as customer).CustomerName == null || (ls[i] as customer).PaymentInFavourOf == null)
                    {
                        MessageBox.Show("Fields can not be empty");
                        return 0;
                    }
                }
            }
            else
            {

                for (int i = 0; i < length; ++i)
                {
                    bool isNumericCustomerName = float.TryParse((ls[i] as customer).CustomerName, out n);
                    bool isNumericDesignation = float.TryParse((ls[i] as customer).Designation, out n);
                    bool isNumericDepartment = float.TryParse((ls[i] as customer).Department, out n);
                    bool isNumericCity = float.TryParse((ls[i] as customer).City, out n);
                    bool isNumericPIN = float.TryParse((ls[i] as customer).PIN, out n);
                    bool isNumericPIFO = float.TryParse((ls[i] as customer).PaymentInFavourOf, out n);

                    for (int j = i; j < length; ++j)
                    {
                        if ((ls[i] as customer).CustomerID == (ls[j] as customer).CustomerID)
                        {
                            MessageBox.Show("Customer ID exists");
                            return 0;
                        }
                        if ((ls[i] as customer).CustomerName == (ls[j] as customer).CustomerName)
                        {
                            MessageBox.Show("Customer Name exists");
                            return 0;
                        }
                        else if (isNumericCustomerName)
                        {
                            MessageBox.Show("Customer Name can not be numeric");
                            return 0;
                        }
                        else if (isNumericDesignation)
                        {
                            MessageBox.Show("Designtaion can not be numeric");
                            return 0;
                        }
                        else if (isNumericDepartment)
                        {
                            MessageBox.Show("Department can not be numeric");
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
                        else if (isNumericPIFO)
                        {
                            MessageBox.Show("Payment in favor of can not be numeric");
                            return 0;
                        }
                        else if ((ls[i] as customer).CustomerID == null || (ls[i] as customer).CustomerName == null || (ls[i] as customer).PaymentInFavourOf == null)
                        {
                            MessageBox.Show("Fields can not be empty");
                            return 0;
                        }
                    }
                }
            }
            return 1;
        }

        public int validateAdd()
        {
            float n;
            bool isNumericCustomerName = float.TryParse(Obj.textbox2.Text, out n);
            bool isNumericPIN = float.TryParse(Obj.textbox7.Text, out n);
            var FileName = @"C:\MyCSV\customer.csv";
            if (!Directory.Exists(@"C:\MyCSV\"))
            {
                Directory.CreateDirectory(@"C:\MyCSV\");
            }

            using (var sw = new StreamWriter(FileName, append: true))
            {
                var writer = new CsvWriter(sw);

               if (new FileInfo(FileName).Length == 0)
                    writer.WriteHeader(typeof(customer));
                
            }

            using (StreamReader sr = new StreamReader(@"C:\MyCSV\customer.csv"))
            {
                var csv = new CsvReader(sr);
                var records = csv.GetRecords<customer>();

                if (records.Count() == 0)
                {
                    if (Obj.textbox1.TextLength == 0)
                    {
                        MessageBox.Show("Customer ID can not be empty");
                        return 0;

                    }
                    else if (Obj.textbox2.TextLength == 0|| isNumericCustomerName)
                    {
                        MessageBox.Show("Customer Name can not be empty or numeric");
                        return 0;

                    }
                    else if (Obj.textbox3.TextLength == 0)
                    {
                        MessageBox.Show("Designation can not be empty");
                        return 0;

                    }
                    else if (Obj.textbox4.TextLength == 0)
                    {
                        MessageBox.Show("Department can not be empty");
                        return 0;

                    }
                    else if (Obj.textbox5.TextLength == 0)
                    {
                        MessageBox.Show("Street can not be empty");
                        return 0;

                    }
                    else if (Obj.textbox6.TextLength == 0)
                    {
                        MessageBox.Show("City can not be empty");
                        return 0;

                    }
                    else if (Obj.textbox7.TextLength == 0|| !isNumericPIN || Obj.textbox7.TextLength>6|| Obj.textbox7.TextLength<6)
                    {
                        MessageBox.Show("PIN can not be empty and should be of 6 digits");
                        return 0;

                    }
                    else if (Obj.textbox8.TextLength == 0)
                    {
                        MessageBox.Show("Payment in Favor of can not be empty");
                        return 0;

                    }

                    return 1;
                }
            }
            using (StreamReader sr = new StreamReader(@"C:\MyCSV\customer.csv"))
            {
                var csv = new CsvReader(sr);
                while (csv.Read())
                {

                    if (csv[0].Equals(Obj.textbox1.Text) || Obj.textbox1.TextLength == 0)
                    {
                        MessageBox.Show("Customer ID exists or can not be empty");
                        return 0;
                    }
                    else if (csv[1].Equals(Obj.textbox2.Text)|| isNumericCustomerName|| Obj.textbox2.TextLength == 0)
                    {
                        MessageBox.Show("Customer Name exists or is numeric or is empty");
                        return 0;
                    }

                    
                }
            }

            return 1;
        }
    }
}
