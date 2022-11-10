using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.IO;
using System.Reflection;
using CustomerDemo;

namespace ROCrude
{

    public class ROView
    {
        RO c = null;
        ROSpDb cl;

        public ROView()
        {
            cl = new ROSpDb();

        }

        public int MenuChoice()
        {
            Console.WriteLine("1. New RO");
            Console.WriteLine("2. Update RO");
            Console.WriteLine("3. Delete RO");
            Console.WriteLine("4. Find RO");
            Console.WriteLine("5. RO Summary");
            Console.WriteLine("6. Exit");
            Console.Write("Please Enter Your Choice\t:\t");
            int ch = int.Parse(Console.ReadLine());
            return ch;
        }

        public void AddROView()
        {
            int  mileage;
            string name, model, address;
            Console.Write("Please Enter Customer Name\t:\t");
            name = Console.ReadLine();
            Console.Write("Please Enter Model\t:\t");
            model = Console.ReadLine();
            Console.Write("Please Enter Customer Address\t:\t");
            address = Console.ReadLine();
            Console.Write("Please Enter Mileage\t:\t");
            mileage = int.Parse(Console.ReadLine());

            c = new RO
            {
                CNAME = name,
                CMAKE = model,
                CADDRESS = address,
                MLGE = mileage,
            };
            cl.AddRO(c);
        }

        public void UpdateROView()
        {
            int id, mileage;
            string name, model, address;
            Console.Write("Please Enter RO ID\t:\t");
            id = int.Parse(Console.ReadLine());
            Console.Write("Please Enter Customer Name\t:\t");
            name = Console.ReadLine();
            Console.Write("Please Enter Model\t:\t");
            model = Console.ReadLine();
            Console.Write("Please Enter Customer Address\t:\t");
            address = Console.ReadLine();
            Console.Write("Please Enter Mileage\t:\t");
            mileage = int.Parse(Console.ReadLine());

            c = new RO
            {
                ROID = id,
                CNAME = name,
                CMAKE = model,
                CADDRESS = address,
                MLGE = mileage,
            };
            Console.WriteLine(cl.UpdateRO(id, c));
            
        }

        public void FindROView()
        {
            int id;

            Console.Write("Please Enter RO ID\t:\t");
            id = int.Parse(Console.ReadLine());

            c = cl.FindRO(id);

            if (c != null)
            {
                Console.WriteLine("RO Record Found.............");
                Console.WriteLine(c);
            }
            else
            {
                Console.WriteLine("RO not found.......");
            }
        }

        public void DeleteROView()
        {
            int id;
            Console.Write("Please Enter RO ID\t:\t");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine(cl.DeleteRO(id));
            
        }

        public void ROSummaryView()
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("ID\tName\tMake\tAddress\tMileage");
            Console.WriteLine("-------------------------------------------------------");
            foreach (RO c in cl.GetRO())
            {
                Console.WriteLine(c.ROID + "\t" + c.CNAME + "\t" + c.CMAKE + "\t" + c.CADDRESS + "\t" + c.MLGE);
            }
            Console.WriteLine("-------------------------------------------------------");
        }


    }
}
