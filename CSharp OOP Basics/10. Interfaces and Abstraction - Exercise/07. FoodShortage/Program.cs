namespace _07._FoodShortage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Buyer> people = GetPeople();
            GoShopping(people);
            TotalAmountOfFoodPurchased(people);
        }

        private static List<Buyer> GetPeople()
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            List<Buyer> people = new List<Buyer>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ');

                switch (cmdArgs.Length)
                {
                    // Citizen 
                    case 4:
                        string citizenName = cmdArgs[0];
                        int citizenAge = int.Parse(cmdArgs[1]);
                        string citizenId = cmdArgs[2];
                        string citizenBirthday = cmdArgs[3];

                        people.Add(new Citizen(citizenName, citizenAge, citizenId, citizenBirthday));
                        break;

                    // Rebel
                    case 3:
                        string rebelName = cmdArgs[0];
                        int rebelAge = int.Parse(cmdArgs[1]);
                        string rebelGroup = cmdArgs[2];

                        people.Add(new Rebel(rebelName, rebelAge, rebelGroup));
                        break;
                }
            }

            return people;
        }

        private static void GoShopping(List<Buyer> people)
        {
            string name = string.Empty;
            while (!(name = Console.ReadLine()).Equals("End"))
            {
                Buyer buyer = people.FirstOrDefault(p => p.Name.Equals(name));

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }
        }

        private static void TotalAmountOfFoodPurchased(List<Buyer> people)
        {
            int sum = people.Sum(c => c.Food);
            Console.WriteLine(sum);
        }
    }
}
