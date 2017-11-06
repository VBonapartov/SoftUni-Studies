using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AnonymousVox
{
    class Program
    {
        static void Main(string[] args)
        {
            string encodedText = Console.ReadLine();
            List<string> placeholders = Console.ReadLine().Split(new string[] { "}" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            placeholders = placeholders.Select(p => p.Replace("{", "")).Select(p => p.Replace("}", "")).ToList();

            string pattern = @"([A-Za-z]+)(.*)\1";
            MatchCollection matches = Regex.Matches(encodedText, pattern);
            if(matches.Count > 0)
            {
                int index = 0;
                string result = encodedText;
                foreach (Match match in matches)
                {
                    string replacePlaceholder = match.Groups[1].Value + placeholders[index++] + match.Groups[1].Value;

                    int idx = result.IndexOf(match.Groups[0].Value); 
                    if(idx != -1)
                    {
                        result = result.Substring(0, idx) + replacePlaceholder + result.Substring(idx + match.Groups[0].Value.Length);
                    }    
                }

                Console.WriteLine(result);
            }
        }
    }
}
