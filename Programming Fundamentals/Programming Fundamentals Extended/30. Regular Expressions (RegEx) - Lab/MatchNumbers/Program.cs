using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))";

            string numberStrings = Console.ReadLine();

            MatchCollection numbers = Regex.Matches(numberStrings, regex);
            foreach (Match number in numbers)
            {
                Console.Write(number.Value + " ");
            }

            Console.WriteLine();
        }
    }
}
