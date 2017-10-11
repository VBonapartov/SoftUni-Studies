using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentenceTheThief
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int numberOfIds = int.Parse(Console.ReadLine());

            int minSByteValue = -128;
            int maxSByteValue = 127;

            long maxValue = 0;            
            switch (type)
            {
                case "sbyte":
                    maxValue = sbyte.MaxValue;
                    break;
                case "int":
                    maxValue = int.MaxValue;
                    break;
                case "long":
                    maxValue = long.MaxValue;
                    break;
            }

            long closestToMaximumValue = long.MinValue;
            for (int i = 1; i <= numberOfIds; i++)
            {
                long number = long.Parse(Console.ReadLine());

                if (number > closestToMaximumValue && number <= maxValue)
                {
                    closestToMaximumValue = number;
                }
            }

            long years = 0;
            if(closestToMaximumValue >= 0)
            {
                years = (long)Math.Ceiling(closestToMaximumValue / (double)maxSByteValue);
            }
            else
            {
                years = (long)Math.Ceiling(closestToMaximumValue / (double)minSByteValue);
            }

            if (years == 1)
            {
                Console.WriteLine($"Prisoner with id {closestToMaximumValue} is sentenced to {years} year");
            }
            else
            {
                Console.WriteLine($"Prisoner with id {closestToMaximumValue} is sentenced to {years} years");
            }
        }
    }
}
