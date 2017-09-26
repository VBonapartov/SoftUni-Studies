using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatrePromotions
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfDay = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            // Group 1 -> 0 <= age <= 18
            // Group 2 -> 18 < age <= 64
            // Group 3 -> 64 < age <= 122

            Dictionary<string, List<int>> ticketPrices = new Dictionary<string, List<int>>()
            {
                {
                    "Weekday",
                    new List<int>(){12, 18, 12}
                },
                {
                    "Weekend",
                    new List<int>(){15, 20, 15}
                },
                {
                    "Holiday",
                    new List<int>(){5, 12, 10}
                }
            };

            int group = -1;
            if (age >= 0 && age <= 18)
            {
                group = 0;
            }
            else if(age >18 && age <= 64)
            {
                group = 1;
            }
            else if (age > 64 && age <= 122)
            {
                group = 2;
            }

            if(group != -1)
            {
                Console.WriteLine($"{ticketPrices[typeOfDay][group]}$");
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
