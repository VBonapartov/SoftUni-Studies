using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(?<=[SHDC]|^)(([2-9JQKA]|10)[SHDC])";
            MatchCollection cardsMatches = Regex.Matches(input, pattern);

            List<string> cards = cardsMatches
                                        .Cast<Match>()
                                        .Select(c => c.Groups[1].Value)
                                        .ToList();

            Console.WriteLine(string.Join(", ", cards));
        }
    }
}
