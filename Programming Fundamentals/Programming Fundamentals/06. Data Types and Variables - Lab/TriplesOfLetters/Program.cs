using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriplesOfLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (char ch1 = 'a'; ch1 < 'a' + n; ch1++)
                for (char ch2 = 'a'; ch2 < 'a' + n; ch2++)
                    for (char ch3 = 'a'; ch3 < 'a' + n; ch3++)
                    {
                        Console.WriteLine($"{ch1}{ch2}{ch3}");
                    }
        }
    }
}
