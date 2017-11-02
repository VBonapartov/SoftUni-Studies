using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtractSentencesByKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string input = Console.ReadLine();

            string pattern = $@"(\w[^.!?]*)?\b{word}\b[^.!?]*";
            MatchCollection matches = Regex.Matches(input, pattern);

            foreach(Match sentence in matches)
            {
                Console.WriteLine(sentence.Value);
            }
        }
    }
}
