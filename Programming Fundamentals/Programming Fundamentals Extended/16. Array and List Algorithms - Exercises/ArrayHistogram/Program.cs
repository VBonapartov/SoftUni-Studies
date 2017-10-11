using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayHistogram
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrayStr = Console.ReadLine().Split(' ');
            
            IEnumerable<IGrouping<string, string>> arrayGroups = arrayStr.GroupBy(x => x).OrderByDescending(x => x.Count());
            foreach(IGrouping<string, string> group in arrayGroups)
            {
                Console.WriteLine($"{group.Key} -> {group.Count()} times ({(group.Count() / (double)arrayStr.Length) * 100:F2}%)");
            }
        }
    }
}
