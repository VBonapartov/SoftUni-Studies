using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddNumbersAtOddPositions
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrInt = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            for (int i = 0; i < arrInt.GetLength(0); i++)
            {
                if ((arrInt[i] & 1) != 0 && (i & 1) != 0)
                {
                    Console.WriteLine($"Index {i} -> {arrInt[i]}");
                }
            }
        }
    }
}
