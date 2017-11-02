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
            List<string> listStrings = Console.ReadLine().Trim().Split(new char[] { '.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            listStrings = listStrings.Select(x => x.ToLower()).Distinct().Where(x => (x.Length < 5)).OrderBy(x => x).ToList();
            Console.WriteLine($"{string.Join(", ", listStrings)}");
        }
    }
}
