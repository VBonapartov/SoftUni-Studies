using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BoomingCannon
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string input = Console.ReadLine();

            List<string> destroyedTargets = new List<string>();

            string pattern = @"((?<=\\<<<)(?<target>.+?))(?=\\<<<|$)";
            MatchCollection targetsMatches = Regex.Matches(input, pattern);
            foreach (Match targetMatch in targetsMatches)
            {
                string target = ShootOf(tokens, targetMatch.Groups["target"].Value);

                if (!target.Equals(""))
                {
                    destroyedTargets.Add(target);
                }
            }
            
            Console.WriteLine(string.Join(@"/\", destroyedTargets));
        }

        private static string ShootOf(int[] tokens, string target)
        {
            int distance = tokens[0];
            int numberOfDestroyElements = tokens[1];

            string destroyedTargets = string.Empty;
            if (distance + numberOfDestroyElements <= target.Length)
            {
                destroyedTargets = new string(target.Skip(distance).Take(numberOfDestroyElements).ToArray());
            }
            else if (distance < target.Length)
            {
                destroyedTargets = target.Substring(distance);
            }

            return destroyedTargets;
        }
    }
}
