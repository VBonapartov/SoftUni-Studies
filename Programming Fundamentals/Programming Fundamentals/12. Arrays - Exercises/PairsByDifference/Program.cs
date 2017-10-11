using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairsByDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrInt = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int diff = int.Parse(Console.ReadLine());

            int countPairs = 0;
            for (int i = 0; i < arrInt.Length; i++)
            {
                for(int p = i; p < arrInt.Length; p++)
                {
                    if (Math.Abs(arrInt[i] - arrInt[p]) == diff)
                    {
                        countPairs++;
                    }
                }
            }

            Console.WriteLine(countPairs);
        }
    }
}
