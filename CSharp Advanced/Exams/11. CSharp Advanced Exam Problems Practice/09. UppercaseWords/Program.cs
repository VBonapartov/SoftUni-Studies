namespace _09.UppercaseWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            List<string> text = GetInputData();
            ProcessData(text);
        }

        private static List<string> GetInputData()
        {
            List<string> text = new List<string>();

            string input = string.Empty;

            while(!(input = Console.ReadLine()).Equals("END"))
            {
                text.Add(input);
            }

            return text;
        }

        private static void ProcessData(List<string> text)
        {
            foreach(string line in text)
            {
                string resultLine = GetAndReplaceUpperCaseWords(line);
                Console.WriteLine(SecurityElement.Escape(resultLine));
            }
        }

        private static string GetAndReplaceUpperCaseWords(string line)
        {
            List<string> patterns = new List<string>();
            List<string> replacers = new List<string>();

            string pattern = @"(?<![a-zA-Z])([A-Z]+)(?![A-Za-z])";

            MatchCollection matches = Regex.Matches(line, pattern);

            for (int i = 0; i < matches.Count; i++)
            {
                string word = matches[i].Groups[1].Value;
                string replacer = word;

                replacer = (IsPalindrome(word)) ? 
                            Regex.Replace(replacer, @"[A-Z]", x => String.Format("{0}{0}", x)) :
                            string.Join("", word.Reverse());

                replacers.Add(replacer);
                patterns.Add("(?<![a-zA-Z])(" + word + ")(?![A-Za-z])");
            }

            return ReplaceWords(line, patterns, replacers);
        }

        private static bool IsPalindrome(string word)
        {
            if (word.Length == 1)
            {
                return true;
            }

            int len = word.Length;

            for (int i = 0; i < len / 2; i++)
            {
                if (word[i] != word[len - i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        private static string ReplaceWords(string line, List<string> patterns, List<string> replacers)
        {
            for (int i = 0; i < patterns.Count; i++)
            {
                line = Regex.Replace(line, patterns[i], replacers[i]);
            }

            return line;
        }
    }
}
