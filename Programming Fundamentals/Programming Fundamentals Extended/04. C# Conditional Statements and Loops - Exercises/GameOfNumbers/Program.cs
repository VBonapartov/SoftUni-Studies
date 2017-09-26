using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // First line – N – integer in the interval [1…999]
            // Second line – M – integer in the interval[N…1000]
            // Third line – magical number – integer in the interval[1…10000]

            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int magicalNumber = int.Parse(Console.ReadLine());

            int firstDigit = 0;
            int secondDigit = 0;
            int totalCombinations = 0;
            bool isMagicNumberFound = false;
            for (int i = n; i <= m; i++)
            {
                for (int p = n; p <= m; p++)
                {
                    totalCombinations++;
                    if (i + p == magicalNumber)
                    {
                        isMagicNumberFound = true;
                        firstDigit = i;
                        secondDigit = p;
                    }
                }
            }

            if(isMagicNumberFound)
            {
                Console.WriteLine($"Number found! {firstDigit} + {secondDigit} = {magicalNumber}");
            }
            else
            {
                Console.WriteLine($"{totalCombinations} combinations - neither equals {magicalNumber}");
            }

        }
    }
}
