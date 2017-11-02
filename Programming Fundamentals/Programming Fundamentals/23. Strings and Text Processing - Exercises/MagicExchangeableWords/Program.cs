using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicExchangeableWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split(' ');

            bool isExchangeable = false;
            if (tokens[0].Length >= tokens[1].Length)
            {
                isExchangeable = IsExchangeable(tokens[0], tokens[1]);
            }
            else
            {
                isExchangeable = IsExchangeable(tokens[1], tokens[0]);
            }

            Console.WriteLine(isExchangeable ? "true" : "false");
        }

        private static bool IsExchangeable(string str1, string str2)
        {
            Dictionary<char, char> pairsOfChars = new Dictionary<char, char>();
            for (int i = 0; i < str2.Length; i++)
            {
                if (pairsOfChars.ContainsKey(str1[i]))
                {
                    if (!pairsOfChars[str1[i]].Equals(str2[i]))
                        return false;
                }
                else
                {
                    pairsOfChars.Add(str1[i], str2[i]);
                }
            }

            for (int i = str2.Length; i < str1.Length; i++)
            {
                if (!pairsOfChars.ContainsKey(str1[i]))
                    return false;
            }

            return true;
        }
    }
}
