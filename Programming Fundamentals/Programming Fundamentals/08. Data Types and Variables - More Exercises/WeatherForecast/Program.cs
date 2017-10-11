using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());

            string weather = string.Empty;
            if (number % 1 != 0)
            {
                weather = "Rainy";
            }
            else if (number >= sbyte.MinValue && number <= sbyte.MaxValue)
            {
                weather = "Sunny";
            }
            else if(number >= int.MinValue && number <= int.MaxValue)
            {
                weather = "Cloudy";
            }
            else if (number >= long.MinValue && number <= long.MaxValue)
            {
                weather = "Windy";
            }

            Console.WriteLine(weather);
        }
    }
}
