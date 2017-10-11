using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrInt = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());

            int[] resultArray = new int[arrInt.Length];
            for(int i = 1; i <= n; i++)
            {
                int lastElement = arrInt[arrInt.Length - 1];
                for(int p = arrInt.Length - 1; p > 0; p--)
                {
                    arrInt[p] = arrInt[p - 1];
                }
                arrInt[0] = lastElement;

                for(int c = 0; c < arrInt.Length; c++)
                {
                    resultArray[c] += arrInt[c];
                }
            }

            for(int i = 0; i < resultArray.Length; i++)
            {
                Console.Write(resultArray[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
