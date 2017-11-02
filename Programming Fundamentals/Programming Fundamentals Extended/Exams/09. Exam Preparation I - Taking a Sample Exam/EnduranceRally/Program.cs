using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnduranceRally
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> participants = Console.ReadLine().Split(' ').ToList();
            List<double> trackLayout = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            List<int> checkpoints = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            for(int i = 0; i < participants.Count; i++)
            {
                double fuel = participants[i][0];
                for(int zone = 0; zone < trackLayout.Count; zone++)
                {
                    if(checkpoints.Contains(zone))
                    {
                        fuel += trackLayout[zone];
                    }
                    else
                    {
                        fuel -= trackLayout[zone];
                    }

                    if(fuel <= 0)
                    {
                        Console.WriteLine($"{participants[i]} - reached {zone}");
                        break;
                    }
                }

                if(fuel > 0)
                {
                    Console.WriteLine($"{participants[i]} - fuel left {fuel:F2}");
                }
            }
        }
    }
}
