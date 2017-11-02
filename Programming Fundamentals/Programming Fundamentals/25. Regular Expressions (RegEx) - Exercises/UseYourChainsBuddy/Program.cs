using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UseYourChainsBuddy
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadInput();
        }

        private static void ReadInput()
        {
            Stream inputStream = Console.OpenStandardInput();
            byte[] bytes = new byte[2000]; 
            int outputLength = inputStream.Read(bytes, 0, 2000);
            string input = Encoding.UTF8.GetString(bytes);

            string result = DecryptText(input);
            Console.WriteLine(result);            
        }

        private static string DecryptText(string input)
        {
            string pattern = @"<p>(?<text>.*?)<\/p>";
            MatchCollection tagsMatches = Regex.Matches(input, pattern);

            StringBuilder result = new StringBuilder();
            foreach (Match tag in tagsMatches)
            {
                string text = tag.Groups["text"].Value;

                //replace symbols with space
                text = Regex.Replace(text, @"[^a-z0-9]", " ");

                //replace multiply spaces with single
                text = Regex.Replace(text, @"\s+|\n+", " ");

                //convert letters
                text = ConvertLetters(text);

                result.Append(text);
            }

            return result.ToString();
        }

        private static string ConvertLetters(string text)
        {
            text = new string(
                               text
                                  .Select(ch =>
                                                {
                                                    if ((ch >= 'a') && (ch <= 'm'))
                                                    {
                                                        return (char)(ch + 13);
                                                    }
                                                    else if (((ch >= 'n') && (ch <= 'z')))
                                                    {
                                                        return (char)(ch - 13);
                                                    }

                                                    return ch;
                                                })
                                  .ToArray()
                             );

            return text;
        }
    }
}
