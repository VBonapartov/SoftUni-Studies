using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());

            Dictionary<string, decimal> products = new Dictionary<string, decimal>();

            string input = string.Empty;
            while (!(input = Console.ReadLine().Trim()).Equals("end"))
            {
                string[] command = input.Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string product = command[0];
                decimal price = decimal.Parse(command[1]);

                if (products.ContainsKey(product))
                {
                    if (products[product] > price)
                    {
                        products[product] = price;
                    }
                }
                else
                {
                    products.Add(product, price);
                }
            }

            if(budget < products.Sum(s => s.Value))
            {
                Console.WriteLine($"Need more money... Just buy banichka");
            }
            else
            {
                var productsForPrint = products.OrderByDescending(s => s.Value).ThenBy(s => s.Key.Length);

                foreach(KeyValuePair<string, decimal> product in productsForPrint)
                {
                    Console.WriteLine($"{product.Key} costs {product.Value:F2}");
                }               
            }
        }
    }
}
