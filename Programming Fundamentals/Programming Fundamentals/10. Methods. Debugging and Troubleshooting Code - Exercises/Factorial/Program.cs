using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger factorial = CalculateNFactorial(n);
            Console.WriteLine(factorial);
        }

        static private BigInteger CalculateNFactorial(int num)
        {
            BigInteger factorial = 1;
            for(int i = 1; i <= num; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
