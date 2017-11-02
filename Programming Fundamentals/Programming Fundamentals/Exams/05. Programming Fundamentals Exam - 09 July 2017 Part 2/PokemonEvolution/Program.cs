using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PokemonEvolution
{
    class Evolution
    {
        public string EvolutionType { get; set; }
        public int EvolutionIndex { get; set; }
    }

    class Pokemon
    {
        public string Name { get; set; }
        public List<Evolution> Evolutions { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();            

            output.AppendFormat($"# {this.Name}");
            foreach(Evolution evolution in this.Evolutions)
            {
                if(output.Length > 0)
                    output.Append(Environment.NewLine);

                output.AppendFormat($"{evolution.EvolutionType} <-> {evolution.EvolutionIndex}");
            }

            return output.ToString();
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            List<Pokemon> pokemons = new List<Pokemon>();

            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("wubbalubbadubdub"))
            {
                string[] tokens = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string pokemonName = tokens[0];

                if (tokens.Length > 1)
                {
                    AddPokemonInfo(pokemons, tokens);
                }
                else
                {
                    PrintPokemonByName(pokemons, pokemonName);
                }
            }

            PrintAllPokemons(pokemons);
        }

        private static void AddPokemonInfo(List<Pokemon> pokemons, string[] tokens)
        {
            string pokemonName = tokens[0];
            string evolutionType = tokens[1];
            int evolutionIndex = Convert.ToInt32(tokens[2]);

            evolutionType = tokens[1];
            evolutionIndex = Convert.ToInt32(tokens[2]);

            if (!pokemons.Exists(p => p.Name.Equals(pokemonName)))
            {
                Pokemon newPokemon = new Pokemon
                {
                    Name = pokemonName,
                    Evolutions = new List<Evolution> { }
                };

                pokemons.Add(newPokemon);
            }

            Pokemon pokemon = pokemons.Where(p => p.Name.Equals(pokemonName)).First();
            Evolution evolution = new Evolution
            {
                EvolutionType = evolutionType,
                EvolutionIndex = evolutionIndex
            };
            pokemon.Evolutions.Add(evolution);
        }

        private static void PrintAllPokemons(List<Pokemon> pokemons)
        {
            foreach (Pokemon pokemon in pokemons)
            {
                pokemon.Evolutions = pokemon.Evolutions.OrderByDescending(e => e.EvolutionIndex).ToList();
                Console.WriteLine(pokemon);
            }
        }

        private static void PrintPokemonByName(List<Pokemon> pokemons, string pokemonName)
        {
            if(pokemons.Exists(p => p.Name.Equals(pokemonName)))
            {
                Pokemon pokemon = pokemons.Where(p => p.Name.Equals(pokemonName)).First();
                Console.WriteLine(pokemon);
            }
        }
    }
}
