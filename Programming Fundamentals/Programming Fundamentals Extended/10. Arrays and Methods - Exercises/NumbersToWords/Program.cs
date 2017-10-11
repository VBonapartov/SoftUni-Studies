using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWords
{
    class Program
    {
        static string[] hundreds = new string[10]{"", "one-hundred", "two-hundred", "three-hundred", "four-hundred", "five-hundred", "six-hundred", "seven-hundred", "eight-hundred", "nine-hundred"};
        static string[] tens = new string[10] {"", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"};
        static string[] txtNumbersTo19 = new string[20]{"", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"};

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string result = Letterize(int.Parse(Console.ReadLine()));
                Console.WriteLine(result);
            }
        }

        static private string Letterize(int number)
        {
            string result = string.Empty;
            if (number > 999)
            {
                result = "too large";
            }
            else if(number < -999)
            {
                result = "too small";
            }
            else if((number > 99 && number < 1000) || (number < -99 && number > -1000))
            {
                if (number < 0)
                {
                    result = "minus ";
                }

                number = Math.Abs(number);
                result += hundreds[number / 100];

                if (number % 100 > 19)
                {
                    result += " and " + tens[(number / 10) % 10] + " " + txtNumbersTo19[number % 10];
                }
                else if(number % 100 != 0)
                {
                    result += " and " + txtNumbersTo19[number % 100];
                }
            }

            return result;
        }
    }
}
