using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class Dog
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int NumberOfLegs { get; set; }

        public void ProduceSound()
        {
            Console.WriteLine("I'm a Distinguishedog, and I will now produce a distinguished sound! Bau Bau.");
        }
    }

    class Cat
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int IntelligenceQuotient { get; set; }

        public void ProduceSound()
        {
            Console.WriteLine("I'm an Aristocat, and I will now produce an aristocratic sound! Myau Myau.");
        }
    }

    class Snake
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int CrueltyCoefficient { get; set; }

        public void ProduceSound()
        {
            Console.WriteLine("I'm a Sophistisnake, and I will now produce a sophisticated sound! Honey, I'm home.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dog> dogs = new Dictionary<string, Dog>();
            Dictionary<string, Cat> cats = new Dictionary<string, Cat>();
            Dictionary<string, Snake> snakes = new Dictionary<string, Snake>();

            ReadInput(dogs, cats, snakes);
            PrintAnimals(dogs, cats, snakes);
        }

        private static void ReadInput(Dictionary<string, Dog> dogs, Dictionary<string, Cat> cats, Dictionary<string, Snake> snakes)
        {
            string input = string.Empty;
            while (!(input = Console.ReadLine().Trim()).Equals("I'm your Huckleberry"))
            {
                string firstCommand = input.Substring(0, input.IndexOf(" "));

                switch(firstCommand)
                {
                    case "Dog":
                        Dog dog = ReadDog(input);
                        dogs.Add(dog.Name, dog);
                        break;

                    case "Cat":
                        Cat cat = ReadCat(input);
                        cats.Add(cat.Name, cat);
                        break;

                    case "Snake":
                        Snake snake = ReadSnake(input);
                        snakes.Add(snake.Name, snake);
                        break;

                    case "talk":
                        ProduceSound(dogs, cats, snakes, input);
                        break;
                }
            }            
        }

        private static Dog ReadDog(string input)
        {
            string[] command = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            Dog dog = new Dog
            {
                Name = command[1],
                Age = Convert.ToInt32(command[2]),
                NumberOfLegs = Convert.ToInt32(command[3])
            };

            return dog;
        }

        private static Cat ReadCat(string input)
        {
            string[] command = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            Cat cat = new Cat
            {
                Name = command[1],
                Age = Convert.ToInt32(command[2]),
                IntelligenceQuotient = Convert.ToInt32(command[3])
            };

            return cat;
        }

        private static Snake ReadSnake(string input)
        {
            string[] command = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            Snake snake = new Snake
            {
                Name = command[1],
                Age = Convert.ToInt32(command[2]),
                CrueltyCoefficient = Convert.ToInt32(command[3])
            };

            return snake;
        }

        private static void ProduceSound(Dictionary<string, Dog> dogs, Dictionary<string, Cat> cats, Dictionary<string, Snake> snakes, string input)
        {
            string name = input.Substring(input.IndexOf(" ") + 1);

            if(dogs.ContainsKey(name))
            {
                dogs[name].ProduceSound();
            }

            else if(cats.ContainsKey(name))
            {
                cats[name].ProduceSound();
            }
            else
            {
                snakes[name].ProduceSound();
            }
        }

        private static void PrintAnimals(Dictionary<string, Dog> dogs, Dictionary<string, Cat> cats, Dictionary<string, Snake> snakes)
        {
            foreach(KeyValuePair<string, Dog> dog in dogs)
            {
                Console.WriteLine($"Dog: {dog.Value.Name}, Age: {dog.Value.Age}, Number Of Legs: {dog.Value.NumberOfLegs}");
            }

            foreach(KeyValuePair<string, Cat> cat in cats)
            {
                Console.WriteLine($"Cat: {cat.Value.Name}, Age: {cat.Value.Age}, IQ: {cat.Value.IntelligenceQuotient}");
            }

            foreach(KeyValuePair<string, Snake> snake in snakes)
            {
                Console.WriteLine($"Snake: {snake.Value.Name}, Age: {snake.Value.Age}, Cruelty: {snake.Value.CrueltyCoefficient}");
            }
        }
    }
}
