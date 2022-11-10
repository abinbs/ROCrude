using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ROCrude
{
    public class Program
    {
        static void Main(string[] args)
        {

            ROView cvw = new ROView();
            bool sts = true;
            while (sts)
            {
                int ch = cvw.MenuChoice();
                switch (ch)
                {
                    case 1:
                        cvw.AddROView();
                        break;
                    case 2:
                        cvw.UpdateROView();
                        break;
                    case 3:
                        cvw.DeleteROView();
                        break;
                    case 4:
                        cvw.FindROView();
                        break;
                    case 5:
                        cvw.ROSummaryView();
                        break;
                    case 6:
                        sts = false;
                        cvw = null;
                        break;
                    default:
                        Console.WriteLine("\n\n******Wrong Choice*******\n\n");
                        break;

                }
            }
        }
    }
}
