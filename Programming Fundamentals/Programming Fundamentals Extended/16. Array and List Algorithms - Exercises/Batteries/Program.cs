using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batteries
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] capacities = Console.ReadLine().Trim().Split(' ').Select(double.Parse).ToArray();
            double[] usagePerHour = Console.ReadLine().Trim().Split(' ').Select(double.Parse).ToArray();
            int stressTestHours = int.Parse(Console.ReadLine());

            for(int i = 0; i < capacities.Length; i++)
            {
                int maxBatteryHours = (int)(capacities[i] / usagePerHour[i]);
                if(maxBatteryHours >= stressTestHours)
                {
                    double remainingCapacity = capacities[i] - (stressTestHours * usagePerHour[i]);
                    double percentage = (remainingCapacity / capacities[i]) * 100;

                    Console.WriteLine($"Battery {i + 1}: {remainingCapacity:F2} mAh ({percentage:F2})%");
                }
                else
                {
                    int lastedHours = (int)Math.Ceiling(capacities[i] / usagePerHour[i]);

                    Console.WriteLine($"Battery {i + 1}: dead (lasted {lastedHours} hours)");
                }
            }
        }
    }
}
