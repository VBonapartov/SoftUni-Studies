using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConvertFromBaseNToBase10
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger[] inputNums = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToArray();

            int baseN = (int)inputNums[0];
            BigInteger number = inputNums[1];         

            BigInteger numberBaseN = ConvertBaseNToBase10(number, baseN);
            Console.WriteLine(numberBaseN);
        }

        private static BigInteger ConvertBaseNToBase10(BigInteger number, int baseN)
        {
            BigInteger resultNumber = 0;

            int power = 0;
            while(number > 0)
            {
                resultNumber += (number % 10) * MathPower(baseN, power++);
                number /= 10;
            }

            return resultNumber;
        }

        private static BigInteger MathPower(int number, int power)
        {
            if (power == 0)
                return 1;

            BigInteger result = number;
            for(int i = 1; i < power; i++)
                result *= number;

            return result;
        }
    }
}
