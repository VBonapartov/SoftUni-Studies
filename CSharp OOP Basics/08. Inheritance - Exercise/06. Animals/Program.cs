namespace _06._Animals
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Animals;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = GetAnimals();
            PrintAnimals(animals);
        }

        private static List<Animal> GetAnimals()
        {
            List<Animal> animals = new List<Animal>();

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("Beast!"))
            {
                try
                {
                    string animalKind = input;
                    string[] cmdArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    if (cmdArgs.Length != 3)
                    {
                        throw new ArgumentException("Invalid input!");
                    }

                    string name = cmdArgs[0];
                    int age = int.Parse(cmdArgs[1]);
                    string gender = cmdArgs[2];

                    Animal animal = AnimalFactory.GetAnimal(animalKind, name, age, gender);
                    animals.Add(animal);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (TargetInvocationException tie) // from Activator.CreateInstance
                {
                    Console.WriteLine(tie.InnerException.Message);
                }
            }

            return animals;
        }

        private static void PrintAnimals(List<Animal> animals)
        {
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
