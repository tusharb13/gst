using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    class search
    {
        Form8 Obj;

        public void Init(Form8 obj)
        {
            Obj = obj;
        }

        public void customerSearch(String searchName)
        {
            Obj.datagridview1.Rows.Clear();
            Obj.datagridview1.Refresh();
            createEmptyInvoice();

            using (var reader = new StreamReader(@"C:\MyCSV\invoice.csv"))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    break;
                }
                int index = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    var abc = values[0];
                    if (values[0].Equals(searchName))
                    {
                        Obj.datagridview1.Rows.Add();
                        Obj.datagridview1.Rows[index].Cells[0].Value = values[0].ToString();
                        Obj.datagridview1.Rows[index].Cells[1].Value = values[1].ToString();
                        Obj.datagridview1.Rows[index].Cells[2].Value = values[2].ToString();
                        Obj.datagridview1.Rows[index].Cells[3].Value = values[3].ToString();
                        Obj.datagridview1.Rows[index].Cells[4].Value = values[4].ToString();
                        Obj.datagridview1.Rows[index].Cells[5].Value = values[5].ToString();
                        Obj.datagridview1.Rows[index].Cells[6].Value = values[9].ToString();

                        index++;

                    }

                }
            }
        }

        public void productSearch(String text)
        {
            Obj.datagridview1.Rows.Clear();
            Obj.datagridview1.Refresh();
            createEmptyInvoice();
            using (var reader = new StreamReader(@"C:\MyCSV\invoice.csv"))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    break;
                }
                int index = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    var abc = values[0];
                    if (values[1].Equals(text))
                    {
                        Obj.datagridview1.Rows.Add();
                        Obj.datagridview1.Rows[index].Cells[0].Value = values[0].ToString();
                        Obj.datagridview1.Rows[index].Cells[1].Value = values[1].ToString();
                        Obj.datagridview1.Rows[index].Cells[2].Value = values[2].ToString();
                        Obj.datagridview1.Rows[index].Cells[3].Value = values[3].ToString();
                        Obj.datagridview1.Rows[index].Cells[4].Value = values[4].ToString();
                        Obj.datagridview1.Rows[index].Cells[5].Value = values[5].ToString();
                        Obj.datagridview1.Rows[index].Cells[6].Value = values[9].ToString();

                        index++;

                    }

                }
            }
        }

        public void dateSearch(string text)
        {
            Obj.datagridview1.Rows.Clear();
            Obj.datagridview1.Refresh();
            createEmptyInvoice();
            using (var reader = new StreamReader(@"C:\MyCSV\invoice.csv"))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    break;
                }
                int index = 0;
                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (line.Contains(text))
                    {

                        Obj.datagridview1.Rows.Add();
                        Obj.datagridview1.Rows[index].Cells[0].Value = values[0].ToString();
                        Obj.datagridview1.Rows[index].Cells[1].Value = values[1].ToString();
                        Obj.datagridview1.Rows[index].Cells[2].Value = values[2].ToString();
                        Obj.datagridview1.Rows[index].Cells[3].Value = values[3].ToString();
                        Obj.datagridview1.Rows[index].Cells[4].Value = values[4].ToString();
                        Obj.datagridview1.Rows[index].Cells[5].Value = values[5].ToString();
                        Obj.datagridview1.Rows[index].Cells[6].Value = values[9].ToString();
                        index++;

                    }

                }
            }
        }

        public void createEmptyInvoice()
        {
            var FileName = @"C:\MyCSV\invoice.csv";
            if (!File.Exists(@"C:\MyCSV\invoice.csv"))
            {
                using (var sw = new StreamWriter(FileName, true))
                {
                    var writer = new CsvWriter(sw);
                    if (new FileInfo(FileName).Length == 0)
                        writer.WriteHeader(typeof(customer));
                }
            }
        }
    }
}
