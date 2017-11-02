using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlattenDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, string>> flattenDictionary = new Dictionary<string, Dictionary<string, string>>();

            string input = string.Empty;
            while (!(input = Console.ReadLine().Trim()).Equals("end"))
            {
                string[] command = input.Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (command[0].Equals("flatten"))
                {
                    string key = command[1];

                    if (flattenDictionary.ContainsKey(key))
                    {
                        flattenDictionary[key] = flattenDictionary[key]
                                                        .Select(s => s)
                                                        .ToDictionary(s => s.Key + s.Value, s => "");
                    }
                }
                else
                {

                    string key = command[0];
                    string innerKey = command[1];
                    string innerValue = command[2];

                    if(flattenDictionary.ContainsKey(key))
                    {
                        if(flattenDictionary[key].ContainsKey(innerKey))
                        {
                            flattenDictionary[key][innerKey] = innerValue;
                        }
                        else
                        {
                            flattenDictionary[key].Add(innerKey, innerValue);
                        }
                    }
                    else
                    {
                        flattenDictionary.Add(  key,
                                                new Dictionary<string, string>
                                                {
                                                    { innerKey, innerValue }
                                                }
                                              );
                    }

                }

            }

            flattenDictionary = flattenDictionary
                .OrderByDescending(k => k.Key.Length)
                .ToDictionary(k => k.Key, k => k.Value);

            PrintFlattenDictionary(flattenDictionary);
        }

        static private void PrintFlattenDictionary(Dictionary<string, Dictionary<string, string>> flattenDictionary)
        {
            int countTeams = 0;
            foreach (KeyValuePair<string, Dictionary<string, string>> item in flattenDictionary)
            {
                Console.WriteLine($"{item.Key}");

                Dictionary<string, string> sortedItems = item.Value
                                                                .Where(s => s.Value.Length > 0)
                                                                .OrderBy(s => s.Key.Length)                                                    
                                                                .ToDictionary(s => s.Key, s => s.Value);


                int countInnerPairs = 0;
                foreach (KeyValuePair<string, string> inner in sortedItems)
                {
                    Console.WriteLine($"{++countInnerPairs}. {inner.Key} - {inner.Value}");
                }

                List<string> sortedFlattenItems = item.Value
                                .Where(s => s.Value.Length == 0)
                                .Select(s => s.Key)
                                .ToList();

                foreach (string flattenItem in sortedFlattenItems)
                {
                    Console.WriteLine($"{++countInnerPairs}. {flattenItem}");
                }
            }
        }
    }
}
