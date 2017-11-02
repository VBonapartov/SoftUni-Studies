using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkProjects
{
    class Program
    {
        class Team
        {
            public string Name { get; set; }
            public string Creator { get; set; }
            public List<string> Members { get; set; }
        }

        static void Main(string[] args)
        {
            List<Team> teams = CreatingTeams();
            JoiningATeam(teams);

            PrintTeams(teams);
        }

        private static List<Team> CreatingTeams()
        {
            int numberOfTeams = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();
            for (int i = 1; i <= numberOfTeams; i++)
            {
                string[] input = Console.ReadLine().Trim().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                Team team = new Team
                {
                    Name = input[1],
                    Creator = input[0],
                    Members = new List<string>()
                };


                if (teams.Exists(t => t.Name.Equals(team.Name)))
                {
                    Console.WriteLine($"Team {team.Name} was already created!");
                }
                else if (teams.Exists(t => t.Creator.Equals(team.Creator)))
                {
                    Console.WriteLine($"{team.Creator} cannot create another team!");
                }
                else
                {
                    teams.Add(team);
                    Console.WriteLine($"Team {team.Name} has been created by {team.Creator}!");
                }
            }

            return teams;
        }

        private static void JoiningATeam(List<Team> teams)
        {
            string input = string.Empty;
            while (!(input = Console.ReadLine().Trim()).Equals("end of assignment"))
            {
                string[] command = input.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                string user = command[0];
                string team = command[1];

                if (!teams.Exists(t => t.Name.Equals(team)))
                {
                    Console.WriteLine($"Team {team} does not exist!");
                }
                else if ((teams.Exists(t => t.Creator.Equals(user))) ||
                     teams.Exists(t => t.Members.Contains(user)))
                {
                    Console.WriteLine($"Member {user} cannot join team {team}!");
                }    
                else
                {
                    Team existingTeam = teams.First(c => c.Name.Equals(team));
                    existingTeam.Members.Add(user);
                }
            }
        }

        private static void PrintTeams(List<Team> teams)
        {
            List<Team> teamsWithMembers = teams
                                                 .Where(t => t.Members.Count > 0)
                                                 .OrderByDescending(t => t.Members.Count)
                                                 .ThenBy(t => t.Name)
                                                 .ToList();

            List<string> teamsWithoutMembers = teams
                                                 .Where(t => t.Members.Count == 0)
                                                 .OrderBy(t => t.Name)
                                                 .Select(t => t.Name)
                                                 .ToList();

            foreach (Team team in teamsWithMembers)
            {
                Console.WriteLine(team.Name);
                Console.WriteLine($"- {team.Creator}");

                team.Members.Sort();
                foreach(string member in team.Members)
                    Console.WriteLine($"-- {member}");
            }

            Console.WriteLine("Teams to disband:");
            Console.WriteLine($"{string.Join(Environment.NewLine, teamsWithoutMembers)}");
        }
    }
}
