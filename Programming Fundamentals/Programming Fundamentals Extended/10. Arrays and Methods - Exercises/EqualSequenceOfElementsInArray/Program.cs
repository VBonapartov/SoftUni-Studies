using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualSequenceOfElementsInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrInt = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            int previousElement = arrInt[0];
            string result = "Yes";
            for (int i = 1; i < arrInt.GetLength(0); i++)
            {
                if (arrInt[i] != previousElement)
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
