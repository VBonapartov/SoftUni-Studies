using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreyAndBilliard
{
    class Customer
    {
        public string Name { get; set; }
        public Dictionary<string, int> ShopList { get; set; }        
        public decimal Bill { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> products = ReadProducts();       
            List<Customer> customers = ReadCustomers(products);

            PrintCustomers(customers);
        }

        private static Dictionary<string, decimal> ReadProducts()
        {
            int numberOfProducts = int.Parse(Console.ReadLine());

            Dictionary<string, decimal> products = new Dictionary<string, decimal>();
            for (int i = 1; i <= numberOfProducts; i++)
            {
                string[] input = Console.ReadLine().Trim().Split('-');
                string productName = input[0];
                decimal productPrice = decimal.Parse(input[1]);

                products[productName] = productPrice;
            }

            return products;
        }

        private static List<Customer> ReadCustomers(Dictionary<string, decimal> products)
        {
            List<Customer> customers = new List<Customer>();

            string input = string.Empty;
            while (!(input = Console.ReadLine().Trim()).Equals("end of clients"))
            {
                string[] command = input.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                string[] prodInfo = command[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                string customerName = command[0];
                string productName = prodInfo[0];
                int quantity = int.Parse(prodInfo[1]);

                if (!products.ContainsKey(productName)) 
                    continue;

                Customer customer = new Customer
                {
                    Name = customerName,
                    ShopList = new Dictionary<string, int>
                        {
                            { productName, quantity }
                        },
                    Bill = quantity * products[productName]
                };


                if (!customers.Exists(c => c.Name == customer.Name))
                {
                    customers.Add(customer);
                }
                else
                {
                    Customer existingCustomer = customers.First(c => c.Name == customerName);
                    if (!(existingCustomer.ShopList.ContainsKey(productName)))
                    {
                        existingCustomer.ShopList.Add(productName, quantity);
                        existingCustomer.Bill += customer.Bill;
                    }
                    else
                    {
                        existingCustomer.ShopList[productName] += quantity;
                        existingCustomer.Bill += customer.Bill;
                    }
                }
            }

            return customers;
        }

        private static void PrintCustomers(List<Customer> customers)
        {
            customers = customers.OrderBy(s => s.Name).ToList();

            foreach (Customer customer in customers)
            {
                Console.WriteLine($"{customer.Name}");
                foreach(KeyValuePair<string, int> product in customer.ShopList)
                {
                    Console.WriteLine($"-- {product.Key} - {product.Value}");
                }
                Console.WriteLine($"Bill: {customer.Bill:F2}");
            }

            decimal total = customers.Select(s => s.Bill).Sum();
            Console.WriteLine($"Total bill: {total:F2}");
        }
    }
}
