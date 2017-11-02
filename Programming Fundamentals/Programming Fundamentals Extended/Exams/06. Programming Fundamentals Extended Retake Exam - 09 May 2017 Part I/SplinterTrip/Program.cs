using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplinterTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripDistanceInMiles = double.Parse(Console.ReadLine());
            double fuelTankCapacityInLiters = double.Parse(Console.ReadLine());
            double milesInHeavyWinds = double.Parse(Console.ReadLine());

            double totalFuelNeeded = (tripDistanceInMiles - milesInHeavyWinds) * 25 + milesInHeavyWinds * 25 * 1.5;
            totalFuelNeeded += totalFuelNeeded * 0.05;

            Console.WriteLine($"Fuel needed: {totalFuelNeeded:F2}L");

            if(totalFuelNeeded <= fuelTankCapacityInLiters)
            {
                Console.WriteLine($"Enough with {(fuelTankCapacityInLiters - totalFuelNeeded):F2}L to spare!");
            }
            else
            {
                Console.WriteLine($"We need {(totalFuelNeeded - fuelTankCapacityInLiters):F2}L more fuel.");
            }
        }
    }
}
