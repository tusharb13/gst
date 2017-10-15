using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    class user
    {
        public string GSTIN { get; set; }
        public string Company { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PIN { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string email { get; set; }
        public string Phone { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string Branch { get; set; }
        public string IFSCCode { get; set; }

        public user() { }

        public user(string a,string b,string  c, string d,string e, string f, string g, string h, string i, string j, string k, string l, string m, string n)
        {
            
            Company = a;
            Street = b;
            City = c;
            PIN = d;
            State = e;
            Country = f;
            Location = g;
            email = h;
            Phone = i;
            GSTIN = j;
            BankName = k;
            AccountNumber = l;
            Branch = m;
            IFSCCode = n;

        }
    }

}
