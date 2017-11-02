using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().ToLower().Trim().Split(' ').ToList();

            Dictionary<string, int> counts = new Dictionary<string, int>();
            for (int i = 0; i < words.Count; i++)
            {
                if (counts.ContainsKey(words[i]))
                {
                    counts[words[i]]++;
                }
                else
                {
                    counts[words[i]] = 1;
                }
            }

            List<string> result = new List<string>();
            foreach (KeyValuePair<string, int> p in counts)
            {
                if (p.Value % 2 != 0)
                {
                    result.Add(p.Key);
                }
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
