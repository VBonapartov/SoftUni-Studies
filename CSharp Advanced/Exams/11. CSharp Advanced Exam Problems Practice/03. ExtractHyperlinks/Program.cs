namespace _03.ExtractHyperlinks
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
            string input = string.Empty;
            StringBuilder sb = new StringBuilder();

            while (!(input = Console.ReadLine()).Equals("END"))
            {
                sb.Append(input).Append(" ");
            }

            string html = sb.ToString().Replace('\t', ' ');
            List<string> hyperlinks = ExtractHyperlinks(html);
            Console.WriteLine(string.Join(Environment.NewLine, hyperlinks));
        }

        private static List<string> ExtractHyperlinks(string html)
        {
            List<string> hyperlinks = new List<string>();

            string pattern = @"<a\s+[^>]*?href\s*=(?<href>.*?)>.*?<\s*\/\s*a\s*>";

            MatchCollection matches = Regex.Matches(html, pattern);
            foreach (Match match in matches)
            {
                string candidateHref = match.Groups["href"].Value.Trim();

                if (candidateHref[0].Equals('\"'))
                {
                    hyperlinks.Add(candidateHref
                                            .Split(new[] { "\"" }, StringSplitOptions.RemoveEmptyEntries)
                                            .First()
                                  );
                }
                else if (candidateHref[0].Equals('\''))
                {
                    hyperlinks.Add(candidateHref
                                            .Split(new[] { "\'" }, StringSplitOptions.RemoveEmptyEntries)
                                            .First()
                                  );
                }
                else
                {
                    hyperlinks.Add(Regex.Split(candidateHref, @"\s+").First());
                }
            }

            return hyperlinks;
        }
    }
}
