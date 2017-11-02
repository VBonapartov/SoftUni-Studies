using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSA
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> registryOfSpies = new Dictionary<string, Dictionary<string, int>>();

            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("quit"))
            {
                string[] commandArgs = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string countryName = commandArgs[0];
                string spyName = commandArgs[1];
                int daysInService = Convert.ToInt32(commandArgs[2]);

                if (!registryOfSpies.ContainsKey(countryName))
                {
                    registryOfSpies.Add(countryName, new Dictionary<string, int> { });
                }

                if(!registryOfSpies[countryName].ContainsKey(spyName))
                {
                    registryOfSpies[countryName].Add(spyName, daysInService);
                }
                else
                {
                    registryOfSpies[countryName][spyName] = daysInService;
                }
            }

            PrintRegistryOfSpies(registryOfSpies);
        }

        private static void PrintRegistryOfSpies(Dictionary<string, Dictionary<string, int>> registryOfSpies)
        {
            Dictionary<string, Dictionary<string, int>> sortedRegistryOfSpies = registryOfSpies
                                                                                    .OrderByDescending(s => s.Value.Count)
                                                                                    .ToDictionary(s => s.Key, s => s.Value);

            foreach(KeyValuePair<string, Dictionary<string, int>> country in sortedRegistryOfSpies)
            {
                Console.WriteLine($"Country: {country.Key}");

                foreach (KeyValuePair<string, int> spy in country.Value.OrderByDescending(s => s.Value))
                {
                    Console.WriteLine($"**{spy.Key} : {spy.Value}");
                }
            }
        }
    }
}
