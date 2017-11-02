using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\+359([ |-])2\1\d{3}\1\d{4}\b";

            string phones = Console.ReadLine();

            MatchCollection phoneMatches = Regex.Matches(phones, regex);
            var matchedPhones = phoneMatches
                                    .Cast<Match>()
                                    .Select(p => p.Value.Trim())
                                    .ToArray();

            Console.WriteLine(string.Join(", ", matchedPhones));
        }
    }
}
