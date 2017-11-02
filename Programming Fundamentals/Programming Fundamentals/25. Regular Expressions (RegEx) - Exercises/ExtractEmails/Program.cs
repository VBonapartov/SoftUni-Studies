using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(?<=\s)[a-z0-9]+(.|-|_)?\w+@[a-z]+(-?[a-z]+)?(\.\w+)+";

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);
            //Console.WriteLine("Found {0} matches", matches.Count);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
