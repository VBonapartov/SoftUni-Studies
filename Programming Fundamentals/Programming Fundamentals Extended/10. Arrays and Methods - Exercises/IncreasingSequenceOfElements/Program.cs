using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncreasingSequenceOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrInt = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            int previousElement = int.MinValue;
            string result = "Yes";
            for (int i = 0; i < arrInt.GetLength(0); i++)
            {
                if (arrInt[i] < previousElement)
                {
                    result = "No";
                    break;
                }
                previousElement = arrInt[i];
            }
            Console.WriteLine(result);
        }        
    }
}
