namespace _20.OMyGirl
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        private static readonly char[] SpecialSymbols = { '*', '+', '?', '[', ']', '{', '}', ',', '.', '^', '$', '<', '>', '\\', '/', '(', ')', '"' };

        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string text = GetInputText();

            GetAddressFromText(text, key);
        }

        private static string GetInputText()
        {
            StringBuilder sb = new StringBuilder();

            string input = string.Empty;

            while(!(input = Console.ReadLine()).Equals("END"))
            {
                sb.Append(input);
            }

            return sb.ToString();
        }

        private static void GetAddressFromText(string text, string key)
        {
            string keyPattern = CreateKeyPattern(key);

            MatchCollection matches = Regex.Matches(text, keyPattern);

            string address = string.Empty;

            foreach (Match match in matches)
            {
                address += match.Groups["addrPart"].Value;
            }

            Console.WriteLine(address);
        }

        private static string CreateKeyPattern(string key)
        {
            StringBuilder pattern = new StringBuilder();

            if (SpecialSymbols.Contains(key[0]))
            {
                pattern.Append(string.Format("\\" + key[0]));
            }
            else
            {
                pattern.Append(key[0]);
            }

            for (int i = 1; i < key.Length - 1; i++)
            {
                if (Char.IsDigit(key[i]))
                {
                    pattern.Append("\\d*");
                }
                else if (Char.IsUpper(key[i]))
                {
                    pattern.Append("[A-Z]*");
                }
                else if (Char.IsLower(key[i]))
                {
                    pattern.Append("[a-z]*");
                }
                else if (SpecialSymbols.Contains(key[i]))
                {
                    pattern.Append("\\" + key[i]);
                }
                else
                {
                    pattern.Append(key[i]);
                }
            }

            if (SpecialSymbols.Contains(key[key.Length - 1]))
            {
                pattern.Append("\\" + key[key.Length - 1]);
            }
            else
            {
                pattern.Append(key[key.Length - 1]);
            }

            return pattern.ToString() + "(?<addrPart>.{2,6})" + pattern.ToString();
        }
    }
}
