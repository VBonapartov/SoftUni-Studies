using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountOfGivenElementInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrInt = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            int element = int.Parse(Console.ReadLine());

            int count = 0;
            for (int i = 0; i < arrInt.GetLength(0); i++)
            {
                if (arrInt[i] == element)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
