using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HappinessIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string happyPattern = @"((:[D\)\*\]\}])|(;[\)\]\}])|([\(\*c\[]:)|(\[;))";
            string sadPattern = @"((:[\(\[\{c])|(;[\(\[\{])|([D\)\]]:)|(\];))";

            MatchCollection happyMatches = Regex.Matches(input, happyPattern);
            MatchCollection sadMatches = Regex.Matches(input, sadPattern);

            int happyEmoticonsCount = happyMatches.Count;
            int sadEmoticonsCount = sadMatches.Count;

            if (sadEmoticonsCount > 0)
            {
                double happinessIndex = happyEmoticonsCount / (double)sadEmoticonsCount;

                string emoticon = string.Empty;
                if (happinessIndex >= 2)
                {
                    emoticon = ":D";
                }
                else if (happinessIndex > 1)
                {
                    emoticon = ":)";
                }
                else if (happinessIndex == 1)
                {
                    emoticon = ":|";
                }
                else if (happinessIndex < 1)
                {
                    emoticon = ":(";
                }

                Console.WriteLine($"Happiness index: {happinessIndex:F2} {emoticon}");
                Console.WriteLine($"[Happy count: {happyEmoticonsCount}, Sad count: {sadEmoticonsCount}]");
            }           
        }
    }
}
