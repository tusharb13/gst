using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

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
		{   if (validateAdd() == 1)
			{
				var FileName = @"C:\MyCSV\items.csv";
				//if (!Directory.Exists(@"C:\MyCSV\"))
				//{
				//    Directory.CreateDirectory(@"C:\MyCSV\");
				//}
				using (var sw = new StreamWriter(FileName, append: true))
				{
					var writer = new CsvWriter(sw);

					writer.Configuration.HasHeaderRecord = false;
					if (new FileInfo(FileName).Length == 0)
						//writer.WriteHeader(typeof(user));
						writer.Configuration.HasHeaderRecord = true;

					List<items> ls = new List<items>();
					ls.Add(new items(Obj.textbox1.Text, Obj.textbox2.Text, Obj.textbox3.Text, Obj.textbox4.Text));
					writer.WriteRecords(ls);

				}
				MessageBox.Show("Entered succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
				Obj.textbox1.Clear();
				Obj.textbox2.Clear();
				Obj.textbox3.Clear();
				Obj.textbox4.Clear();
			}            
			
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
		{   var ls = f6.itemsbindingsource.List;
            if (ValidateEdit(ls) == 1)
            {

                //MessageBox.Show(ls.GetType().ToString());
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

        private int ValidateEdit(IList ls)
        {          
            var length = ls.Count;
            float n;
            if (length == 1)
            {
                for (int i = 0; i < length; ++i)
                {
                    bool isNumericUnitPrice = float.TryParse((ls[i] as items).UnitPrice, out n);
                    bool isNumericGSTPercent = float.TryParse((ls[i] as items).GSTpercent, out n);

                    if (!isNumericUnitPrice)
                    {
                        MessageBox.Show("Unit price should be numeric");
                        return 0;
                    }
                    else if (!isNumericGSTPercent)
                    {
                        MessageBox.Show("GST percent should be numeric");
                        return 0;
                    }
                    else if ((ls[i] as items).ProductID == null || (ls[i] as items).ProductName == null || (ls[i] as items).UnitPrice == null || (ls[i] as items).GSTpercent == null)
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
                    bool isNumericUnitPrice = float.TryParse((ls[i] as items).UnitPrice, out n);
                    bool isNumericGSTPercent = float.TryParse((ls[i] as items).GSTpercent, out n);
                    
                    for (int j = i + 1; j < length; ++j)
                    {
                        if ((ls[i] as items).ProductID == (ls[j] as items).ProductID)
                        {
                            MessageBox.Show("Product ID exists");
                            return 0;
                        }
                        if ((ls[i] as items).ProductName == (ls[j] as items).ProductName)
                        {
                            MessageBox.Show("Product Name exists");
                            return 0;
                        }
                        else if (!isNumericUnitPrice)
                        {
                            MessageBox.Show("Unit price should be numeric");
                            return 0;
                        }
                        else if (!isNumericGSTPercent)
                        {
                            MessageBox.Show("GST percent should be numeric");
                            return 0;
                        }
                        else if ((ls[i] as items).ProductID == null || (ls[i] as items).ProductName == null || (ls[i] as items).UnitPrice == null || (ls[i] as items).GSTpercent == null)
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
			bool isNumericUnitPrice = float.TryParse(Obj.textbox3.Text, out n);
			bool isNumericGSTpercent = float.TryParse(Obj.textbox4.Text, out n);
			var FileName = @"C:\MyCSV\items.csv";
			if (!Directory.Exists(@"C:\MyCSV\"))
			{
				Directory.CreateDirectory(@"C:\MyCSV\");
			}

			using (var sw = new StreamWriter(FileName, append: true))
			{
				var writer = new CsvWriter(sw);

				//writer.Configuration.HasHeaderRecord = false;
				if (new FileInfo(FileName).Length == 0)
					writer.WriteHeader(typeof(items));
					//writer.Configuration.HasHeaderRecord = true;
			}

			using (StreamReader sr = new StreamReader(@"C:\MyCSV\items.csv"))
			{
				var csv = new CsvReader(sr);
				var records = csv.GetRecords<items>();

				if (records.Count() == 0)
				{
					if (Obj.textbox1.TextLength == 0)
					{
						MessageBox.Show("Product ID exists or can not be empty");
						return 0;

					}
					else if (Obj.textbox2.TextLength == 0)
					{
						MessageBox.Show("Product Name exists or can not be empty");
						return 0;

					}
					else if (!isNumericUnitPrice)
					{
						MessageBox.Show("Unit price should be numeric");
						return 0;
					}
					else if (!isNumericGSTpercent)
					{
						MessageBox.Show("GST percent should be numeric");
						return 0;
					}
					return 1;
				}
			}
			using (StreamReader sr = new StreamReader(@"C:\MyCSV\items.csv"))
			{
				var csv = new CsvReader(sr);
				while (csv.Read())
				{

					if (csv[0].Equals(Obj.textbox1.Text) || Obj.textbox1.TextLength == 0)
					{
						MessageBox.Show("Product ID exists or can not be empty");
						return 0;
					}
					else if (csv[1].Equals(Obj.textbox2.Text))
					{
						MessageBox.Show("Product Name exists");
						return 0;
					}

					else if (!isNumericUnitPrice)
					{
						MessageBox.Show("Unit price should be numeric");
						return 0;
					}
					else if (!isNumericGSTpercent)
					{
						MessageBox.Show("GST percent should be numeric");
						return 0;
					}
				}
			}   
			
			return 1;
		}

		
	}
}
