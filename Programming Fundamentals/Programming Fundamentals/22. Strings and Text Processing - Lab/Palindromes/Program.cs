using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(new string[] { " ", ",", ".", "?", "!" }, StringSplitOptions.RemoveEmptyEntries);

            HashSet<string> palindromes = new HashSet<string>();
            for(int i = 0; i < text.Length; i++)
            {
                if(IsPalindrome(text[i]))
                {
                    palindromes.Add(text[i]);
                }
            }

            PrintPalindromes(palindromes);
        }

        private static bool IsPalindrome(string word)
        {
            if(string.Compare(word, Reverse(word)) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static string Reverse(string word)
        {
            return new string(word.Reverse().ToArray());
        }

        private static void PrintPalindromes(HashSet<string> palindromes)
        {
            Console.WriteLine(string.Join(", ", palindromes.OrderBy(s => s).ToList()));
        }
    }
}
