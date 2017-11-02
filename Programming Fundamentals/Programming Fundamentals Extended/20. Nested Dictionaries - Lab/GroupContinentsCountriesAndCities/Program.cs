using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupContinentsCountriesAndCities
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedDictionary<string, SortedDictionary<string, SortedSet<string>>> continentInfo = new SortedDictionary<string, SortedDictionary<string, SortedSet<string>>>();
            for (int i = 1; i <= n; i++)
            {
                string[] input = Console.ReadLine().Trim().Split(' ');

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (continentInfo.ContainsKey(continent))
                {
                    if (continentInfo[continent].ContainsKey(country))
                    {
                        continentInfo[continent][country].Add(city);
                    }
                    else
                    {
                        continentInfo[continent].Add(country, new SortedSet<string>() { city });
                    }
                }
                else
                {
                    continentInfo.Add(continent,
                                        new SortedDictionary<string, SortedSet<string>>()
                                        {
                                            { country, new SortedSet<string>() { city } }
                                        }
                                     );
                }
            }

            foreach (KeyValuePair<string, SortedDictionary<string, SortedSet<string>>> continent in continentInfo)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (KeyValuePair<string, SortedSet<string>> country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
