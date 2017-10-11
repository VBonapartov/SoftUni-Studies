using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheThief
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int numberOfIds = int.Parse(Console.ReadLine());

            long maxValue = 0;
            switch(type)
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

            Console.WriteLine(closestToMaximumValue);
        }
    }
}
