using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSTyping
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCharacters = int.Parse(Console.ReadLine());

            string[] characters = new string[10];
            characters[0] = " ";
            characters[1] = "";
            characters[2] = "abc";
            characters[3] = "def";
            characters[4] = "ghi";
            characters[5] = "jkl";
            characters[6] = "mno";
            characters[7] = "pqrs";
            characters[8] = "tuv";
            characters[9] = "wxyz";

            StringBuilder message = new StringBuilder(numberOfCharacters);
            for (int i = 1; i <= numberOfCharacters; i++)
            {
                int number = int.Parse(Console.ReadLine());

                int length = number.ToString().Length;
                int idx = number;
                if(number > 9)
                {
                    idx = number % 10;
                }

                message.Append(characters[idx].Substring(length - 1, 1));
            }

            Console.WriteLine(message);
        }
    }
}
