using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrStr = Console.ReadLine().Split(' ');

            string[] resultStr = new string[arrStr.GetLength(0)];
            resultStr[0] = arrStr[arrStr.GetLength(0) - 1];
            for (int i = 0; i < arrStr.GetLength(0) - 1; i++)
            {
                resultStr[i + 1] = arrStr[i];
            }

            for (int i = 0; i < resultStr.GetLength(0); i++)
            {
                Console.Write(resultStr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
