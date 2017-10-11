using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlants
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] plantsPowerLevel = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            int countDays = 0;
            int countSeasons = 0;
            bool allThePlantsDie = false;

            while (!allThePlantsDie)
            {
                // season
                for (int day = 0; day < plantsPowerLevel.GetLength(0); day++)
                {
                    countDays++;
                    int countPlantsDie = 0;
                    for (int i = 0; i < plantsPowerLevel.GetLength(0); i++)
                    {
                        if (day != i && plantsPowerLevel[i] > 0)
                        {
                            plantsPowerLevel[i]--;
                        }

                        countPlantsDie += (plantsPowerLevel[i] == 0) ? 1 : 0;
                    }

                    // all plants die
                    if (countPlantsDie == plantsPowerLevel.GetLength(0))
                    {
                        allThePlantsDie = true;
                        break;
                    }
                }

                if (!allThePlantsDie)
                {
                    countSeasons++;

                    // all plants which are still alive bloom
                    for (int i = 0; i < plantsPowerLevel.GetLength(0); i++)
                    {
                        if (plantsPowerLevel[i] > 0)
                        {
                            plantsPowerLevel[i]++;                           
                        }
                    }
                }
                else
                {
                    break;
                }           
            }

            if (countSeasons == 1)
            {
                Console.WriteLine($"survived {countDays} days ({countSeasons} season)");
            }
            else
            {
                Console.WriteLine($"survived {countDays} days ({countSeasons} seasons)");
            }
        }
    }
}
