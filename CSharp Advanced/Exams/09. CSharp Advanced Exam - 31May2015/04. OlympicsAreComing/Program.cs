namespace _04.OlympicsAreComing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        private static List<Country> countries;

        static void Main(string[] args)
        {
            countries = GetDataFromInput();
            PrintResult();
        }

        private static List<Country> GetDataFromInput()
        {
            List<Country> countries = new List<Country>();

            string input = string.Empty;

            while(!(input = Console.ReadLine()).Equals("report"))
            {
                string[] cmdArgs = input.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                string athleteName = Regex.Replace(cmdArgs[0], @"\s+", " ").Trim();
                string countryName = Regex.Replace(cmdArgs[1], @"\s+", " ").Trim();

                Country country = countries.FirstOrDefault(c => c.Name.Equals(countryName));

                if(country == null)
                {
                    country = new Country(countryName);
                    countries.Add(country);
                }

                country.AddAthlete(athleteName);
            }

            return countries;
        }

        private static void PrintResult()
        {
            foreach (Country country in countries.OrderByDescending(c => c.NumberOfWins()))
            {
                Console.WriteLine(country);
            }
        }
    }
}
