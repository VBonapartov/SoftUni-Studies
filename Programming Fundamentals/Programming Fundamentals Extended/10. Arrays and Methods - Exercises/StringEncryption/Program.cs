using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder result = new StringBuilder();
            for(int i = 1; i <= n; i++)
            {
                char inputChar = char.Parse(Console.ReadLine());
                result.Append(Encrypt(inputChar));
            }
            Console.WriteLine(result);
        }

        static private string Encrypt(char letter)
        {
            string result = string.Empty;

            int ascii = letter;
            string asciiToStr = ascii.ToString();

            result = asciiToStr[0].ToString() + asciiToStr[asciiToStr.Length - 1].ToString();
            result = result.Insert(0, ((char)(ascii + (ascii % 10))).ToString());
            result += ((char)(ascii - Convert.ToInt32(asciiToStr[0].ToString()))).ToString();

            return result;
        }
    }
}
