using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertSpeedUnits
{
    class Program
    {
        static void Main(string[] args)
        {
            int distance = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());

            float kilometers = (float)(distance / 1000.00);

            int totalSeconds = hours * 3600 + minutes * 60 + seconds;
            float totalHours = (float)(totalSeconds / 3600.00);

            float metersPerSecond = distance / (float)totalSeconds;
            float kilometersPerHour = kilometers / totalHours;
            float milesPerHour = (float)(kilometers / 1.609) / totalHours;

            Console.WriteLine(metersPerSecond);
            Console.WriteLine(kilometersPerHour);
            Console.WriteLine(milesPerHour);
        }
    }
}
