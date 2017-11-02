using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wormtest
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthInMeters = int.Parse(Console.ReadLine());
            double widthInCentimeters = double.Parse(Console.ReadLine());

            int lengthInCentimeters = lengthInMeters * 100;            
            
            if (widthInCentimeters != 0)
            {
                double remainder = lengthInCentimeters % widthInCentimeters;
                if (remainder == 0)
                {
                    Console.WriteLine($"{(lengthInCentimeters * widthInCentimeters):F2}");
                }
                else
                {
                    double percentage = (lengthInCentimeters / widthInCentimeters) * 100.00;
                    Console.WriteLine($"{percentage:F2}%");
                }
            }
            else
            {
                Console.WriteLine($"{(lengthInCentimeters * widthInCentimeters):F2}");
            }
        }
    }
}
