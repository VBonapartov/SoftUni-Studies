namespace _04._ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                List<Person> people = GetPeople();
                List<Product> products = GetProducts();

                ExecutePurchases(people, products);
                PrintPeople(people);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            string[] cmdArgs = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < cmdArgs.Length; i++)
            {
                string[] peopleInfo = cmdArgs[i].Split("=");
                string name = peopleInfo[0];
                decimal money = decimal.Parse(peopleInfo[1]);

                people.Add(new Person(name, money));
            }

            return people;
        }

        private static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            string[] cmdArgs = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < cmdArgs.Length; i++)
            {
                string[] productInfo = cmdArgs[i].Split("=");
                string name = productInfo[0];
                decimal cost = decimal.Parse(productInfo[1]);

                products.Add(new Product(name, cost));
            }

            return products;
        }

        private static void ExecutePurchases(List<Person> people, List<Product> products)
        {
            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("END"))
            {
                string[] cmdArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = cmdArgs[0];
                string productName = cmdArgs[1];

                if (people.Exists(p => p.Name.Equals(name)) && products.Exists(prod => prod.Name.Equals(productName)))
                {
                    Person person = people.Where(p => p.Name.Equals(name)).First();
                    Product product = products.Where(prod => prod.Name.Equals(productName)).First();

                    try
                    {
                        person.BoughtProduct(product);
                        Console.WriteLine($"{name} bought {productName}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private static void PrintPeople(List<Person> people)
        {
            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
