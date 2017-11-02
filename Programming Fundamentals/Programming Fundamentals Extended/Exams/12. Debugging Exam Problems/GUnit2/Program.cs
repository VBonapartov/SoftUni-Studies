using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GUnit2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 90/100 

            SortedDictionary<string, SortedDictionary<string, SortedSet<string>>> classes = new SortedDictionary<string, SortedDictionary<string, SortedSet<string>>>();
            Dictionary<string, int> classUnits = new Dictionary<string, int>();

            string pattern = @"^([A-Z][a-zA-Z0-9]+)\s\|\s([A-Z][a-zA-Z0-9]+)\s\|\s([A-Z][a-zA-Z0-9]+)$";

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("It's testing time!"))
            {
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string clas = match.Groups[1].Value;
                    string method = match.Groups[2].Value;
                    string test = match.Groups[3].Value;

                    if (!classes.ContainsKey(clas))
                    {
                        classes.Add(clas, new SortedDictionary<string, SortedSet<string>> { });
                        classUnits.Add(clas, 0);
                    }

                    if (!classes[clas].ContainsKey(method))
                    {
                        classes[clas].Add(method, new SortedSet<string> { });
                    }

                    if (!classes[clas][method].Contains(test))
                    {
                        classes[clas][method].Add(test);
                        classUnits[clas] += 1;
                    }
                }
            }

            Dictionary<string, SortedDictionary<string, SortedSet<string>>> sortedClasses = classes
                                                                        .OrderByDescending(c => classUnits[c.Key])
                                                                        .ThenBy(c => c.Value.Count())
                                                                        .ToDictionary(c => c.Key, c => c.Value);

            foreach (KeyValuePair<string, SortedDictionary<string, SortedSet<string>>> clas in sortedClasses)
            {
                Console.WriteLine($"{clas.Key}:");

                foreach (KeyValuePair<string, SortedSet<string>> method in clas.Value.OrderByDescending(m => m.Value.Count))
                {
                    Console.WriteLine($"##{method.Key}");

                    foreach (string test in method.Value.OrderBy(t => t.Length))
                    {
                        Console.WriteLine($"####{test}");
                    }
                }
            }
        }
    }
}
