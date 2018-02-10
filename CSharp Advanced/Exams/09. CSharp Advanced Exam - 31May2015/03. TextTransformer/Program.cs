namespace _03.TextTransformer
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {   
        static void Main(string[] args)
        {
            string text = GetText();

            text = ReplaceMultipleWhitespacesWithASingleOne(text);
            ProcessDataBetweenSpecialSymbols(text);
        }

        private static string GetText()
        {
            StringBuilder sb = new StringBuilder();

            string input = string.Empty;

            while(!(input = Console.ReadLine()).Equals("burp"))
            {
                sb.Append(input);
            }

            return sb.ToString();
        }

        private static string ReplaceMultipleWhitespacesWithASingleOne(string text)
        {
            return Regex.Replace(text, @"\s{2,}", " ");
        }

        private static void ProcessDataBetweenSpecialSymbols(string text)
        {
            StringBuilder sb = new StringBuilder();

            string pattern = @"(?<specialSymbol>[\$\%\&\'])(?<data>[^\$\%\&\']+)\1";

            MatchCollection matches = Regex.Matches(text, pattern);

            foreach (Match match in matches)
            {
                string specialSymbol = match.Groups["specialSymbol"].Value;
                string data = match.Groups["data"].Value;

                sb.Append(TransofrmingCharacters(specialSymbol, data) + " ");
            }

            Console.WriteLine(sb.ToString().Trim());
        }

        private static string TransofrmingCharacters(string specialSymbol, string data)
        {
            string[] SpecialSymbols = new string[] { "", "$", "%", "&", "'" };
            int specialSymbolWeight = Array.IndexOf(SpecialSymbols, specialSymbol);

            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < data.Length; i++)
            {
                if(i % 2 == 0)
                {
                    sb.Append((char)(data[i] + specialSymbolWeight));
                }
                else
                {
                    sb.Append((char)(data[i] - specialSymbolWeight));
                }
            }

            return sb.ToString();
        }
    }
}
