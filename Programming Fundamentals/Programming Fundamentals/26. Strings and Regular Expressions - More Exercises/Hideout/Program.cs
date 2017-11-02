using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hideout
{
    class Program
    {
        static void Main(string[] args)
        {
            string map = Console.ReadLine();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(' ');
                string searchedCharacter = tokens[0];
                string minimumCount = tokens[1];

                string pattern = @"\" + searchedCharacter + "{" + minimumCount + ",}";
                Match hideout = Regex.Match(map, pattern);
                if(hideout.Success)
                {
                    Console.WriteLine($"Hideout found at index {hideout.Index} and it is with size {hideout.Length}!");
                    break;
                }
            }
        }
    }
}
