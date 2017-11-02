using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\b[A-Z][a-z]+\s[A-Z][a-z]+\b";

            string names = Console.ReadLine();

            MatchCollection matches = Regex.Matches(names, regex);
            foreach(Match match in matches)
            {
                Console.Write(match.Value + " ");
            }
            Console.WriteLine();
        }
    }
}
