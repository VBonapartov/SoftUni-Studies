using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicodeCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder output = new StringBuilder();
            foreach(char ch in input)
                output.AppendFormat(GetEscapeSequence(ch));

            Console.WriteLine(output);
        }

        private static string GetEscapeSequence(char c)
        {
            return "\\u" + ((int)c).ToString("X4").ToLower();
        }
    }
}
