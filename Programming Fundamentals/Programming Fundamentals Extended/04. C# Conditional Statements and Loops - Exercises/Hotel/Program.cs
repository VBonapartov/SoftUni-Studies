using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            //  First line: Month – May, June, July, August, September, October or December
            //  Second line: Nights Count – an integer between[0... 200]

            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double priceStudio = 0.00;
            double priceDouble = 0.00;
            double priceSuite = 0.00;

            double studioDiscount = 0.00;
            double doubleDiscount = 0.00;
            double suiteDiscount = 0.00;                       

            if (month.Equals("May") || month.Equals("October"))
            {
                priceStudio = 50.00;
                priceDouble = 65.00;
                priceSuite = 75.00;

                studioDiscount = (nights > 7) ? 0.05 : 0;
                priceStudio -= priceStudio * studioDiscount;
            }
            else if(month.Equals("June") || month.Equals("September"))
            {
                priceStudio = 60.00;
                priceDouble = 72.00;
                priceSuite = 82.00;

                doubleDiscount = (nights > 14) ? 0.10 : 0;
                priceDouble -= priceDouble * doubleDiscount;
            }
            else if (month.Equals("July") || month.Equals("August") || month.Equals("December"))
            {
                priceStudio = 68.00;
                priceDouble = 77.00;
                priceSuite = 89.00;

                suiteDiscount = (nights > 14) ? 0.15 : 0;
                priceSuite -= priceSuite * suiteDiscount;
            }

            int studioFreeNights = 0;
            if ((nights > 7) && (month.Equals("September") || month.Equals("October")))
            {
                studioFreeNights = 1;
            }

            Console.WriteLine($"Studio: {(priceStudio * (nights - studioFreeNights)):F2} lv.");
            Console.WriteLine($"Double: {(priceDouble * nights):F2} lv.");
            Console.WriteLine($"Suite: {(priceSuite * nights):F2} lv.");
        }
    }
}
