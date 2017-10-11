using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestElementInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] arrInt = new int[n];
            for (int i = 0; i < n; i++)
            {
                arrInt[i] = int.Parse(Console.ReadLine());
            }

            int maxElement = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                maxElement = Math.Max(maxElement, arrInt[i]);
            }

            Console.WriteLine(maxElement);
        }
    }
}
