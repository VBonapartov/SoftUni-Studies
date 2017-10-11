using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int number = 1; number <= n; number++)
            {
                int currentNumber = number;
                int digitsSum = 0;
                while (number > 0)
                {
                    digitsSum += number % 10;
                    number = number / 10;
                }

                bool isSpecial = (digitsSum == 5) || (digitsSum == 7) || (digitsSum == 11);
                Console.WriteLine($"{currentNumber} -> {isSpecial}");

                digitsSum = 0;
                number = currentNumber;
            }
        }
    }
}
