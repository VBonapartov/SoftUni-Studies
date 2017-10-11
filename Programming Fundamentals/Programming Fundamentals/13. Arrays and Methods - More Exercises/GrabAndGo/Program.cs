using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabAndGo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrInt = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int searchNumber = int.Parse(Console.ReadLine());

            bool isFind = false;
            long sum = 0;
            for(int i = arrInt.Length - 1; i >= 0; i--)
            {
                if (arrInt[i] == searchNumber && !isFind)
                {
                    isFind = true;
                    continue;
                }

                if (isFind)
                {
                    sum += arrInt[i];
                }
            }

            if (isFind)
            {
                Console.WriteLine(sum);
            }
            else
            {
                Console.WriteLine("No occurrences were found!");
            }
        }
    }
}
