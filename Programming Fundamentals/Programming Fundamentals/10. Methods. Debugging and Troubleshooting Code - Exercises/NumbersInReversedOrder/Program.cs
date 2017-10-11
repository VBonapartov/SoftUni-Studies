using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersInReversedOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());

            string numberToString = number.ToString();
            StringBuilder result = new StringBuilder();
            for (int i = numberToString.Length - 1; i >= 0; i--)
            {
                result.Append(numberToString[i]);
            }
            Console.WriteLine(result);
        }
    }
}
