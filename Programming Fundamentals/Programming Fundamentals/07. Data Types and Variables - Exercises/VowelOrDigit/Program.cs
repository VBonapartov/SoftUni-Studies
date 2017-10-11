using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowelOrDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            char symbol = char.Parse(Console.ReadLine());

            if(char.IsDigit(symbol))
            {
                Console.WriteLine("digit");
            }
            else if (symbol.Equals('a') || symbol.Equals('e') || symbol.Equals('i') || symbol.Equals('o') || symbol.Equals('u') || symbol.Equals('y'))
            {
                Console.WriteLine("vowel");
            }
            else
            {
                Console.WriteLine("other");
            }
        }
    }
}
