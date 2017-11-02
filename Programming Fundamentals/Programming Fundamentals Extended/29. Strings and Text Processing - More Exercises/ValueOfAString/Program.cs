using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueOfAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputStr = Console.ReadLine().Trim();
            string condition = Console.ReadLine();

            int total = SumASCIICodes(inputStr, condition);
            Console.WriteLine($"The total sum is: {total}");
        }

        private static int SumASCIICodes(string inputStr, string condition)
        {
            int result = 0;

            switch(condition)
            {
                case "UPPERCASE":
                    result = SumUppercaseLetters(inputStr);
                    break;

                case "LOWERCASE":
                    result = SumLowercaseLetters(inputStr);
                    break;
            }

            return result;
        }
        
        private static int SumUppercaseLetters(string input)
        {
            int result = input.Where(c => char.IsUpper(c)).Select(c => (int)c).ToArray().Sum();
            return result;
        }

        private static int SumLowercaseLetters(string input)
        {
            int result = input.Where(c => char.IsLower(c)).Select(c => (int)c).ToArray().Sum();
            return result;
        }
    }
}
