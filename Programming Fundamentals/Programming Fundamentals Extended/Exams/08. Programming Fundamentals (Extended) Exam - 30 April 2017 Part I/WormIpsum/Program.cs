using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WormIpsum
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("Worm Ipsum"))
            {
                string pattern = @"^[A-Z][^.]*?\.$";

                bool isValidSentence = Regex.IsMatch(input, pattern);
                if(isValidSentence)
                {
                    string sentence = WordsProcessing(input);
                    Console.WriteLine(sentence);
                }
            }
        }

        private static string WordsProcessing(string sentence)
        {
            string[] words = sentence.TrimEnd('.').Split(' ');

            StringBuilder resultSntence = new StringBuilder(sentence.Length);
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];

                bool isDuplicatedChars = word.GroupBy(x => x).Any(g => g.Count() > 1);
                if (isDuplicatedChars)
                {
                    char mostOccurrenceChar = word.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
                    word = Regex.Replace(word, @"[A-Za-z]", mostOccurrenceChar.ToString());
                }

                if(resultSntence.Length > 0)
                {
                    resultSntence.Append(" ");
                }

                resultSntence.Append(word);
            }

            resultSntence.Append(".");
            return resultSntence.ToString();
        }
    }
}
