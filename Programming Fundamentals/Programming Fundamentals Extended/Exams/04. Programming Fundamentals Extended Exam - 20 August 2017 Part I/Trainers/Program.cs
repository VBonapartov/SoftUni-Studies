using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfParticipants = int.Parse(Console.ReadLine());

            Dictionary<string, double> teams = new Dictionary<string, double>();
            teams.Add("Technical", 0);
            teams.Add("Theoretical", 0);
            teams.Add("Practical", 0);

            for (int i = 0; i < numberOfParticipants; i++)
            {
                int distanceInMiles = int.Parse(Console.ReadLine());
                double cargoInTons = double.Parse(Console.ReadLine());
                string team = Console.ReadLine();

                int distanceInMeters = distanceInMiles * 1600;
                double cargoInKillograms = cargoInTons * 1000;

                double participantEarnedMoney = (cargoInKillograms * 1.5) - (0.7 * distanceInMeters * 2.5);
                if(teams.ContainsKey(team))
                {
                    teams[team] += participantEarnedMoney;
                }
            }

            KeyValuePair<string, double> teamMostEarnedMoney = teams
                                                        .OrderByDescending(t => t.Value)
                                                        .ToDictionary(t => t.Key, t => t.Value).First();

            Console.WriteLine($"The {teamMostEarnedMoney.Key} Trainers win with ${teamMostEarnedMoney.Value:F3}.");
        }
    }
}
