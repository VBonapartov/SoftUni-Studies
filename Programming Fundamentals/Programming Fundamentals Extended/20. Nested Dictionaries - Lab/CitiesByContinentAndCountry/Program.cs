using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> continentInfo = new Dictionary<string, Dictionary<string, List<string>>>();
            for(int i = 1; i <= n; i++)
            {
                string[] input = Console.ReadLine().Trim().Split(' ');

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if(continentInfo.ContainsKey(continent))
                {
                    if(continentInfo[continent].ContainsKey(country))
                    {
                        continentInfo[continent][country].Add(city);
                    }
                    else
                    {
                        continentInfo[continent].Add(country, new List<string>() { city });
                    }
                }
                else
                {
                    continentInfo.Add(continent, 
                                        new Dictionary<string, List<string>>()
                                        {
                                            { country, new List<string>() { city } }
                                        }
                                     );
                }
            }

            foreach(KeyValuePair<string, Dictionary<string, List<string>>> continent in continentInfo)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach(KeyValuePair<string, List<string>> country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
