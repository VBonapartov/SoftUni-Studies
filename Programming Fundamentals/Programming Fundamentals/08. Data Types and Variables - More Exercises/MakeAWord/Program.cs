using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeAWord
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder word = new StringBuilder();
            for(int i = 1; i <= n; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                word.Append(letter);
            }

            Console.WriteLine($"The word is: {word}");
        }
    }
}
