using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NthDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            byte index = byte.Parse(Console.ReadLine());

            byte findDigit = FindNthDigit(number, index);
            Console.WriteLine(findDigit);
        }

        static private byte FindNthDigit(int number, byte index)
        {
            byte resultDigit = 0;

            byte currentIndex = 1;
            while(number > 0)
            {
                if (currentIndex != index)
                {
                    currentIndex++;
                    number /= 10;
                    continue;
                }
                else
                {
                    resultDigit = (byte)(number % 10);
                    break;
                }
            }

            return resultDigit;
        }
    }
}
