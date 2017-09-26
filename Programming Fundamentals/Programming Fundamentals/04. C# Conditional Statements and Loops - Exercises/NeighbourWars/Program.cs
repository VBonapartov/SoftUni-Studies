using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighbourWars
{
    class Program
    {
        static void Main(string[] args)
        {
            // First line – Pesho’s damage
            // Second line – Gosho’s damage

            int peshoDamage = int.Parse(Console.ReadLine());
            int goshoDamage = int.Parse(Console.ReadLine());

            int healthPesho = 100;
            int healthGosho = 100;
            
            int round = 1;
            while(true)
            {
                string nameOfTheAttacker = string.Empty;
                string nameOfTheAttack = string.Empty;
                string nameOfTheDefendingPlayer = string.Empty;
                int healthOfTheDefendingPlayer = 0;

                if (round % 2 == 0)
                {
                    healthPesho -= goshoDamage;
                    nameOfTheAttacker = "Gosho";
                    nameOfTheAttack = "Thunderous fist";
                    nameOfTheDefendingPlayer = "Pesho";
                    healthOfTheDefendingPlayer = healthPesho;
                }
                else
                {
                    healthGosho -= peshoDamage;
                    nameOfTheAttacker = "Pesho";
                    nameOfTheAttack = "Roundhouse kick";
                    nameOfTheDefendingPlayer = "Gosho";
                    healthOfTheDefendingPlayer = healthGosho;
                }

                if (healthPesho <= 0)
                {
                    Console.WriteLine($"Gosho won in {round}th round.");
                    break;
                }
                else if (healthGosho <= 0)
                {
                    Console.WriteLine($"Pesho won in {round}th round.");
                    break;
                }

                if (round % 3 == 0)
                {
                    healthPesho += 10;
                    healthGosho += 10;
                }

                Console.WriteLine($"{nameOfTheAttacker} used {nameOfTheAttack} and reduced {nameOfTheDefendingPlayer} to {healthOfTheDefendingPlayer} health.");

                round++;
            }
        }
    }
}
