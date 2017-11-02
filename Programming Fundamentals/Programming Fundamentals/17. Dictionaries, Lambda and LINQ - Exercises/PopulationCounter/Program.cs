using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Save Country: {City : Population}
            Dictionary<string, Dictionary<string, int>> citiesPopulation = new Dictionary<string, Dictionary<string, int>>();

            // Save total country population
            Dictionary<string, long> countriesPopulation = new Dictionary<string, long>();

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("report"))
            {
                string[] inputInfo = input.Split('|');

                string city = inputInfo[0];
                string country = inputInfo[1];
                int population = Convert.ToInt32(inputInfo[2]);

                if (citiesPopulation.ContainsKey(country))
                {
                    if(citiesPopulation[country].ContainsKey(city))
                    {
                        citiesPopulation[country][city] += population;
                    }
                    else
                    {
                        citiesPopulation[country].Add(city, population);
                    }

                    countriesPopulation[country] += population;
                }
                else
                {
                    citiesPopulation.Add(country, new Dictionary<string, int>() { { city, population } });
                    countriesPopulation.Add(country, population);
                }
            }

            PrintPopulation(countriesPopulation, citiesPopulation);
        }

        static private void PrintPopulation(Dictionary<string, long> countriesPopulation, Dictionary<string, Dictionary<string, int>> citiesPopulation)
        {
            while(countriesPopulation.Count > 0)
            {
                KeyValuePair<string, long> currentCountryInfo = countriesPopulation.ElementAt(0);

                string country = currentCountryInfo.Key;
                long population = currentCountryInfo.Value;

                for (int p = 0; p < countriesPopulation.Count; p++)
                {
                    KeyValuePair<string, long> coutryInfo = countriesPopulation.ElementAt(p);
                    if (coutryInfo.Value > population)
                    {
                        country = coutryInfo.Key;
                        population = coutryInfo.Value;
                    }
                }
                                
                Console.WriteLine($"{country} (total population: {population})");
                PrintCitiesPopulation(citiesPopulation[country]);

                countriesPopulation.Remove(country);
            }
        }
        
        static private void PrintCitiesPopulation(Dictionary<string, int> citiesPopulation)
        {
            while (citiesPopulation.Count > 0)
            {
                KeyValuePair<string, int> currentCityInfo = citiesPopulation.ElementAt(0);

                string city = currentCityInfo.Key;
                int population = currentCityInfo.Value;

                for (int p = 0; p < citiesPopulation.Count; p++)
                {
                    KeyValuePair<string, int> cityInfo = citiesPopulation.ElementAt(p);
                    if (cityInfo.Value > population)
                    {
                        city = cityInfo.Key;
                        population = cityInfo.Value;
                    }
                }

                citiesPopulation.Remove(city);
                Console.WriteLine($"=>{city}: {population}");
            }
        }
    }
}
