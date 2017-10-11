using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignOfIntegerNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintSign(n);
        }

        static private void PrintSign(int number)
        {
            string numberType = "zero";

            if (number > 0)
            {
                numberType = "positive";
            }
            else if (number < 0)
            {
                numberType = "negative";
            }

            Console.WriteLine($"The number {number} is {numberType}.");
        }

    }
}
