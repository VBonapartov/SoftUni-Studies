using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelingAtLightSpeed
{
    class Program
    {
        static void Main(string[] args)
        {
            double lightYears = double.Parse(Console.ReadLine());

            double totalSeconds = (lightYears * 9450000000000) / 300000.00;
            TimeSpan timeSpan = TimeSpan.FromSeconds(totalSeconds);

            int weeks = timeSpan.Days / 7;
            int days = timeSpan.Days % 7;
            int hours = timeSpan.Hours % 24;
            int minutes = timeSpan.Minutes % 60;
            int seconds = timeSpan.Seconds % 60;

            Console.WriteLine($"{weeks} weeks");
            Console.WriteLine($"{days} days");
            Console.WriteLine($"{hours} hours");
            Console.WriteLine($"{minutes} minutes");
            Console.WriteLine($"{seconds} seconds");
        }
    }
}
