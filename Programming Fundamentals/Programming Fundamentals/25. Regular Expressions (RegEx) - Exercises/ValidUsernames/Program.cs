using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List <string> usernames = GetValidUsernames(input);
            Print2UsersWithBiggestSum(usernames);
        }

        private static List<string> GetValidUsernames(string input)
        {
            string pattern = @"\b(?<username>[a-zA-Z]\w{2,24})\b";
            MatchCollection matches = Regex.Matches(input, pattern);

            List<string> usernames = matches
                                            .Cast<Match>()
                                            .Select(u => u.Groups["username"].Value)
                                            .ToList();

            return usernames;
        }

        private static void Print2UsersWithBiggestSum(List<string> usernames)
        {
            int sum = int.MinValue;
            string[] result = new string[2];
            for (int i = 0; i < usernames.Count - 1; i++)
            {
                int currentSum = usernames[i].Length + usernames[i + 1].Length;
                if (currentSum > sum)
                {
                    result[0] = usernames[i];
                    result[1] = usernames[i + 1];

                    sum = currentSum;
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
