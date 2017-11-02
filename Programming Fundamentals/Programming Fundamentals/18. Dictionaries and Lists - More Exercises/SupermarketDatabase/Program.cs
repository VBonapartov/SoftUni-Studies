using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketDatabase
{
    class Program
    {
        private struct ProductInfo
        {
            public double price;
            public int quantity;
        }

        static void Main(string[] args)
        {
            // Product : {Price, Quantity}
            Dictionary<string, ProductInfo> products = new Dictionary<string, ProductInfo>();

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("stocked"))
            {
                string[] info = input.Split(' ');
                string product = info[0];
                double price = Convert.ToDouble(info[1]);
                int quantity = Convert.ToInt32(info[2]);

                if (products.ContainsKey(product))
                {
                    ProductInfo productInfo = products[product];
                    productInfo.price = price;
                    productInfo.quantity += quantity;

                    products[product] = productInfo;
                }
                else
                {
                    ProductInfo productInfo = new ProductInfo();
                    productInfo.price = price;
                    productInfo.quantity = quantity;

                    products.Add(product, productInfo);
                }
            }

            PrintProducts(products);
        }

        static private void PrintProducts(Dictionary<string, ProductInfo> products)
        {
            double grandTotal = 0.00d;
            foreach (KeyValuePair<string, ProductInfo> product in products)
            {
                ProductInfo productInfo = product.Value;
                double price = productInfo.price;
                int quantity = productInfo.quantity;

                double total = price * quantity;
                grandTotal += total;

                Console.WriteLine($"{product.Key}: ${price:F2} * {quantity} = ${total:F2}");
            }

            Console.WriteLine("------------------------------");
            Console.WriteLine($"Grand Total: ${grandTotal:F2}");
        }
    }
}
