using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MorseCodeUpgraded
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadInput();
        }

        private static void ReadInput()
        {
            string[] codedMessage = Console.ReadLine().Split('|');
            List<char> decodedMessage = codedMessage.Select(s => DecodeMessage(s)).ToList();

            Console.WriteLine(string.Join("", decodedMessage));
        }

        private static char DecodeMessage(string message)
        {
            int totalSum = message.Count(ch => ch.Equals('1')) * 5 + message.Count(ch => ch.Equals('0')) * 3;

            string pattern = @"(\d)\1+";
            MatchCollection seqMatches = Regex.Matches(message, pattern);

            totalSum += seqMatches
                                  .Cast<Match>()
                                  .Select(s => s.Groups[0].Value.Length)
                                  .Sum();                                 

            return (char)totalSum;
        }
    }
}
