using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HornetWings
{
    class Program
    {
        static void Main(string[] args)
        {
            int wingFlaps = int.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            int endurance = int.Parse(Console.ReadLine());

            double totalDistance = (wingFlaps / 1000.00) * distanceInMeters;
            int seconds = (wingFlaps / 100) + (wingFlaps / endurance) * 5;

            Console.WriteLine($"{totalDistance:F2} m.");
            Console.WriteLine($"{seconds} s.");
        }
    }
}
