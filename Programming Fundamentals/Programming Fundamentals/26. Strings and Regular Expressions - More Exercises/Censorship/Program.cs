using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Censorship
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string sentence = Console.ReadLine();

            sentence = Regex.Replace(sentence, $@"{word}", new string('*', word.Length));
            Console.WriteLine(sentence);
        }
    }
}
