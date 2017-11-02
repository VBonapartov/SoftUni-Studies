using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmuneSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialHealth = int.Parse(Console.ReadLine());

            Dictionary<string, int> viruses = new Dictionary<string, int>();

            int remainingHealth = initialHealth;
            bool isImmuneSystemDefeated = false;
            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("end"))
            {
                string virusName = input;
                int virusLength = input.Length;
                int virusStrength = 0;
                int timeToDefeatInSec = 0;

                if (viruses.ContainsKey(virusName))
                {
                    virusStrength = viruses[virusName];
                    timeToDefeatInSec = (virusStrength * virusLength) / 3;
                }
                else
                {
                    int asciiCodeSum = 0;
                    for (int i = 0; i < virusLength; i++)
                    {
                        asciiCodeSum += virusName[i];
                    }

                    virusStrength = (asciiCodeSum / 3);
                    viruses.Add(virusName, virusStrength);

                    timeToDefeatInSec = virusStrength * virusLength;
                }

                Console.WriteLine($"Virus {virusName}: {virusStrength} => {timeToDefeatInSec} seconds");
                remainingHealth -= timeToDefeatInSec;

                if (virusStrength <= remainingHealth)
                {                                        
                    Console.WriteLine($"{virusName} defeated in {timeToDefeatInSec / 60}m {timeToDefeatInSec % 60}s.");
                    Console.WriteLine($"Remaining health: {remainingHealth}");

                    remainingHealth += (int)(remainingHealth * 0.20);
                    if (remainingHealth > initialHealth)
                        remainingHealth = initialHealth;
                }
                else
                {
                    Console.WriteLine("Immune System Defeated.");
                    isImmuneSystemDefeated = true;
                    break;
                }
            }

            if(!isImmuneSystemDefeated)
            {
                Console.WriteLine($"Final Health: {remainingHealth}");
            }
        }
    }
}
