using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace BigFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            BigInteger fact = GetFactorial(number);
            Console.WriteLine(fact);
        }

        static private BigInteger GetFactorial(int number)
        {
            if(number == 0)
            {
                return 1;
            }

            return number * GetFactorial(number - 1);
        }
    }
}
