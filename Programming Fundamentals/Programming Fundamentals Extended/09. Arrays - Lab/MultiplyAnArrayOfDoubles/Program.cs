using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplyAnArrayOfDoubles
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arrDoubles = Console.ReadLine().Split(' ').Select(x => double.Parse(x)).ToArray();
            double p = double.Parse(Console.ReadLine());

            for (int i = 0; i < arrDoubles.GetLength(0); i++)
            {
                arrDoubles[i] *= p;
            }

            for (int i = 0; i < arrDoubles.GetLength(0); i++)
            {
                Console.Write(arrDoubles[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
