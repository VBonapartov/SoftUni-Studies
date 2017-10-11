using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arrDouble = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            for(int i = 0; i < arrDouble.Length; i++)
            {
                int roundedNumber = (int)Math.Round(arrDouble[i], MidpointRounding.AwayFromZero);
                Console.WriteLine($"{arrDouble[i]} => {roundedNumber}");
            }
        }
    }
}
