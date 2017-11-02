using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalizeWords
{
    class Program
    {
        static string[] separators = new string[] { ",", ".", "!", " ", "?", ":", ";", "+", "-", "=" };

        static void Main(string[] args)
        {       
            string input = string.Empty;
            while(!(input = Console.ReadLine().Trim()).Equals("end"))
            {
                string[] words = ExtractWords(input);
                CapitalizeWords(words);

                PrintWords(words);
            }            
        }

        private static string[] ExtractWords(string input)
        {
            string[] words = input.ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }

        private static void CapitalizeWords(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].First().ToString().ToUpper() + words[i].Substring(1);
            }
        }

        private static void PrintWords(string[] words)
        {
            Console.WriteLine(string.Join(", ", words));
        }
    }
}
