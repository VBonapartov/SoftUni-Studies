using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountOfNegativeElementsInArray
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

            int countNegativeElements = 0;
            for (int i = 0; i < n; i++)
            {
                if(arrInt[i] < 0)
                {
                    countNegativeElements++;
                }
            }

            Console.WriteLine(countNegativeElements);
        }
    }
}
