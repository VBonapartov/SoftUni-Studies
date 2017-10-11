using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountOfOddNumbersInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrInt = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            int countOdds = 0;
            for(int i = 0; i < arrInt.GetLength(0); i++)
            {
                if((arrInt[i] & 1) != 0)
                {
                    countOdds++;
                }
            }

            Console.WriteLine(countOdds);
        }
    }
}
