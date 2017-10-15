using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
   public class items
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string UnitPrice { get; set; }
        public string GSTpercent { get; set; }

        public items()
        { }

        public items(string a, string b, string c, string d)
        {
            ProductID = a;
            ProductName = b;
            UnitPrice = c;
            GSTpercent = d;
        }
    }

   


}
