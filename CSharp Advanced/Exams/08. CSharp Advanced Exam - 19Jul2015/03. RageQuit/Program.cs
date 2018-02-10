namespace _03.RageQuit
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            RageMessages(input);
        }

        private static void RageMessages(string input)
        {
            StringBuilder sb = new StringBuilder();

            string pattern = @"(?<text>[^\d]+)(?<count>\d+)";

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach(Match match in matches)
            {
                string text = match.Groups["text"].Value;
                int count = int.Parse(match.Groups["count"].Value);

                sb.Append(string.Concat(Enumerable.Repeat(text.ToUpper(), count)));
            }

            Console.WriteLine($"Unique symbols used: {sb.ToString().Distinct().Count()}");
            Console.WriteLine(sb.ToString());
        }
    }
}
