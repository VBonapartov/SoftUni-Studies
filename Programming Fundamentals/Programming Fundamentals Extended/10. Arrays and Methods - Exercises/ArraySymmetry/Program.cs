using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySymmetry
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrStr = Console.ReadLine().Split(' ');

            int middle = (int)Math.Ceiling(arrStr.GetLength(0) / 2.00);
            string result = "Yes";
            for (int i = 0; i < middle; i++)
            {
                if (arrStr[i] != arrStr[arrStr.GetLength(0) - 1 - i])
                {
                    result = "No";
                    break;
                }
              
            }
            Console.WriteLine(result);
        }
    }
}
