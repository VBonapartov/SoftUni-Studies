using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resurrection
{
    class Program
    {
        static void Main(string[] args)
        {
            int amountOfPhoenixes = int.Parse(Console.ReadLine());

            for(int i = 0; i < amountOfPhoenixes; i++)
            {
                int totalLengthOfTheBody = int.Parse(Console.ReadLine());
                decimal totalWidthOfTheBody = decimal.Parse(Console.ReadLine());
                int lengthOfOneWing = int.Parse(Console.ReadLine());

                decimal totalYears = (decimal)Math.Pow(totalLengthOfTheBody, 2) * (totalWidthOfTheBody + 2 * (decimal)lengthOfOneWing);
                Console.WriteLine(totalYears);
            }
        }
    }
}
