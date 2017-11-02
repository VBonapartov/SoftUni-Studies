using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WormsWorldParty
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> teams = new Dictionary<string, Dictionary<string, long>>();

            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("quit"))
            {
                string[] commandArgs = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string wormName = commandArgs[0];
                string teamName = commandArgs[1];
                int wormScore = Convert.ToInt32(commandArgs[2]);

                bool isWormExists = teams.Where(w => w.Value.ContainsKey(wormName)).Any();
                if (isWormExists)
                    continue;

                if (!teams.ContainsKey(teamName))
                {
                    teams.Add(teamName, new Dictionary<string, long> { });
                }

                if(!teams[teamName].ContainsKey(wormName))
                {
                    teams[teamName].Add(wormName, wormScore);
                }
            }

            PrintTeams(teams);
        }

        private static void PrintTeams(Dictionary<string, Dictionary<string, long>> teams)
        {
            Dictionary<string, Dictionary<string, long>> sortedTeams = teams
                                                                        .OrderByDescending(w => w.Value.Values.Sum())
                                                                        .ThenByDescending(w => w.Value.Values.Sum() / w.Value.Count())
                                                                        .ToDictionary(w => w.Key, w => w.Value);

            int countTeams = 1;
            foreach(KeyValuePair<string, Dictionary<string, long>> team in sortedTeams)
            {
                Console.WriteLine($"{countTeams++}. Team: {team.Key} - {team.Value.Values.Sum()}");

                foreach(KeyValuePair<string, long> worm in team.Value.OrderByDescending(w => w.Value))
                {
                    Console.WriteLine($"###{worm.Key} : {worm.Value}");
                }
            }
        }
    }
}
