using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDessert
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal amountOfCash = decimal.Parse(Console.ReadLine());
            int numberOfGuests = int.Parse(Console.ReadLine());
            decimal priceOfBananas = decimal.Parse(Console.ReadLine());
            decimal priceOfEggs = decimal.Parse(Console.ReadLine());
            decimal priceOfBerries = decimal.Parse(Console.ReadLine());

            int numberOfPortions = (int)Math.Ceiling(numberOfGuests / 6.00) * 6;

            decimal totalPriceBananas = (numberOfPortions / 6.00m) * 2 * priceOfBananas;
            decimal totalPriceEggs = (numberOfPortions / 6.00m) * 4 * priceOfEggs;
            decimal totalPriceBerries = numberOfPortions / 6.00m * 0.2m * priceOfBerries;

            decimal totalPriceOfProducts = totalPriceBananas + totalPriceEggs + totalPriceBerries;
            if (amountOfCash >= totalPriceOfProducts)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {totalPriceOfProducts:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {(totalPriceOfProducts - amountOfCash):F2}lv more.");
            }
        }
    }
}
