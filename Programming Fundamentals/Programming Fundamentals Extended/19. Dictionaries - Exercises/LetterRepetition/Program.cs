using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterRepetition
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> characterCounter = new Dictionary<char, int>();
            for(int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if(characterCounter.ContainsKey(currentChar))
                {
                    characterCounter[currentChar]++;
                }
                else
                {
                    characterCounter.Add(currentChar, 1);
                }
            }

            foreach(KeyValuePair<char, int> character in characterCounter)
            {
                Console.WriteLine($"{character.Key} -> {character.Value}");
            }
        }
    }
}
