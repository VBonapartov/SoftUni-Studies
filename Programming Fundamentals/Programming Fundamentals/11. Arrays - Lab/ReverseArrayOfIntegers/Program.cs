using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseArrayOfIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] arrInt = new int[n];
            for (int i = 0; i < n; i++)
            {
                arrInt[i] = int.Parse(Console.ReadLine());
            }

            for(int i = arrInt.Length -1; i >= 0; i--)
            {
                Console.Write(arrInt[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
