using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSubstringOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            string pattern = Console.ReadLine().ToLower();

            int lastIndex = -1;
            int countSubstringOccurrences = 0;
            while ((lastIndex = text.IndexOf(pattern, ++lastIndex)) != -1)
                countSubstringOccurrences++;

            Console.WriteLine(countSubstringOccurrences);
        }
    }
}
