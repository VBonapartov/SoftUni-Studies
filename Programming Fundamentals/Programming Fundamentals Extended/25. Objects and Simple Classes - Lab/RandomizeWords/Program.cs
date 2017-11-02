using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Trim().Split(' ');

            Random r = new Random();
            for(int i = 0; i < words.Length; i++)
            {
                int randomPos = r.Next(words.Length);
                string old = words[i];
                words[i] = words[randomPos];
                words[randomPos] = old;
            }

            Console.WriteLine($"{string.Join(Environment.NewLine, words)}");
        }
    }
}
