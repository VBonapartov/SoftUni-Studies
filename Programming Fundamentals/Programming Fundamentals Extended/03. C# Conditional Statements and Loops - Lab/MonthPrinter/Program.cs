using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthPrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            int monthNumber = int.Parse(Console.ReadLine());

            string month = string.Empty;
            if (monthNumber < 1 || monthNumber > 12)
            {
                month = "Error!";
            }
            else
            {
                switch(monthNumber)
                {
                    case 1:
                        month = "January";
                        break;
                    case 2:
                        month = "February";
                        break;
                    case 3:
                        month = "March";
                        break;
                    case 4:
                        month = "April";
                        break;
                    case 5:
                        month = "May";
                        break;
                    case 6:
                        month = "June";
                        break;
                    case 7:
                        month = "July";
                        break;
                    case 8:
                        month = "August";
                        break;
                    case 9:
                        month = "September";
                        break;
                    case 10:
                        month = "October";
                        break;
                    case 11:
                        month = "November";
                        break;
                    case 12:
                        month = "December";
                        break;
                }
            }

            Console.WriteLine(month);
        }
    }
}
