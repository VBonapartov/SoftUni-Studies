namespace _11.PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = GetTrainers();
            ReadElements(trainers);
            PrintTrainers(trainers);
        }

        private static List<Trainer> GetTrainers()
        {
            List<Trainer> trainers = new List<Trainer>();

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("Tournament"))
            {
                string[] cmdArgs = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string trainerName = cmdArgs[0];
                string pokemonName = cmdArgs[1];
                string pokemonElement = cmdArgs[2];
                int pokemonHealth = int.Parse(cmdArgs[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                Trainer trainer = trainers.Where(t => t.Name.Equals(trainerName)).FirstOrDefault();

                if (trainer == null)
                {
                    trainer = new Trainer(trainerName, pokemon);
                    trainers.Add(trainer);
                }
                else
                {
                    trainer.Pokemons.Add(pokemon);
                }
            }

            return trainers;
        }

        private static void ReadElements(List<Trainer> trainers)
        {
            string element = string.Empty;
            while (!(element = Console.ReadLine()).Equals("End"))
            {
                foreach (Trainer trainer in trainers)
                {
                    trainer.CheckPokemonsForElement(element);
                }
            }
        }

        private static void PrintTrainers(List<Trainer> trainers)
        {
            foreach (Trainer trainer in trainers.OrderByDescending(t => t.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}