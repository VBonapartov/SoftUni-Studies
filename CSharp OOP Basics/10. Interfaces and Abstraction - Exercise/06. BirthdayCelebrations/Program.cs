namespace _06._BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static List<IPerson> citizens = new List<IPerson>();
        private static List<IRobot> robots = new List<IRobot>();
        private static List<IAnimal> pets = new List<IAnimal>();

        public static void Main(string[] args)
        {
            GetCitizensRobotsPets();
            PrintAllBirthdaysInSpecificYear();
        }

        private static void GetCitizensRobotsPets()
        {
            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("End"))
            {
                string[] cmdArgs = input.Split(' ');
                string type = cmdArgs[0];

                switch (type)
                {
                    case "Citizen":
                        string citizenName = cmdArgs[1];
                        int age = int.Parse(cmdArgs[2]);
                        string citizenId = cmdArgs[3];
                        string citizenBirthday = cmdArgs[4];

                        citizens.Add(new Citizen(citizenName, age, citizenId, citizenBirthday));
                        break;

                    case "Robot":
                        string model = cmdArgs[1];
                        string robotId = cmdArgs[2];

                        robots.Add(new Robot(model, robotId));
                        break;

                    case "Pet":
                        string petName = cmdArgs[1];
                        string petBirthday = cmdArgs[2];

                        pets.Add(new Pet(petName, petBirthday));
                        break;
                }
            }
        }

        private static void PrintAllBirthdaysInSpecificYear()
        {
            string year = Console.ReadLine();

            foreach (Citizen citizen in citizens)
            {
                if (citizen.Birthday.EndsWith(year))
                {
                    Console.WriteLine(citizen.Birthday);
                }
            }

            foreach (Pet pet in pets)
            {
                if (pet.Birthday.EndsWith(year))
                {
                    Console.WriteLine(pet.Birthday);
                }
            }
        }
    }
}
