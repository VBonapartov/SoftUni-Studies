using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int startNumber = 1;
            int sum = 0;
            while(n > 0)
            {
                if((startNumber % 2) != 0)
                {
                    sum += startNumber;
                    Console.WriteLine(startNumber);
                    n--;
                }

                startNumber++;                
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
