using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConvertFromBase10ToBaseN
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger[] inputNums = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToArray();

            BigInteger baseN = inputNums[0];
            BigInteger number = inputNums[1];

            StringBuilder result = new StringBuilder();
            while (number >  0)
            {
                int reminder = (int)(number % baseN);
                result.Append(reminder);
                number /= baseN;
            }

            string convertedNumber = new string(result.ToString().Reverse().ToArray());
            Console.WriteLine(convertedNumber);
        }
    }
}
