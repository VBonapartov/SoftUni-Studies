using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            bool result = IsPrime(n);
            Console.WriteLine(result);
        }

        static private bool IsPrime(long n)
        {
            bool result = (n > 1);
            for (int i = 3; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }
    }
}
