namespace _03.BasicMarkupLanguage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            List<string> bml = ReadInput();
            ParseBML(bml);
        }

        private static List<string> ReadInput()
        {
            List<string> bml = new List<string>();

            string input = string.Empty;

            while(!(input = Console.ReadLine()).Equals("<stop/>"))
            {
                bml.Add(input);
            }

            return bml;                
        }

        private static void ParseBML(List<string> bml)
        {
            int countLines = 0;

            string inversePattern = @"<\s*inverse\s+content\s*=\s*" + '"' + @"(?<content>.+)" + '"' + @"\s*\/\s*>";
            string reversePattern = @"<\s*reverse\s+content\s*=\s*" + '"' + @"(?<content>.+)" + '"' + @"\s*\/\s*>";
            string repeatPattern = @"<\s*repeat\s+value\s*=\s*" + '"' + @"(?<value>.+)" + '"' + @"\s+content\s*=\s*" + '"' + @"(?<content>.+)" + '"' + @"\s*\/\s*>";

            foreach (string line in bml)
            {
                Match inverseMatch = Regex.Match(line, inversePattern);
                Match reverseMatch = Regex.Match(line, reversePattern);
                Match repeatMatch = Regex.Match(line, repeatPattern);

                if(inverseMatch.Success)
                {
                    Console.WriteLine($"{++countLines}. {InverseContent(inverseMatch.Groups["content"].Value)}");
                    continue;
                }

                if (reverseMatch.Success)
                {
                    Console.WriteLine($"{++countLines}. {ReverseContent(reverseMatch.Groups["content"].Value)}");
                    continue;
                }

                if (repeatMatch.Success)
                {
                    int value = int.Parse(repeatMatch.Groups["value"].Value);

                    for (int i = 0; i < value; i++)
                    {
                        Console.WriteLine($"{++countLines}. {repeatMatch.Groups["content"].Value}");
                    }

                    continue;
                }
            }
        }

        private static string InverseContent(string content)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < content.Length; i++)
            {
                if (char.IsUpper(content, i))
                {
                    result.Append(char.ToLower(content[i]));
                }
                else if (char.IsLower(content, i))
                {
                    result.Append(char.ToUpper(content[i]));
                }
                else
                {
                    result.Append(content[i]);
                }
            }

            return result.ToString();
        }

        private static string ReverseContent(string content)
        {
            return new string(content.ToCharArray().Reverse().ToArray());
        }
    }
}
