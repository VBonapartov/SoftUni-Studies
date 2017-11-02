using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTheLetter
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputStr = Console.ReadLine();
            string[] tokens = Console.ReadLine().Split();

            string letter = tokens[0];
            int occurrences = Convert.ToInt32(tokens[1]);

            int index = FindIndexByLetter(inputStr, letter, occurrences);
            Console.WriteLine((index != -1) ? index.ToString() : "Find the letter yourself!");
        }

        private static int FindIndexByLetter(string inputStr, string letter, int occurrences)
        {
            int result = 0;
            int index = -1;
            int countOccurrences = 0;
            while ((index = inputStr.IndexOf(letter, ++index)) != -1 && countOccurrences < occurrences)
            {
                countOccurrences++;
                result = index;
            }

            if (countOccurrences == occurrences)
                return result;
            else
                return - 1;
        }
    }
}
