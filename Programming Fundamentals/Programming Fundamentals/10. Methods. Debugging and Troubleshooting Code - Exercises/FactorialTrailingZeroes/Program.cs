using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FactorialTrailingZeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger factorial = CalculateNFactorial(n);
            int trailingZeroes = GetTrailingZeroes(factorial.ToString());
            Console.WriteLine(trailingZeroes);
        }

        static private BigInteger CalculateNFactorial(int num)
        {
            BigInteger factorial = 1;
            for (int i = 1; i <= num; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

        static private int GetTrailingZeroes(string factorial)
        {
            int trailingZeroes = 0;
            for (int i = factorial.Length - 1; i >= 0; i--)
            {
                char tre = factorial[i];
                if (factorial[i].Equals('0'))
                {
                    trailingZeroes++;
                }
                else
                {
                    break;
                }
            }

            return trailingZeroes;
        }
    }
}
