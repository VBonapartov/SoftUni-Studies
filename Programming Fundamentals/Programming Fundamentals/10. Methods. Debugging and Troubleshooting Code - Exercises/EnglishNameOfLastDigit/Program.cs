using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishNameOfLastDigit
{
    class Program
    {
        static string[] digits = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            string name = GetNameOfTheLastDigit(number);
            Console.WriteLine(name);
        }

        static private string GetNameOfTheLastDigit(long number)
        {
            number = Math.Abs(number);
            string name = digits[number % 10];
            return name;
        }
    }
}
