using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountOccurrOfLargerNumbersInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arrDouble = Console.ReadLine().Split(' ').Select(x => double.Parse(x)).ToArray();
            double element = double.Parse(Console.ReadLine());

            int count = 0;
            for (int i = 0; i < arrDouble.GetLength(0); i++)
            {
                if (arrDouble[i] > element)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
