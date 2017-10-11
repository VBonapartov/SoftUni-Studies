using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageCharacterDelimiter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrayStr = Console.ReadLine().Split(' ');

            int totalLength = 0;
            int sum = 0;
            for(int i = 0; i < arrayStr.Length; i++)
            {
                string currentStr = arrayStr[i];
                totalLength += currentStr.Length;

                for(int p = 0; p < currentStr.Length; p++)
                {
                    sum += currentStr[p];
                }
            }

            int averageSum = sum / totalLength;
            string delimiter = ((char)averageSum).ToString().ToUpper();

            Console.WriteLine(string.Join(delimiter, arrayStr));
        }
    }
}
