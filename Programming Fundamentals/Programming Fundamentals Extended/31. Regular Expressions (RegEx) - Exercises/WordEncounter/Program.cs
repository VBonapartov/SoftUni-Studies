using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordEncounter
{
    class Program
    {
        static void Main(string[] args)
        {
            string arg = Console.ReadLine();
            char filterCharacter = arg[0];
            int filterDigit = Convert.ToInt32(arg[1].ToString());

            List<string> words = new List<string>();
            string sentence = string.Empty;
            while (!(sentence = Console.ReadLine()).Equals("end"))
            {
                if (Regex.IsMatch(sentence, @"^[A-Z].*[.!?]$"))
                {
                    MatchCollection wordsMatches = Regex.Matches(sentence, @"(\w+)");
                    words.AddRange(wordsMatches
                                                .Cast<Match>()
                                                .Where(w => w.Groups[1].Value.Count(ch => ch.Equals(filterCharacter)) >= filterDigit)
                                                .Select(w => w.Groups[1].Value)
                                                .ToList()
                                   );
                }
            }

            Console.WriteLine(string.Join(", ", words));
        }
    }
}