using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractMiddleElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrInt = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[] result = ExtractMiddlelements(arrInt);
            Console.WriteLine("{ " + string.Join(", ", result) + " }");
        }

        static private int[] ExtractMiddlelements(int[] array)
        {
            int arrayLength = array.Length;
            int[] resultArray;
            if (arrayLength == 1)
            {
                resultArray = new int[1];
                resultArray[0] = array[0];
            }
            else if (arrayLength % 2 == 0)
            {
                resultArray = new int[2];
                resultArray[0] = array[arrayLength / 2 - 1];
                resultArray[1] = array[arrayLength / 2];
            }
            else
            {
                resultArray = new int[3];
                resultArray[0] = array[arrayLength / 2 - 1];
                resultArray[1] = array[arrayLength / 2];
                resultArray[2] = array[arrayLength / 2 + 1];
            }

            return resultArray;
        }
    }
}
