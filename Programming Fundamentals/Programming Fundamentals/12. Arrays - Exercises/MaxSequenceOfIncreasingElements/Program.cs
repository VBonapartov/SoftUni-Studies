using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSequenceOfIncreasingElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrInt = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int countMaxSequence = 1;
            int currentSequence = 1;
            int currentElement = arrInt[0];
            int itemIdx = 0;
            for (int i = 1; i < arrInt.Length; i++)
            {
                if (currentElement < arrInt[i])
                {
                    currentSequence++;
                    if (currentSequence > countMaxSequence)
                    {
                        countMaxSequence = currentSequence;
                        itemIdx = i;
                    }
                }
                else
                {
                    currentSequence = 1;                    
                }

                currentElement = arrInt[i];
            }

            itemIdx = itemIdx - countMaxSequence + 1;
            for (int i = 0; i < countMaxSequence; i++)
            {
                Console.Write(arrInt[itemIdx + i] + " ");
            }
            Console.WriteLine();

        }
    }
}
