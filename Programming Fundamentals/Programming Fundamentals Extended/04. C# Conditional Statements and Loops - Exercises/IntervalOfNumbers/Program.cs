using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntervalOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());

            int min = Math.Min(number1, number2);
            int max = Math.Max(number1, number2);

            for(int i = min; i <= max; i++)
            {
                Console.WriteLine($"{i}");
            }
        }
    }
}
