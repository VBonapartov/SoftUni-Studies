using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnlyLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string pattern = @"(?<number>\d\d*)(?<letter>[A-Za-z])";
            message = Regex.Replace(message, pattern, "${letter}${letter}");

            Console.WriteLine(message);
        }
    }
}
