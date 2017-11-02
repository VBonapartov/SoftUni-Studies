using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KeyReplacer
{
    class Program
    {
        static void Main(string[] args)
        {
            string keyString = Console.ReadLine();
            string textString = Console.ReadLine();

            string[] startEndStr = new string[2] { "", "" };
            bool isFind = GetStartAndEndString(keyString, startEndStr);

            if(isFind)
            {
                string result = ExtractStringsFromtext(textString, startEndStr[0], startEndStr[1]);                
                Console.WriteLine(result);
            }
        }

        private static bool GetStartAndEndString(string keyString, string[] startEndStr)
        {
            string pattern = @"(?<start>.*)(\||\<|\\).*(\||\<|\\)(?<end>.*)";
            Match match = Regex.Match(keyString, pattern);

            if (match.Success)
            {
                startEndStr[0] = match.Groups["start"].Value;
                startEndStr[1] = match.Groups["end"].Value;

                return true;
            }

            return false;
        }

        private static string ExtractStringsFromtext(string textString, string start, string end)
        {
            string pattern = $@"{start}(?<text>.*?){end}";
            MatchCollection matches = Regex.Matches(textString, pattern);

            StringBuilder output = new StringBuilder();
            foreach(Match text in matches)
            {
                output.Append(text.Groups["text"].Value);
            }

            if (output.Length == 0)
                output.Append("Empty result");

            return output.ToString();
        }
    }
}
