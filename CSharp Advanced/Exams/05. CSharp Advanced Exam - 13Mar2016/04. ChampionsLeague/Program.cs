namespace _04.ChampionsLeague
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teamsStats = ReadInputInfo();
            PrintTeamStats(teamsStats);
        }

        private static List<Team> ReadInputInfo()
        {
            List<Team> teamsStats = new List<Team>();

            string input = string.Empty;

            while(!(input = Console.ReadLine()).Equals("stop"))
            {
                string[] cmdArgs = input.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                string team1Name = cmdArgs[0];
                string team2Name = cmdArgs[1];
                int[] team1VsTeam2Result = cmdArgs[2].Split(':').Select(int.Parse).ToArray();
                int[] team2VsTeam1Result = cmdArgs[3].Split(':').Select(int.Parse).ToArray();

                int team1Goals = team1VsTeam2Result[0] + team2VsTeam1Result[1];
                int team2Goals = team1VsTeam2Result[1] + team2VsTeam1Result[0];

                Team team1 = teamsStats.FirstOrDefault(t => t.Name.Equals(team1Name));
                Team team2 = teamsStats.FirstOrDefault(t => t.Name.Equals(team2Name));

                if(team1 == null)
                {
                    team1 = new Team(team1Name);
                    teamsStats.Add(team1);
                }

                if (team2 == null)
                {
                    team2 = new Team(team2Name);
                    teamsStats.Add(team2);
                }

                team1.AddOpponent(team2Name);
                team2.AddOpponent(team1Name);

                if(team1Goals > team2Goals)
                {
                    team1.IncreaseWins();
                }
                else if(team2Goals > team1Goals)
                {
                    team2.IncreaseWins();
                }
                else if(team2VsTeam1Result[1] > team1VsTeam2Result[1])
                {
                    team1.IncreaseWins();
                }
                else
                {
                    team2.IncreaseWins();
                }
            }

            return teamsStats;
        }

        private static void PrintTeamStats(List<Team> teamsStats)
        {
            List<Team> sortedStats = teamsStats.OrderByDescending(t => t.Wins).ThenBy(t => t.Name).ToList();

            foreach(Team teamStats in sortedStats)
            {
                Console.WriteLine(teamStats);
            }               
        }
    }
}
