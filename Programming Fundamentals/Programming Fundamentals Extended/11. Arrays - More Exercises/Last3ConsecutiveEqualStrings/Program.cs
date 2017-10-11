using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Last3ConsecutiveEqualStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputString = Console.ReadLine().Split(' ');

            int[] consecutiveEqual;

            string previousElement = inputString[0];
            int countEquals = 0;
            int index = int.MinValue;
            for (int i = 1; i < inputString.GetLength(0); i++)
            {
                if (previousElement.Equals(inputString[i]))
                {
                    countEquals++;

                    if(countEquals + 1 == 3)
                    {
                        index = i;
                    }
                }
                else
                {
                    countEquals = 0;
                }

                previousElement = inputString[i];
            }          

            if(index != int.MinValue)
            {
                Console.WriteLine("{0} {0} {0}", inputString[index]);
            }
        }
    }
}
