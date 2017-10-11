using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamelsBack
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> buildings = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
            int camelBacksSize = int.Parse(Console.ReadLine());

            int rounds = (buildings.Count - camelBacksSize) / 2;
            if(rounds <= 0)
            {
                Console.WriteLine($"already stable: " + string.Join(" ", buildings));
            }
            else
            {
                Console.WriteLine($"{rounds} rounds");

                buildings = buildings.Skip(rounds).ToList();
                buildings = buildings.Take(buildings.Count - rounds).ToList();
                Console.WriteLine($"remaining: " + string.Join(" ", buildings));
            }
        }
    }
}
