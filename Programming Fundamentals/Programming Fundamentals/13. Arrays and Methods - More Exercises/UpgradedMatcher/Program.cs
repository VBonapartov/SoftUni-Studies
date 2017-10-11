using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpgradedMatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nameOfProducts = Console.ReadLine().Split(' ');
            long[] quantitiesOfTheProducts = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            decimal[] priceOfTheProducts = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("done"))
            {
                string[] product = input.Split(' ');

                int index = Array.IndexOf(nameOfProducts, product[0]);
                long quantity = Convert.ToInt64(product[1]);

                if (index >= quantitiesOfTheProducts.Length || quantitiesOfTheProducts[index] < quantity)
                {
                    Console.WriteLine($"We do not have enough {product[0]}");
                }
                else
                {
                    Console.WriteLine($"{product[0]} x {quantity} costs {(quantity * priceOfTheProducts[index]):F2}");
                    quantitiesOfTheProducts[index] -= quantity;
                }
            }
        }
    }
}
