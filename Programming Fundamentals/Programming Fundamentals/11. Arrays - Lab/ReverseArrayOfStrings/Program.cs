using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrString = Console.ReadLine().Split(' ');

            //arrString = arrString.Reverse().ToArray();

            int arrLength = arrString.Length;
            for (int i = 0; i < arrLength / 2; i++)
            {
                string currentItem = arrString[i];
                arrString[i] = arrString[arrLength - i - 1];
                arrString[arrLength - i - 1] = currentItem;
            }

            for (int i = 0; i < arrLength; i++)
            {
                Console.Write(arrString[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
