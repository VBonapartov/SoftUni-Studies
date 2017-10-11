using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrInt1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] arrInt2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int lenArr1 = arrInt1.Length;
            int lenArr2 = arrInt2.Length;

            int maxLength = Math.Max(lenArr1, lenArr2);
            for(int i = 0; i < maxLength; i++)
            {
                int sum = arrInt1[i % lenArr1] + arrInt2[i % lenArr2];
                Console.Write(sum + " ");
            }

            Console.WriteLine();
        }
    }
}
