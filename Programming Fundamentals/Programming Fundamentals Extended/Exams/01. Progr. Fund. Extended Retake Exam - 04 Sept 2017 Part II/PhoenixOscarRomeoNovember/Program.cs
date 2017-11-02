using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixOscarRomeoNovember
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> fireCreatures = new Dictionary<string, HashSet<string>>();
            ReadCreaturesAndSquadMates(fireCreatures);
            PrintCreatures(fireCreatures);
        }

        private static void ReadCreaturesAndSquadMates(Dictionary<string, HashSet<string>> fireCreatures)
        {
            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("Blaze it!"))
            {
                string[] commandArgs = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string creature = commandArgs[0];
                string squadMate = commandArgs[1];

                if (creature.Equals(squadMate))
                    continue;

                if (!fireCreatures.ContainsKey(creature))
                {
                    fireCreatures.Add(creature, new HashSet<string> { });
                }

                fireCreatures[creature].Add(squadMate);
            }
        }

        private static void PrintCreatures(Dictionary<string, HashSet<string>> fireCreatures)
        {
            Dictionary<string, List<string>> finalCreatures = new Dictionary<string, List<string>>();
            foreach (KeyValuePair<string, HashSet<string>> creature in fireCreatures)
            {
                finalCreatures.Add(creature.Key, new List<string> { });
                foreach (string squadMate in creature.Value)
                {
                    if (fireCreatures.ContainsKey(squadMate))
                    {
                        if (!fireCreatures[squadMate].Contains(creature.Key))
                            finalCreatures[creature.Key].Add(squadMate);
                    }
                    else
                    {
                        finalCreatures[creature.Key].Add(squadMate);
                    }
                }
            }            

            foreach(KeyValuePair<string, List<string>> creature in finalCreatures.OrderByDescending(c => c.Value.Count))
            {
                Console.WriteLine($"{creature.Key} : {creature.Value.Count}");
            }
        }
    }
}
