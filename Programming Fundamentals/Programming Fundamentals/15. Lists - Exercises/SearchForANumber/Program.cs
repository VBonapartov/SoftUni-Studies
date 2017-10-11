using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchForANumber
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfNumbers = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
            int[] arrayOfNumbers = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();

            // Take first N elements
            listOfNumbers = listOfNumbers.Take(arrayOfNumbers[0]).ToList();

            // Delete first K elements
            listOfNumbers.RemoveRange(0, arrayOfNumbers[1]);

            // Search number P in collection
            bool isInList = listOfNumbers.IndexOf(arrayOfNumbers[2]) != -1;

            if(isInList)
            {
                Console.WriteLine("YES!");
            }
            else
            {
                Console.WriteLine("NO!");
            }
        }
    }
}
