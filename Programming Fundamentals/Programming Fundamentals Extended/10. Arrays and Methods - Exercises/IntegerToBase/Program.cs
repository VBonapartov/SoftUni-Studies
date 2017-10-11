using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerToBase
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            int toBase = int.Parse(Console.ReadLine());

            string result = IntegerToBase(number, toBase);
            Console.WriteLine(result);
        }

        static private string IntegerToBase(long number, int toBase)
        {
            StringBuilder result = new StringBuilder();
            while (number > 0)
            {
                long remainder = (number % toBase);
                result.Append(remainder);

                number /= toBase;
            }

            return new string(result.ToString().ToCharArray().Reverse().ToArray());
        }
    }
}
