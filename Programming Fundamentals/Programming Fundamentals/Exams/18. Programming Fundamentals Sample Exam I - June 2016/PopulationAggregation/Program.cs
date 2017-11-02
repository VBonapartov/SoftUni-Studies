using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PopulationAggregation
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> cities = new Dictionary<string, long>();
            Dictionary<string, int> countries = new Dictionary<string, int>();

            ReadInputInfo(countries, cities);
            PrintAggregatedData(countries, cities);
        }

        private static void ReadInputInfo(Dictionary<string, int> countries, Dictionary<string, long> cities)
        {
            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("stop"))
            {
                string[] inputInfo = input.Split('\\');

                long population = long.Parse(inputInfo[2]);
                string country = string.Empty;
                string city = string.Empty;
                if (Char.IsUpper(inputInfo[0][0]))
                {
                    country = ClearProhibitedSymbols(inputInfo[0]);
                    city = ClearProhibitedSymbols(inputInfo[1]);
                }
                else
                {
                    country = ClearProhibitedSymbols(inputInfo[1]);
                    city = ClearProhibitedSymbols(inputInfo[0]);
                }

                if (!countries.ContainsKey(country))
                {
                    countries.Add(country, 0);
                }

                countries[country]++;
                cities[city] = population;
            }
        }

        private static string ClearProhibitedSymbols(string input)
        {
            return Regex.Replace(input, @"[0-9@#$&]", "");
        }

        private static void PrintAggregatedData(Dictionary<string, int> countries, Dictionary<string, long> cities)
        {
            countries = countries.OrderBy(c => c.Key).ToDictionary(c => c.Key, c => c.Value);
            foreach(KeyValuePair<string, int> country in countries)
            {
                Console.WriteLine($"{country.Key} -> {country.Value}");
            }

            cities = cities.OrderByDescending(c => c.Value).ToDictionary(c => c.Key, c => c.Value);
            foreach (KeyValuePair<string, long> city in cities.Take(3))
            {
                Console.WriteLine($"{city.Key} -> {city.Value}");
            }
        }
    }
}
