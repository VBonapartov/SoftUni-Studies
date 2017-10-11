using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostFrequentNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrInt = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int countMostFrequentNumber = 0;
            int mostFrequentNumber = 0;
            for (int i = 0; i < arrInt.Length; i++)
            {
                int countNumber = 0;
                for(int p = 0; p < arrInt.Length; p++)
                {
                    if(arrInt[i] == arrInt[p])
                    {
                        countNumber++;
                    }
                }

                if (countNumber > countMostFrequentNumber)
                {
                    mostFrequentNumber = arrInt[i];
                    countMostFrequentNumber = countNumber;
                }
            }

            Console.WriteLine(mostFrequentNumber);
        }
    }
}
