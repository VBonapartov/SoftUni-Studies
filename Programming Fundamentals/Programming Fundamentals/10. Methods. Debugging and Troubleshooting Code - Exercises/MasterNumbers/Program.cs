using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++)
            {
                bool isMasterNumber = IsPalindrome(i) && SumOfDigitsDivisibleBy7(i) && ContainsEvenDigit(i);

                if(isMasterNumber)
                {
                    Console.WriteLine(i);
                }
            }
        }

        static private bool IsPalindrome(int num)
        {
            string digits = "" + num;
            for (int i = 0; i < digits.Length / 2; i++)
            {
                if (digits[i] != digits[digits.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        static private bool SumOfDigitsDivisibleBy7(int num)
        {
            int sum = 0;
            while(num > 0)
            {
                sum += num % 10;
                num /= 10;
            }

            return (sum % 7 == 0);
        }

        static private bool ContainsEvenDigit(int num)
        {
            while(num > 0)
            {
                if ((num % 10) % 2 == 0)
                    return true;

                num /= 10;
            }

            return false;
        }
    }
}
