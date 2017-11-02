using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortWordsSorted
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console
                                .ReadLine()
                                .ToLower()
                                .Trim()
                                .Split(new[] { '.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '\\', '/', '!', '?', ' '}, StringSplitOptions.RemoveEmptyEntries)
                                .ToList();

            List<string> result = new List<string>();
            result = words.Distinct().Where(x => x.Length < 5).OrderBy(x => x).ToList();
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
