using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitByWordCasing
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new[] {',', ';', ':', '.', '!', '(', ')', '"', '\'', '\\', '/', '[', ']', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> lowerCase = new List<string>();
            List<string> mixedCase = new List<string>();
            List<string> upperCase = new List<string>();

            for(int i = 0; i < input.Length; i++)
            {
                string word = input[i];
                int countLowercaseLetters = 0;
                int countUppercaseLetters = 0;
                for (int p = 0; p < word.Length; p++)
                {
                    if(char.IsLower(word, p))
                    {
                        countLowercaseLetters++;
                        if (countUppercaseLetters > 0)
                            break;
                    }
                    else if (char.IsUpper(word, p))
                    {                        
                        countUppercaseLetters++;
                        if (countLowercaseLetters > 0)
                            break;
                    }
                    else
                    {
                        countLowercaseLetters++;
                        countUppercaseLetters++;
                        break;
                    }
                }

                if(countLowercaseLetters > 0 && countUppercaseLetters == 0)
                {
                    lowerCase.Add(word);
                }
                else if(countUppercaseLetters > 0 && countLowercaseLetters == 0)
                {
                    upperCase.Add(word);
                }
                else
                {
                    mixedCase.Add(word);
                }
            }

            Console.WriteLine("Lower-case: " + string.Join(", ", lowerCase));
            Console.WriteLine("Mixed-case: " + string.Join(", ", mixedCase));
            Console.WriteLine("Upper-case: " + string.Join(", ", upperCase));
        }
    }
}
