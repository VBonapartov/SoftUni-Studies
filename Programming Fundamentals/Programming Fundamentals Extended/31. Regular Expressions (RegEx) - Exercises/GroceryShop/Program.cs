using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GroceryShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(?<product>[A-Z][a-z]+):(?<price>\d+\.\d{2})$";

            Dictionary<string, double> products = new Dictionary<string, double>();
            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("bill"))
            {
                Match productMatch = Regex.Match(input, pattern);
                if(productMatch.Success)
                {
                    string nameOfTheProduct = productMatch.Groups["product"].Value;
                    double priceOfTheProduct = Convert.ToDouble(productMatch.Groups["price"].Value);

                    products[nameOfTheProduct] = priceOfTheProduct;
                }
            }

            products = products.OrderByDescending(p => p.Value).ToDictionary(p => p.Key, p => p.Value);
            foreach(KeyValuePair<string, double> product in products)
            {
                Console.WriteLine($"{product.Key} costs {product.Value:F2}");
            }
        }
    }
}
