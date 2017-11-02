using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostValuedCustomer
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> products = new Dictionary<string, double>();

            string input = string.Empty;
            while (!(input = Console.ReadLine().Trim()).Equals("Shop is open"))
            {
                string[] command = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string productName = command[0];
                double productPrice = double.Parse(command[1]);

                if(!products.ContainsKey(productName))
                {
                    products.Add(productName, productPrice);
                }
            }

            Dictionary<string, Dictionary<string, int>> customers = new Dictionary<string, Dictionary<string, int>>();

            while (!(input = Console.ReadLine().Trim()).Equals("Print"))
            {
                string[] command = input.Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries);

                if (command[0].Equals("Discount"))
                {
                    DecreaseThePrices(products);
                }
                else
                {
                    string nameOfCustomer = command[0];
                    string[] boughtProducts = command[1].Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);


                    if (!customers.ContainsKey(nameOfCustomer))
                    {
                        customers.Add(nameOfCustomer, new Dictionary<string, int>());
                    }

                    for (int i = 0; i < boughtProducts.Length; i++)
                    {
                        if (products.ContainsKey(boughtProducts[i]))
                        {
                            if (customers[nameOfCustomer].ContainsKey(boughtProducts[i]))
                            {
                                customers[nameOfCustomer][boughtProducts[i]]++;
                            }
                            else
                            {
                                customers[nameOfCustomer].Add(boughtProducts[i], 1);
                            }
                        }
                    }

                }
            }

            string bigestSpender = GetBiggestSpender(products, customers);
            PrintMostValuedCustomer(products, customers, bigestSpender);
        }

        static private void DecreaseThePrices(Dictionary<string, double> products)
        {
            Dictionary<string, double> top3MostExpensiveProducts = products
                                                                        .OrderByDescending(s => s.Value)
                                                                        .Take(3)
                                                                        .ToDictionary(s => s.Key, s => s.Value);

            string[] expensives = top3MostExpensiveProducts.Keys.ToArray();
            for(int i = 0; i < expensives.Length; i++)
            {
                string key = expensives[i];
                products[key] *= 0.90; 
            }       
        }

        static private string GetBiggestSpender(Dictionary<string, double> products, Dictionary<string, Dictionary<string, int>> customers)
        {
            string biggestSpender = string.Empty;
            double currentMax = 0.00d;
            foreach (KeyValuePair<string, Dictionary<string, int>> customer in customers)
            {
                double total = 0.00d;
                foreach (KeyValuePair<string, int> product in customer.Value)
                {
                    total += product.Value * products[product.Key];
                }

                if (total > currentMax)
                {
                    currentMax = total;
                    biggestSpender = customer.Key;
                }
            }

            return biggestSpender;
        }

        static private void PrintMostValuedCustomer(Dictionary<string, double> products, Dictionary<string, Dictionary<string, int>> customers, string biggestSpender)
        {
            Console.WriteLine($"Biggest spender: {biggestSpender}");
            Console.WriteLine($"^Products bought:");

            Dictionary<string, int> sortedProducts = customers[biggestSpender]
                                                                         .OrderByDescending(s => products[s.Key])
                                                                         .ToDictionary(s => s.Key, s => s.Value);

            double total = 0.00d;
            foreach (KeyValuePair<string, int> product in sortedProducts)
            {
                Console.WriteLine($"^^^{product.Key}: {products[product.Key]:F2}");
                total += product.Value * products[product.Key];
            }

            Console.WriteLine($"Total: {total:F2}");
        }
    }
}
