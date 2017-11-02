using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfDragons = int.Parse(Console.ReadLine());

            // DragonType : {DragonName : {Damage, Health, Armor}}
            Dictionary<string, SortedDictionary<string, List<int>>> dragonsInfo = new Dictionary<string, SortedDictionary<string, List<int>>>();

            for (int i = 1; i <= numberOfDragons; i++)
            {

                string[] inputInfo = Console.ReadLine().Trim().Split(' ');
                string dragonType = inputInfo[0];
                string dragonName = inputInfo[1];
                int damage = (inputInfo[2].Equals("null")) ?  45 : Convert.ToInt32(inputInfo[2]);
                int health = (inputInfo[3].Equals("null")) ? 250 : Convert.ToInt32(inputInfo[3]);
                int armor  = (inputInfo[4].Equals("null")) ?  10 : Convert.ToInt32(inputInfo[4]);

                if(dragonsInfo.ContainsKey(dragonType))
                {
                    if (dragonsInfo[dragonType].ContainsKey(dragonName))
                    {
                        dragonsInfo[dragonType][dragonName][0] = damage;
                        dragonsInfo[dragonType][dragonName][1] = health;
                        dragonsInfo[dragonType][dragonName][2] = armor;
                    }
                    else
                    {
                        dragonsInfo[dragonType].Add(dragonName, new List<int>() { damage, health, armor });
                    }
                }
                else
                {
                    dragonsInfo.Add( dragonType,
                                     new SortedDictionary<string, List<int>>()
                                     {
                                        { dragonName, new List<int>() { damage, health, armor } }
                                     }
                                    );
                }
            }

            PrintDragonsInfo(dragonsInfo);
        }

        static private void PrintDragonsInfo(Dictionary<string, SortedDictionary<string, List<int>>> dragonsInfo)
        {
            foreach(KeyValuePair<string, SortedDictionary<string, List<int>>> dragon in dragonsInfo)
            {
                (double averageDamage, double averageHealth, double averageArmor) = CalculateAverageStats(dragon.Value);
                Console.WriteLine($"{dragon.Key}::({averageDamage:F2}/{averageHealth:F2}/{averageArmor:F2})");

                PrintDragons(dragon.Value);
            }
        }

        static private (double averageDamage, double averageHealth, double averageArmor) CalculateAverageStats(SortedDictionary<string, List<int>> dragonsStats)
        {
            double averageDamage = 0.00d; 
            double averageHealth = 0.00d;
            double averageArmor = 0.00d;

            foreach (KeyValuePair<string, List<int>> dragonStat in dragonsStats)
            {
                averageDamage += dragonStat.Value[0];
                averageHealth += dragonStat.Value[1];
                averageArmor += dragonStat.Value[2];
            }

            averageDamage /= dragonsStats.Count();
            averageHealth /= dragonsStats.Count();
            averageArmor /= dragonsStats.Count();

            return (averageDamage, averageHealth, averageArmor);
        }

        static private void PrintDragons(SortedDictionary<string, List<int>> dragonsStats)
        {
            foreach (KeyValuePair<string, List<int>> dragonStat in dragonsStats)
            {
                Console.WriteLine(  $"-{dragonStat.Key} -> " +
                                    $"damage: {dragonStat.Value[0]}, " +
                                    $"health: {dragonStat.Value[1]}, " +
                                    $"armor: {dragonStat.Value[2]}"
                                  );
            }
        }
    }
}
