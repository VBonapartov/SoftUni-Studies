using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FootballLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();

            Dictionary<string, List<long>> teams = new Dictionary<string, List<long>>();
            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("final"))
            {
                string[] footballMatches = input.Split(' ');
                string encryptedTeamA = footballMatches[0];
                string encryptedTeamB = footballMatches[1];
                string[] scores = footballMatches[2].Split(':');

                string teamA = DecryptTeam(encryptedTeamA, key).ToUpper();
                string teamB = DecryptTeam(encryptedTeamB, key).ToUpper();

                teams = AddTeamInfo(teams, teamA, teamB, scores);
            }

            PrintStandingsTable(teams);
        }

        private static string DecryptTeam(string team, string key)
        {
            string pattern = "(" + Regex.Escape(key) + @")(\w+)\1";
            Match match = Regex.Match(team, pattern);

            if (match.Success)
            {
                return new string(match.Groups[2].Value.Reverse().ToArray());
            }

            return "";
        }

        private static Dictionary<string, List<long>> AddTeamInfo(Dictionary<string, List<long>> teams, string teamA, string teamB, string[] scores)
        {
            int teamAScore = Convert.ToInt32(scores[0]);
            int teamBScore = Convert.ToInt32(scores[1]);

            int pointsTeamA = 0;
            int pointsTeamB = 0;

            if (teamAScore == teamBScore)
            {
                pointsTeamA = 1;
                pointsTeamB = 1;
            }
            else if (teamAScore > teamBScore)
            {
                pointsTeamA = 3;
            }
            else
            {
                pointsTeamB = 3;
            }

            if (!teams.ContainsKey(teamA))
            {
                teams.Add(teamA, new List<long> { pointsTeamA, teamAScore });
            }
            else
            {
                teams[teamA][0] += pointsTeamA;
                teams[teamA][1] += teamAScore;
            }

            if (!teams.ContainsKey(teamB))
            {
                teams.Add(teamB, new List<long> { pointsTeamB, teamBScore });
            }
            else
            {
                teams[teamB][0] += pointsTeamB;
                teams[teamB][1] += teamBScore;
            }

            return teams;
        }

        private static void PrintStandingsTable(Dictionary<string, List<long>> teams)
        {
            teams = teams.OrderByDescending(t => t.Value[0]).ThenBy(t => t.Key).ToDictionary(t => t.Key, t => t.Value);
            Console.WriteLine("League standings:");
            int place = 1;
            foreach (KeyValuePair<string, List<long>> team in teams)
            {
                Console.WriteLine($"{place++}. {team.Key} {team.Value[0]}");
            }

            int numberOfTopTeams = (teams.Count() > 3) ? 3 : teams.Count();
            teams = teams.OrderByDescending(t => t.Value[1]).ThenBy(t => t.Key).Take(numberOfTopTeams).ToDictionary(t => t.Key, t => t.Value);
            Console.WriteLine("Top 3 scored goals:");
            foreach (KeyValuePair<string, List<long>> team in teams)
            {
                Console.WriteLine($"- {team.Key} -> {team.Value[1]}");
            }
        }
    }
}
