using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listNumbers = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();

            int start = listNumbers[0];
            int length = 1;

            int bestStart = start;
            int bestLength = length;
            for (int i = 1; i < listNumbers.Count; i++)
            {
                if(listNumbers[i] == start)
                {
                    length++;
                    if(length > bestLength)
                    {
                        bestStart = listNumbers[i];
                        bestLength = length;
                    }
                }
                else
                {
                    start = listNumbers[i];
                    length = 1;
                }
            }

            for(int i = 1; i <= bestLength; i++)
            {
                Console.Write(bestStart + " ");
            }
            Console.WriteLine();
        }
    }
}
