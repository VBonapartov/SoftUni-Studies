using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhoenixGrid
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = string.Empty;
            while(!(message = Console.ReadLine()).Equals("ReadMe"))
            {
                string pattern = @"^([^\n\r\t' '_]{3}(\.[^\n\r\t' '_]{3})*)$";

                bool isValid = Regex.IsMatch(message, pattern);
                if(isValid && IsPalindrome(message))
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
        }

        private static bool IsPalindrome(string message)
        {
            for(int i = 0; i < message.Length / 2; i++)
            {
                if (!message[i].Equals(message[message.Length - 1 - i]))
                    return false;
            }

            return true;
        }
    }
}
