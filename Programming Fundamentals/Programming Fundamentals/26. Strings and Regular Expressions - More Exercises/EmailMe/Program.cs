using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmailMe
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();

            string pattern = @"(?<leftPart>.*)@(?<rightPart>.*)";
            Match match = Regex.Match(email, pattern);

            if(match.Success)
            {
                string leftPart = match.Groups["leftPart"].Value;
                string rightPart = match.Groups["rightPart"].Value;

                int sumOfLeftPartCharacters = SumCharacters(leftPart);
                int sumOfRightPartCharacters = SumCharacters(rightPart);

                int result = sumOfLeftPartCharacters - sumOfRightPartCharacters;

                if (result >= 0)
                {
                    Console.WriteLine("Call her!");
                }
                else
                {
                    Console.WriteLine("She is not the one.");
                }
            }
        }

        private static int SumCharacters(string text)
        {
            int result = text
                            .Select(ch => (int)ch)
                            .ToArray()
                            .Sum();

            return result;                
        }
    }
}
