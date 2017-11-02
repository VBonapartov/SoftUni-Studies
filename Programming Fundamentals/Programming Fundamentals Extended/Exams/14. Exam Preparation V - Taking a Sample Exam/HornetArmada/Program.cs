using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HornetArmada
{
    class Legion
    {
        public string Name { get; set; }
        public int LastActivity { get; set; }
        public Dictionary<string, long> Soldiers { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSoldiers = int.Parse(Console.ReadLine());

            List<Legion> legions = new List<Legion>();
            for(int i  = 1; i <= numberOfSoldiers; i++)
            {
                string[] input = Console.ReadLine().Split(new string[] { " = ", " -> ", ":" }, StringSplitOptions.None);
                legions = AddNewLegionInfo(legions, input);
            }

            string[] tokens = Console.ReadLine().Split('\\');
            PrintLegionsInfo(legions, tokens);
        }

        private static List<Legion> AddNewLegionInfo(List<Legion> legions, string[] input)
        {
            int lastActivity = Convert.ToInt32(input[0]);
            string legionName = input[1];
            string soldierType = input[2];
            int soldierCount = Convert.ToInt32(input[3]);

            if (!legions.Exists(l => l.Name.Equals(legionName)))
            {
                Legion newLegion = new Legion
                {
                    Name = legionName,
                    LastActivity = lastActivity,
                    Soldiers = new Dictionary<string, long> { }
                };

                legions.Add(newLegion);
            }

            Legion legion = legions.Where(l => l.Name.Equals(legionName)).First();
            if(lastActivity > legion.LastActivity)
            {
                legion.LastActivity = lastActivity;
            }

            if (!legion.Soldiers.ContainsKey(soldierType))
            {
                legion.Soldiers.Add(soldierType, 0);
            }

            legion.Soldiers[soldierType] += soldierCount;

            return legions;
        }

        private static void PrintLegionsInfo(List<Legion> legions, string[] tokens)
        {
            if (tokens.Length > 1)
            {
                PrintLegionsBySoldierTypeAndLastActivity(legions, Convert.ToInt32(tokens[0]), tokens[1]);
            }
            else
            {
                PrintLegionsBySoldierType(legions, tokens[0]);
            }
        }

        private static void PrintLegionsBySoldierTypeAndLastActivity(List<Legion> legions, int activity, string soldierType)
        {
            legions = legions
                            .Where(l => l.LastActivity < activity)
                            .Where(l => l.Soldiers.ContainsKey(soldierType))
                            .OrderByDescending(l => l.Soldiers[soldierType])
                            .ToList();

            foreach(Legion legion in legions)
            {
                Console.WriteLine($"{legion.Name} -> {legion.Soldiers[soldierType]}");
            }
        }

        private static void PrintLegionsBySoldierType(List<Legion> legions, string soldierType)
        {
            legions = legions
                            .Where(l => l.Soldiers.ContainsKey(soldierType))
                            .OrderByDescending(l => l.LastActivity)
                            .ToList();

            foreach (Legion legion in legions)
            {
                Console.WriteLine($"{legion.LastActivity} : {legion.Name}");
            }
        }
    }
}
