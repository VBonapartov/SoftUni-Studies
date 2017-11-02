using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Weather
{
    class Weather
    {
        public string City { get; set; }
        public double AverageTemp { get; set; }
        public string WeatherType { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Weather> weathers = new List<Weather>();

            string pattern = @"(?<city>[A-Z]{2})(?<averageTemp>\d+\.\d+)(?<weatherType>[A-Za-z]+)\|";

            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("end"))
            {
                Match match = Regex.Match(input, pattern);
                if (!match.Success)
                    continue;

                string city = match.Groups["city"].Value;
                double averageTemp = Convert.ToDouble(match.Groups["averageTemp"].Value);
                string weatherType = match.Groups["weatherType"].Value;

                if(weathers.Exists(w => w.City.Equals(city)))
                {
                    Weather weather = weathers.First(w => w.City.Equals(city));
                    weather.AverageTemp = averageTemp;
                    weather.WeatherType = weatherType;
                }
                else
                {
                    Weather weather = new Weather
                    {
                        City = city,
                        AverageTemp = averageTemp,
                        WeatherType = weatherType
                    };

                    weathers.Add(weather);
                }
            }

            weathers = weathers.OrderBy(w => w.AverageTemp).ToList();
            foreach(Weather weather in weathers)
            {
                Console.WriteLine($"{weather.City} => {weather.AverageTemp:F2} => {weather.WeatherType}");
            }
        }
    }
}
