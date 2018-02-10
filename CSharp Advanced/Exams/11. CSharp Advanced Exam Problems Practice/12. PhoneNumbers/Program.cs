namespace _12.PhoneNumbers
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            string input = GetInputData();
            PrintNamePhonePairs(input);
        }

        private static string GetInputData()
        {
            StringBuilder sb = new StringBuilder();

            string input = string.Empty;

            while(!(input = Console.ReadLine()).Equals("END"))
            {
                sb.Append(input);
            }

            return sb.ToString();
        }

        private static void PrintNamePhonePairs(string input)
        {
            StringBuilder sb = new StringBuilder();

            string pattern = @"(?<name>[A-Z][a-zA-Z]*)[^\da-zA-Z+]*(?<phone>[+]*\d[\d\()\/.\-\s]*\d)";

            MatchCollection matches = Regex.Matches(input, pattern);

            if(matches.Count == 0)
            {
                Console.WriteLine("<p>No matches!</p>");
                return;
            }

            sb.Append("<ol>");

            foreach(Match match in matches)
            {
                string name = match.Groups["name"].Value;
                string phone = match.Groups["phone"].Value;

                phone = Regex.Replace(phone, @"[^\d+]", "");

                sb.Append($"<li><b>{name}:</b> {phone}</li>");
            }

            sb.Append("</ol>");

            Console.WriteLine(sb);
        }
    }
}
