using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FishStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"(?<fish>(>+)?<\(+('|-|x)>)";
            MatchCollection fishesMatches = Regex.Matches(input, pattern);

            int countFishes = 1;
            foreach(Match fishMatch in fishesMatches)
            {
                string fish = fishMatch.Groups["fish"].Value;

                // tail type
                int tailLen = fish.Where(ch => ch.Equals('>')).Count() - 1;
                string tailType = GetTailType(tailLen);

                // body type
                int bodyLen = fish.Where(ch => ch.Equals('(')).Count();
                string bodyType = GetBodyType(bodyLen);

                // fish status
                char eye = fish[fish.Length - 2];
                string fishStatus = GetFishStatus(eye);

                PrintFish(fish, countFishes, tailLen, tailType, bodyLen, bodyType, fishStatus);
                countFishes++;
            }

            if (fishesMatches.Count == 0)
            {
                Console.WriteLine("No fish found.");
            }
        }

        private static string GetTailType(int tailLen)
        {
            string tailType = string.Empty;
            if (tailLen > 5)
            {
                tailType = "Long";
            }
            else if (tailLen > 1)
            {
                tailType = "Medium";
            }
            else if(tailLen == 1)
            {
                tailType = "Short";
            }
            else
            {
                tailType = "None";
            }

            return tailType;
        }

        private static string GetBodyType(int bodyLen)
        {
            string bodyType = string.Empty;
            if (bodyLen > 10)
            {
                bodyType = "Long";
            }
            else if (bodyLen > 5)
            {
                bodyType = "Medium";
            }
            else
            {
                bodyType = "Short";
            }

            return bodyType;
        }

        private static string GetFishStatus(char eye)
        {
            string fishStatus = string.Empty;
            if (eye.Equals('\''))
            {
                fishStatus = "Awake";
            }
            else if (eye.Equals('-'))
            {
                fishStatus = "Asleep";
            }
            else if (eye.Equals('x'))
            {
                fishStatus = "Dead";
            }

            return fishStatus;
        }

        private static void PrintFish(string fish, int countFishes, int tailLen, string tailType, int bodyLen, string bodyType, string fishStatus)
        {
            Console.WriteLine($"Fish {countFishes}: {fish}");

            if (tailType.Equals("None"))
            {
                Console.WriteLine($"  Tail type: {tailType}");
            }
            else
            {
                Console.WriteLine($"  Tail type: {tailType} ({tailLen * 2} cm)");
            }

            Console.WriteLine($"  Body type: {bodyType} ({bodyLen * 2} cm)");
            Console.WriteLine($"  Status: {fishStatus}");
        }
    }
}
