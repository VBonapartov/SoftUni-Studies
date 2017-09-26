using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDiscount
{
    class Program
    {
        static void Main(string[] args)
        {
            // First line: the group size as an integer
            // Second line: the package as a string

            int groupSize = int.Parse(Console.ReadLine());
            string package = Console.ReadLine();

            Dictionary<string, Dictionary<string, int>> discounts = new Dictionary<string, Dictionary<string, int>>()
            {
                {
                    "Normal",
                    new Dictionary<string, int>()
                    {
                        {"Discount", 5},
                        {"Price", 500}
                    }
                },
                {
                    "Gold",
                    new Dictionary<string, int>()
                    {
                        {"Discount", 10},
                        {"Price", 750}
                    }
                },
                {
                    "Platinum",
                    new Dictionary<string, int>()
                    {
                        {"Discount", 15},
                        {"Price", 1000}
                    }
                }
            };

            int price = 0;
            string hallName = string.Empty;
            if(groupSize <= 50)
            {
                hallName = "Small Hall";
                price = 2500;
            }
            else if(groupSize <= 100)
            {
                hallName = "Terrace";
                price = 5000;
            }
            else if(groupSize <= 120)
            {
                hallName = "Great Hall";
                price = 7500;
            }

            if (groupSize > 120)
            {
                Console.WriteLine("We do not have an appropriate hall.");
            }
            else
            {
                double totalPrice = price + discounts[package]["Price"];
                totalPrice -= (double)(totalPrice * (discounts[package]["Discount"] / 100.00));
                double pricePerPerson = totalPrice / groupSize;

                Console.WriteLine($"We can offer you the {hallName}");
                Console.WriteLine($"The price per person is {pricePerPerson:F2}$");
            }
        }
    }
}
