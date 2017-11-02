using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Trim().Split(new string[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);

            double total = 0.00d;
            for(int i = 0; i < tokens.Length; i++)
            {
                total += LettersChangeNumbers(tokens[i]);
            }

            Console.WriteLine($"{total:F2}");
        }

        private static double LettersChangeNumbers(string input)
        {
            char firstLetter = input[0];
            char lastLetter = input[input.Length - 1];
            double number = Convert.ToDouble(input.Substring(1, input.Length - 2));

            int firstLetterPos = char.ToUpper(firstLetter) - 64;
            int lastLetterPos = char.ToUpper(lastLetter) - 64;

            if (Char.IsLower(firstLetter))
            {                
                number *= firstLetterPos;
            }
            else
            {
                number /= firstLetterPos;
            }


            if (Char.IsLower(lastLetter))
            {
                number += lastLetterPos;
            }
            else
            {
                number -= lastLetterPos;
            }

            return number;
        }
    }
}
