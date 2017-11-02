using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniWaterSupplies
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalAmountOfWater = int.Parse(Console.ReadLine());
            double[] bottles = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            int bottleCapacity = int.Parse(Console.ReadLine());

            int amountOfBottles = 0;
            double amountOfWaterLeft = totalAmountOfWater;            
            double amountOfWaterNeeded = 0;             
            List<int> indices = new List<int>();

            int currentIndex = (totalAmountOfWater % 2 == 0) ? 0 : bottles.Length - 1;
            while(0 <= currentIndex && currentIndex <= bottles.Length - 1)
            {
                double waterForCurrentBottle = (bottleCapacity - bottles[currentIndex]);
                if(amountOfWaterLeft >= waterForCurrentBottle)
                {
                    amountOfWaterLeft -= waterForCurrentBottle;
                }
                else
                {
                    amountOfBottles++;
                    amountOfWaterNeeded += waterForCurrentBottle - amountOfWaterLeft;                 
                    indices.Add(currentIndex);

                    amountOfWaterLeft = 0;
                }                
                
                currentIndex = (totalAmountOfWater % 2 == 0) ? currentIndex + 1 : currentIndex - 1;
            }


            if(amountOfBottles == 0)
            {
                Console.WriteLine($"Enough water!");
                Console.WriteLine($"Water left: {amountOfWaterLeft}l.");
            }
            else
            {
                Console.WriteLine($"We need more water!");
                Console.WriteLine($"Bottles left: {amountOfBottles}");
                Console.WriteLine($"With indexes: " + string.Join(", ", indices));
                Console.WriteLine($"We need {amountOfWaterNeeded} more liters!");
            }
        }
    }
}
