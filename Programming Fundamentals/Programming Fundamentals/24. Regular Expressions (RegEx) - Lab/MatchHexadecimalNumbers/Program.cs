using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchHexadecimalNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\b(?:0x)?[0-9A-F]+\b";

            string hexadecimal = Console.ReadLine();

            MatchCollection hexadecimalMatches = Regex.Matches(hexadecimal, regex);
            var matchedHexadecimal = hexadecimalMatches
                                            .Cast<Match>()
                                            .Select(p => p.Value.Trim())
                                            .ToArray();

            Console.WriteLine(string.Join(" ", matchedHexadecimal));
        }
    }
}
