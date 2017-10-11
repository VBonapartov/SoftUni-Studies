using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrInt = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[] firstRow = new int[2 * (arrInt.Length / 4)];
            int[] secondRow = new int[2 * (arrInt.Length / 4)];

            int firstRowIndex = (arrInt.Length / 4) - 1;
            int secondRowIndex = 0;
            for (int i = 0; i < arrInt.Length; i++)
            {
                if ((i <= (firstRow.Length / 2) - 1) || (i >= arrInt.Length - (firstRow.Length / 2)))
                {
                    firstRow[firstRowIndex] = arrInt[i];
                    if (firstRowIndex == 0)
                    {
                        firstRowIndex = 2 * (arrInt.Length / 4) - 1;
                    }
                    else
                    {
                        firstRowIndex--;
                    }
                }
                else
                {
                    secondRow[secondRowIndex++] = arrInt[i];
                }
            }

            for(int i = 0; i < firstRow.Length; i++)
            {
                Console.Write(firstRow[i] + secondRow[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
