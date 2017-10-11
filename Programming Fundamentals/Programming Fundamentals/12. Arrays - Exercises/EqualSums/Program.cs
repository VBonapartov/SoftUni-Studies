using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrInt = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            bool isPrinted = false;
            for (int i = 0; i < arrInt.Length; i++)
            {
                int leftSum = (i > 0) ? GetLeftSum(arrInt, i - 1) : 0;
                int rightSum = (i < arrInt.Length - 1) ? GetRightSum(arrInt, i + 1) : 0;

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    isPrinted = true;
                }
            }

            if(!isPrinted)
            {
                Console.WriteLine("no");
            }

        }

        static private int GetLeftSum(int[] array, int lastElementIndex)
        {
            int sum = 0;
            for(int i = 0; i <= lastElementIndex; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        static private int GetRightSum(int[] array, int firstElementIndex)
        {
            int sum = 0;
            for (int i = firstElementIndex; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }
    }
}
