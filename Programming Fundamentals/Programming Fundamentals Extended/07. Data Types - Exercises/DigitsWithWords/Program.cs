using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitsWithWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            char digit = ' ';
            switch(input)
            {
                case "zero":
                    digit = '0';
                    break;
                case "one":
                    digit = '1';
                    break;
                case "two":
                    digit = '2';
                    break;
                case "three":
                    digit = '3';
                    break;
                case "four":
                    digit = '4';
                    break;
                case "five":
                    digit = '5';
                    break;
                case "six":
                    digit = '6';
                    break;
                case "seven":
                    digit = '7';
                    break;
                case "eight":
                    digit = '8';
                    break;
                case "nine":
                    digit = '9';
                    break;
            }
            Console.WriteLine(digit);
        }
    }
}
