using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountOfCapitalLettersInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrStr = Console.ReadLine().Split(' ');

            int countCapital = 0;
            for (int i = 0; i < arrStr.GetLength(0); i++)
            {
                if ((arrStr[i].Length == 1) && (char.IsUpper(arrStr[i][0])))
                {
                    countCapital++;
                }
            }
            Console.WriteLine(countCapital);
        }
    }
}
