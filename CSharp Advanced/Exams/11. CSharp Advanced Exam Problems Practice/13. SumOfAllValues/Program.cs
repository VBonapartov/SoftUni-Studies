namespace _13.SumOfAllValues
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            string keysString = Console.ReadLine();
            string textString = Console.ReadLine();

            string[] keys = GetStartEndKeys(keysString);
            SumAllValuesInTextString(textString, keys);
        }

        private static void SumAllValuesInTextString(string textString, string[] keys)
        {
            string startKey = keys[0];
            string endKey = keys[1];

            if(startKey.Equals("") || endKey.Equals(""))
            {
                Console.WriteLine("<p>A key is missing</p>");
                return;
            }

            string pattern = $@"{startKey}(?<content>.*?){endKey}";

            MatchCollection matches = Regex.Matches(textString, pattern);

            if(matches.Count == 0)
            {
                Console.WriteLine("<p>The total value is: <em>nothing</em></p>");
                return;
            }

            double totalSum = 0.0d;

            foreach(Match match in matches)
            {
                string content = match.Groups["content"].Value;

                double num = 0.0d;
                if (double.TryParse(content, out num))
                {
                    totalSum += num;
                }
            }

            Console.WriteLine($"<p>The total value is: <em>{totalSum}</em></p>");
        }

        private static string[] GetStartEndKeys(string keysString)
        {
            string pattern = @"^(?<startKey>[a-zA-Z_]+)\d.*?\d(?<endKey>[a-zA-Z_]+)$";

            Match match = Regex.Match(keysString, pattern);
            if(match.Success)
            {
                string startKey = match.Groups["startKey"].Value;
                string endKey = match.Groups["endKey"].Value;

                return new string[] { startKey, endKey };
            }
            else
            {
                return new string[] { "", "" };
            }
        }
    }
}
