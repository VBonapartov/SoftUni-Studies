using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestElementInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrInt = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            int minElement = int.MaxValue;
            for(int i = 0; i < arrInt.GetLength(0); i++)
            {
                minElement = Math.Min(minElement, arrInt[i]);
            }

            Console.WriteLine(minElement);
        }
    }
}
