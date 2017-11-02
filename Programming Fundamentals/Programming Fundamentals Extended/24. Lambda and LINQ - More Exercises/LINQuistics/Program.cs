using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQuistics
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> collections = new Dictionary<string, HashSet<string>>();

            string input = string.Empty;
            while (!(input = Console.ReadLine().Trim()).Equals("exit"))
            {
                string[] command = input.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                string collection = command[0];

                if (command.Length == 1)
                {
                    if ((collection.Length == 1) && (char.IsDigit(collection[0])))
                    {
                        // if input is digit
                        PrintLowestLengthNMethods(collections, Convert.ToInt32(collection));
                    }
                    else if (collections.ContainsKey(collection))
                    {
                        PrintMethodsByCollection(collections, collection);
                    }
                }
                else 
                {
                    if (!collections.ContainsKey(collection))
                        collections.Add(collection, new HashSet<string>());

                    for (int i = 1; i < command.Length; i++)
                        collections[collection].Add(command[i].Replace("()", ""));
                }
            }

            string[] serMeth = Console.ReadLine().Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string method = serMeth[0];
            string selection = serMeth[1];

            Dictionary<string, List<string>> collectionsWithGivenMethod = TakeAllCollectionsContainsGivenMethod(collections, method, selection);
            PrintCollectionsAndMethods(collectionsWithGivenMethod, true);
        }

        static private void PrintLowestLengthNMethods(Dictionary<string, HashSet<string>> collections, int nMethods)
        {
            Dictionary<string, List<string>> result = collections
                                                          .OrderByDescending(c => c.Value.Count)
                                                          .Take(1)
                                                          .ToDictionary(
                                                                         c => c.Key,
                                                                         c => c.Value
                                                                                  .ToList()
                                                                                  .OrderBy(m => m.Length)
                                                                                  .Take(nMethods)
                                                                                  .ToList()
                                                                        );

            PrintCollectionsAndMethods(result, false);
        }

        static private void PrintMethodsByCollection(Dictionary<string, HashSet<string>> collections, string collection)
        {
            Dictionary<string, List<string>> result = collections
                                                            .Where(c => c.Key.Equals(collection))
                                                            .ToDictionary(
                                                                             c => c.Key,
                                                                             c => c.Value
                                                                                      .ToList()
                                                                                      .OrderByDescending(m => m.Length)
                                                                                      .ThenByDescending(m => m.Distinct().Count())
                                                                                      .ToList()
                                                                          );

            PrintCollectionsAndMethods(result, false);
        }

        static private void PrintCollectionsAndMethods(Dictionary<string, List<string>> collectDict, bool printCollection = false)
        {            
            foreach (KeyValuePair<string, List<string>> collection in collectDict)
            {
                if(printCollection)
                    Console.WriteLine($"{collection.Key}");

                foreach (string method in collection.Value)
                {
                    Console.WriteLine($"* {method}");
                }
            }
        }

        static private Dictionary<string, List<string>> TakeAllCollectionsContainsGivenMethod(Dictionary<string, HashSet<string>> collections, string method, string selection)
        {
            switch(selection)
            {
                case "all":
                    return collections
                             .Where(c => c.Value.Contains(method))
                             .OrderByDescending(c => c.Value.Count())
                             .ThenByDescending(c => c.Value.Min(m => m.Length))
                             .ToDictionary(
                                            c => c.Key,
                                            c => c.Value
                                                      .ToList()
                                                      .OrderByDescending(m => m.Length)
                                                      .ToList()                                          
                                          );

                case "collection":
                    return collections
                            .Where(c => c.Value.Contains(method))
                            .OrderByDescending(c => c.Value.Count())
                            .ThenByDescending(c => c.Value.Min(m => m.Length))
                            .ToDictionary(c => c.Key, c => new List<string>());

                default:
                    return collections.ToDictionary(s => s.Key, s => s.Value.ToList());                    
            }
        }
    }
}
