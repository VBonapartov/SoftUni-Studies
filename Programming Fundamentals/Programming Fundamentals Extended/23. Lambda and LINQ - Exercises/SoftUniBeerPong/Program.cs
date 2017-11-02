using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniBeerPong
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> teamsInfo = new Dictionary<string, Dictionary<string, int>>();

            string input = string.Empty;
            while (!(input = Console.ReadLine().Trim()).Equals("stop the game"))
            {
                string[] command = input.Trim().Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                string player = command[0];
                string team = command[1];
                int pointsMade = int.Parse(command[2]);

                if (teamsInfo.ContainsKey(team))
                {
                    if (teamsInfo[team].Count() < 3)
                    {
                        teamsInfo[team].Add(player, pointsMade);
                    }
                }
                else
                {
                    teamsInfo.Add(team,
                                    new Dictionary<string, int>
                                    {
                                        { player, pointsMade }
                                    }
                                 );
                }
            }

            teamsInfo = teamsInfo
                .Where(p => p.Value.Count() == 3)
                .OrderByDescending(p => p.Value.Values.Sum())           
                .ToDictionary(p => p.Key, p => p.Value);


            PrintTeamInfo(teamsInfo);
        }

        static private void PrintTeamInfo(Dictionary<string, Dictionary<string, int>> teamsInfo)
        {
            int countTeams = 0;
            foreach (KeyValuePair<string, Dictionary<string, int>> team in teamsInfo)
            {
                Console.WriteLine($"{++countTeams}. {team.Key}; Players:");

                Dictionary<string, int> sortedTeamPlayers = team.Value
                                                                .OrderByDescending(p => p.Value)
                                                                .ToDictionary(p => p.Key, p => p.Value);

                foreach (KeyValuePair<string, int> player in sortedTeamPlayers)
                {
                    Console.WriteLine($"###{player.Key}: {player.Value}");
                }
            }
        }
    }
}
