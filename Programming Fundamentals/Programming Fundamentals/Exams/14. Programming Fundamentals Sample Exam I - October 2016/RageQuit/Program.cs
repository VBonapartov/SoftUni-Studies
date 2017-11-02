using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @".+?\d+";
            MatchCollection stringNumberPairs = Regex.Matches(input, pattern);

            StringBuilder output = new StringBuilder();
            foreach(Match stringNumberPair in stringNumberPairs)
            {
                Match matchStr = Regex.Match(stringNumberPair.Value, @"[^0-9]+");
                string str = matchStr.Value.ToUpper();

                Match matchNumber = Regex.Match(stringNumberPair.Value, @"[0-9]+");
                int number = Convert.ToInt32(matchNumber.Value);

                for(int i = 0; i < number; i++)
                {
                    output.Append(str);
                }
            }

            Console.WriteLine($"Unique symbols used: {output.ToString().Distinct().Count()}");
            Console.WriteLine(output);
        }
    }
}
