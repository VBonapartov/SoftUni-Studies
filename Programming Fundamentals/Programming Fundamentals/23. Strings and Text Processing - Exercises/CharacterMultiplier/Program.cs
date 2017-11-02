using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split(' ');

            string str1 = tokens[0];
            string str2 = tokens[1];

            int result = CharacterMultiplier(str1, str2);
            Console.WriteLine(result);
        }

        private static int CharacterMultiplier(string str1, string str2)
        {
            int sum = 0;

            int maxNumberOfElements = Math.Max(str1.Length, str2.Length);
            for (int i = 0; i < maxNumberOfElements; i++)
            {
                if((i < str1.Length) && (i < str2.Length))
                {
                    sum += str1[i] * str2[i];
                }
                else if(i < str1.Length)
                {
                    sum += str1[i];
                }
                else
                {
                    sum += str2[i];
                }
            }


            return sum;
        }
    }
}
