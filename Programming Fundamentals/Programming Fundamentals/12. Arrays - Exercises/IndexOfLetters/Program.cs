using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            char[] letters = new char[26];
            char startChar = 'a';
            for(int i = 0; i < 26; i++)
            {
                letters[i] = startChar++;
            }

            for(int i = 0; i < word.Length; i++)
                for(int index = 0; index < 26; index++)
                    if (word[i].Equals(letters[index]))
                    {
                        Console.WriteLine($"{word[i]} -> {index}");
                    }
        }
    }
}
