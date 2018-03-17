namespace _03._WildFarm
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static List<Animal> animals;
        private static List<Food> foods;

        static void Main(string[] args)
        {
            ReadAnimalsAndFoods();
            PrintAnimalsInfo();
        }

        private static void ReadAnimalsAndFoods()
        {
            animals = new List<Animal>();
            foods = new List<Food>();

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("End"))
            {
                Animal animal = GetAnimal(input);
                animals.Add(animal);

                Food food = GetFood();
                foods.Add(food);
            }
        }

        private static Animal GetAnimal(string input)
        {
            string[] cmdArgs = input.Split(' ');
            string animalType = cmdArgs[0];
            string animalName = cmdArgs[1];
            double animalWeight = double.Parse(cmdArgs[2]);

            double wingSize;
            string animalLivingRegion = string.Empty;
            string breed = string.Empty;

            switch (animalType)
            {
                case "Cat":
                    animalLivingRegion = cmdArgs[3];
                    breed = cmdArgs[4];
                    return new Cat(animalName, animalWeight, animalLivingRegion, breed);

                case "Tiger":                    
                    animalLivingRegion = cmdArgs[3];
                    breed = cmdArgs[4];
                    return new Tiger(animalName, animalWeight, animalLivingRegion, breed);

                case "Dog":
                    animalLivingRegion = cmdArgs[3];
                    return new Dog(animalName, animalWeight, animalLivingRegion);

                case "Mouse":
                    animalLivingRegion = cmdArgs[3];
                    return new Mouse(animalName, animalWeight, animalLivingRegion);

                case "Hen":
                    wingSize = double.Parse(cmdArgs[3]);
                    return new Hen(animalName, animalWeight, wingSize);

                case "Owl":
                    wingSize = double.Parse(cmdArgs[3]);
                    return new Owl(animalName, animalWeight, wingSize);

                default:
                    return null;
            }
        }

        private static Food GetFood()
        {
            string[] foodArgs = Console.ReadLine().Split(' ');
            string foodType = foodArgs[0];
            int foodQuantity = int.Parse(foodArgs[1]);

            switch (foodType)
            {
                case "Vegetable":
                    return new Vegetable(foodQuantity);

                case "Fruit":
                    return new Fruit(foodQuantity);

                case "Meat":
                    return new Meat(foodQuantity);

                case "Seeds":
                    return new Seeds(foodQuantity);

                default:
                    return null;
            }
        }

        private static void PrintAnimalsInfo()
        {
            for (int i = 0; i < animals.Count; i++)
            {
                Console.WriteLine(animals[i].MakeSound());

                try
                {
                    animals[i].TryEatFood(foods[i]);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }                
            }

            for (int i = 0; i < animals.Count; i++)
            {
                Console.WriteLine(animals[i]);
            }
        }
    }
}
