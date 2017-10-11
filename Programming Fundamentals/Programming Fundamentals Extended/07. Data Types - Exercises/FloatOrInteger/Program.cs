using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloatOrInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberDouble = Convert.ToDouble(Console.ReadLine());
            int numberInteger = Convert.ToInt32(numberDouble);

            if (numberInteger == numberDouble)
            {
                Console.WriteLine(numberInteger);
            }
            else
            {
                Console.WriteLine($"{Math.Round(numberDouble)}");
            }
        }
    }
}
