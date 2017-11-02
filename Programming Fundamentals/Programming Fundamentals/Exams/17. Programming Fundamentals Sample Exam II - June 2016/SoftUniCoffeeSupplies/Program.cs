using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SoftUniCoffeeSupplies
{
    class CoffeeDrinker
    {
        public string Name { get; set; }
        public Coffee CoffeeType { get; set; }
    }

    class Coffee
    {
        public string Name { get; set; }
        public int Quantity { get; set; } = 0;
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] delimiters = Console.ReadLine().Split();

            string delimiterOne = delimiters[0];
            string delimiterTwo = delimiters[1];            

            List<CoffeeDrinker> coffeeDrinkers = new List<CoffeeDrinker>();
            List<Coffee> coffeeTypes = new List<Coffee>();

            ReadCoffeeDrinkersAndCoffeeTypes(coffeeDrinkers, coffeeTypes, delimiterOne, delimiterTwo);
            ReadCoffeeCups(coffeeDrinkers, coffeeTypes);

            PrintReport(coffeeDrinkers, coffeeTypes);
        }

        private static void ReadCoffeeDrinkersAndCoffeeTypes(List<CoffeeDrinker> coffeeDrinkers, List<Coffee> coffeeTypes, string delimiterOne, string delimiterTwo)
        {
            string command = string.Empty;
            while (!(command = Console.ReadLine()).Equals("end of info"))
            {
                if (Regex.IsMatch(command, $@"(\w+)(?:{Regex.Escape(delimiterOne)})(\w+)"))
                {
                    string[] personAndCoffee = Regex.Split(command, Regex.Escape(delimiterOne));

                    CoffeeDrinker drinker = new CoffeeDrinker
                    {
                        Name = personAndCoffee[0],
                        CoffeeType = new Coffee { Name = personAndCoffee[1] }
                    };

                    if (!coffeeTypes.Any(x => x.Name == drinker.CoffeeType.Name))
                    {
                        coffeeTypes.Add(new Coffee { Name = personAndCoffee[1] });
                    }

                    coffeeDrinkers.Add(drinker);
                }
                else
                {
                    string[] coffeeAndQuantity = Regex.Split(command, Regex.Escape(delimiterTwo));

                    Coffee coffee = new Coffee
                    {
                        Name = coffeeAndQuantity[0],
                        Quantity = int.Parse(coffeeAndQuantity[1])
                    };

                    if (coffeeTypes.Any(x => x.Name == coffee.Name))
                    {
                        int index = coffeeTypes.FindIndex(x => x.Name == coffee.Name);
                        coffeeTypes[index].Quantity += coffee.Quantity;
                    }
                    else
                    {
                        coffeeTypes.Add(coffee);
                    }
                }
            }

            foreach (Coffee coffee in coffeeTypes.Where(x => x.Quantity <= 0))
            {
                Console.WriteLine($"Out of {coffee.Name}");
            }
        }

        private static void ReadCoffeeCups(List<CoffeeDrinker> coffeeDrinkers, List<Coffee> coffeeTypes)
        {
            string command = string.Empty;
            while (!(command = Console.ReadLine()).Equals("end of week"))
            {
                string[] personAndCoffeCups = command.Split();
                string person = personAndCoffeCups[0];
                int cups = int.Parse(personAndCoffeCups[1]);

                int indxP = coffeeDrinkers.FindIndex(x => x.Name == person);
                string coffeeName = coffeeDrinkers[indxP].CoffeeType.Name;
                int indxC = coffeeTypes.FindIndex(x => x.Name == coffeeName);

                coffeeTypes[indxC].Quantity -= cups;
                if (coffeeTypes[indxC].Quantity <= 0)
                {
                    Console.WriteLine($"Out of {coffeeName}");
                }
            }
        }

        private static void PrintReport(List<CoffeeDrinker> coffeeDrinkers, List<Coffee> coffeeTypes)
        {
            List<string> coffeeNames = new List<string>();

            Console.WriteLine("Coffee Left:");
            foreach (Coffee coffee in coffeeTypes.Where(x => x.Quantity > 0).OrderByDescending(x => x.Quantity))
            {
                Console.WriteLine($"{coffee.Name} {coffee.Quantity}");
                coffeeNames.Add(coffee.Name);
            }

            List<CoffeeDrinker> endResults = new List<CoffeeDrinker>();
            foreach (string coffeeName in coffeeNames)
            {
                foreach (CoffeeDrinker drinker in coffeeDrinkers)
                {
                    if (drinker.CoffeeType.Name == coffeeName)
                    {
                        endResults.Add(drinker);
                    }
                }
            }

            Console.WriteLine("For:");
            foreach (CoffeeDrinker drinker in endResults.OrderBy(x => x.CoffeeType.Name).ThenByDescending(p => p.Name))
            {
                Console.WriteLine($"{drinker.Name} {drinker.CoffeeType.Name}");
            }
        }
    }    
}
