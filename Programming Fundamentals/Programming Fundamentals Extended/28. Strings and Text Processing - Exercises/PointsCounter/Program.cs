using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsCounter
{
    class Player
    {
        public string Name { get; set; }
        public int Points { get; set; }
    }

    class Team
    {
        public string Name { get; set; }
        public List<Player> Players { get; set; }

        public void AddPlayer(Player player)
        {
            if(this.Players.Exists(p => p.Name.Equals(player.Name)))
            {
                Player existsPlayer = this.Players.First(p => p.Name.Equals(player.Name));
                existsPlayer.Points = player.Points;
            }
            else
            {
                this.Players.Add(player);
            }
        }

        private int GetTotalScores()
        {
            return this.Players.Select(p => p.Points).Sum();
        }

        private string PlayerWithMostPoints()
        {
            return this.Players.OrderByDescending(p => p.Points).Select(p => p.Name).First();
        }

        public override string ToString()
        {
            string output = string.Format($"{this.Name} => {GetTotalScores()}\n");
            output += string.Format($"Most points scored by {PlayerWithMostPoints()}");

            return output;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = ReadTeams();
            PrintTeams(teams);
        }

        private static List<Team> ReadTeams()
        {
            List<Team> teams = new List<Team>();

            string input = string.Empty;
            while (!(input = Console.ReadLine().Trim()).Equals("Result"))
            {
                input = input.Replace("@", "");
                input = input.Replace("%", "");
                input = input.Replace("$", "");
                input = input.Replace("*", "");

                Team team = ReadStudent(input);
                if (!teams.Exists(t => t.Name.Equals(team.Name)))
                {
                    teams.Add(team);
                }
                else
                {
                    teams.First(t => t.Name.Equals(team.Name)).AddPlayer(team.Players[0]);
                }         
            }

            return teams;
        }

        private static Team ReadStudent(string input)
        {
            string[] tokens = input.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

            string teamName = string.Empty;
            string playerName = string.Empty;
            int points = Convert.ToInt32(tokens[2]);

            if(IsTeam(tokens[0]))
            {
                teamName = tokens[0];
                playerName = tokens[1];
            }
            else
            {
                teamName = tokens[1];
                playerName = tokens[0];
            }

            Team team = new Team
            {
                Name = teamName,
                Players = new List<Player>
                { 
                    new Player { Name = playerName, Points = points }
                }
            };

            return team;
        }

        private static bool IsTeam(string input)
        {
            return input.All(c => char.IsUpper(c));
        }

        private static void PrintTeams(List<Team> teams)
        {
            teams = teams.OrderByDescending(t => t.Players.Sum(p => p.Points)).ToList();
            foreach(Team team in teams)
            {
                Console.WriteLine(team);
            }
        }
    }
}
