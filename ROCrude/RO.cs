using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class RO
    {
        public int ROID
        {
            get;
            set;
        }
        public string CNAME
        {
            get;
            set;
        }

        public string CADDRESS
        {
            get;
            set;
        }
        public string CMAKE
        {
            get;
            set;
        }
        public int MLGE
        {
            get;
            set;
        }
        public override string ToString()
        {
            string s = "";
            s += "\nRO ID\t:\t" + ROID;
            s += "\nCustomer Name\t:\t" + CNAME;
            s += "\nAddress\t\t:\t" + CADDRESS;
            s += "\nModel\t\t:\t" + CMAKE;
            s += "\nMileage\t:\t" + MLGE;
            return s;
        }
    }
}
