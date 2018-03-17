namespace _06._FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            ReadInput();
        }

        private static void ReadInput()
        {
            List<Team> teams = new List<Team>();

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("END"))
            {
                string[] cmdArgs = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

                switch (cmdArgs[0])
                {
                    case "Team":
                        teams.Add(CreateTeam(cmdArgs[1]));
                        break;

                    case "Add":
                        AddPlayer(teams, cmdArgs);
                        break;

                    case "Remove":
                        RemovePlayer(teams, cmdArgs);
                        break;

                    case "Rating":
                        ShowStats(teams, cmdArgs);
                        break;
                }
            }
        }

        private static Team CreateTeam(string teamName)
        {
            try
            {
                Team team = new Team(teamName);
                return team;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private static void AddPlayer(List<Team> teams, string[] cmdArgs)
        {
            string teamName = cmdArgs[1];
            string playerName = cmdArgs[2];

            if (!IsTeamExist(teams, teamName))
            {
                return;
            }

            Team team = teams.Where(t => t.Name.Equals(teamName)).FirstOrDefault();

            try
            {
                List<int> stats = new List<int>();
                for (int i = 3; i < cmdArgs.Length; i++)
                {
                    stats.Add(int.Parse(cmdArgs[i]));
                }

                Player player = new Player(playerName, stats);
                team.AddPlayer(player);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void RemovePlayer(List<Team> teams, string[] cmdArgs)
        {
            string teamName = cmdArgs[1];
            string playerName = cmdArgs[2];

            if (!IsTeamExist(teams, teamName))
            {
                return;
            }

            Team team = teams.Where(t => t.Name.Equals(teamName)).FirstOrDefault();

            try
            {
                team.RemovePlayer(playerName);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ShowStats(List<Team> teams, string[] cmdArgs)
        {
            string teamName = cmdArgs[1];

            if (IsTeamExist(teams, teamName))
            {
                Team team = teams.Where(t => t.Name.Equals(teamName)).FirstOrDefault();
                Console.WriteLine(team);
            }
        }

        private static bool IsTeamExist(List<Team> teams, string teamName)
        {
            if (!teams.Exists(team => team.Name.Equals(teamName)))
            {
                Console.WriteLine($"Team {teamName} does not exist.");
                return false;
            }

            return true;
        }
    }
}
