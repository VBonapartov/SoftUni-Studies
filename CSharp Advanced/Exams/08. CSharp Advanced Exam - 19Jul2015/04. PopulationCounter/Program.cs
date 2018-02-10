namespace _04.PopulationCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            List<Country> countries = ReadCountriesStats();
            PrintStats(countries);
        }

        private static List<Country> ReadCountriesStats()
        {
            List<Country> countries = new List<Country>();

            string input = string.Empty;

            while(!(input = Console.ReadLine()).Equals("report"))
            {
                string[] cmdArgs = input.Split('|');
                string cityName = cmdArgs[0];
                string countryName = cmdArgs[1];
                long population = long.Parse(cmdArgs[2]);

                Country country = countries.FirstOrDefault(c => c.Name.Equals(countryName));

                if(country == null)
                {
                    country = new Country(countryName);
                    countries.Add(country);
                }

                country.AddCity(cityName, population);
            }

            return countries;
        }

        private static void PrintStats(List<Country> countries)
        {
            foreach(Country country in countries.OrderByDescending(c => c.GetTotalPopulation()))
            {
                Console.WriteLine(country);
            }
        }
    }

    class Country
    {
        private List<City> cities;

        public Country(string name)
        {
            this.Name = name;
            this.cities = new List<City>();
        }

        public string Name { get; private set; }

        public void AddCity(string name, long population)
        {
            City city = new City(name, population);
            this.cities.Add(city);
        }

        public long GetTotalPopulation()
        {
            return this.cities.Sum(c => c.Population);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} (total population: {this.GetTotalPopulation()})");

            foreach (City city in this.cities.OrderByDescending(c => c.Population))
            {
                sb.AppendLine($"=>{city.Name}: {city.Population}");
            }

            return sb.ToString().Trim();
        }
    }

    class City
    {
        public City(string name, long population)
        {
            this.Name = name;
            this.Population = population;
        }

        public string Name { get; private set; }

        public long Population { get; private set; }
    }
}
