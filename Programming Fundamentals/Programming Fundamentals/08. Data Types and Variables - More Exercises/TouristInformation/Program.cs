using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            string imperialUnit = Console.ReadLine();
            double value = double.Parse(Console.ReadLine());

            switch(imperialUnit)
            {
                case "miles":
                    Console.WriteLine($"{value} miles = {(value * 1.60):F2} kilometers");
                    break;
                case "inches":
                    Console.WriteLine($"{value} inches = {(value * 2.54):F2} centimeters");
                    break;
                case "feet":
                    Console.WriteLine($"{value} feet = {(value * 30):F2} centimeters");
                    break;
                case "yards":
                    Console.WriteLine($"{value} yards = {(value * 0.91):F2} meters");
                    break;
                case "gallons":
                    Console.WriteLine($"{value} gallons = {(value * 3.80):F2} liters");
                    break;
            }
        }
    }
}
