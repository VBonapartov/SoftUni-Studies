using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HornetAssault
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> beehives = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
            List<long> hornets = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();

            for(int currentBeehives = 0; currentBeehives < beehives.Count; currentBeehives++)
            {
                long totalHornetsPower = hornets.Sum();
                if (totalHornetsPower == 0)
                    break;

                if (totalHornetsPower > beehives[currentBeehives])
                {
                    beehives[currentBeehives] = 0;
                }
                else
                {
                    beehives[currentBeehives] -= totalHornetsPower;
                    hornets.RemoveAt(0);
                }
            }

            PrintResult(beehives, hornets);
        }

        private static void PrintResult(List<long> beehives, List<long> hornets)
        {
            beehives = beehives.Where(i => i > 0).ToList();

            if (beehives.Count > 0)
            {
                Console.WriteLine(string.Join(" ", beehives));
            }
            else if (hornets.Count > 0)
            {
                Console.WriteLine(string.Join(" ", hornets));
            }
        }
    }
}
