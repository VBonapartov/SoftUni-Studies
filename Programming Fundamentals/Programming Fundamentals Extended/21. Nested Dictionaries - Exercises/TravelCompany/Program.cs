using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompany
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Dictionary<string, int>> transportInfo = new Dictionary<string, Dictionary<string, int>>();

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("ready"))
            {
                string[] command = input.Split(':');
                string city = command[0];
                string[] vehicles = command[1].Split(',');

                if (!transportInfo.ContainsKey(city))
                {
                    transportInfo.Add(city, new Dictionary<string, int>() { });
                }

                for (int i = 0; i < vehicles.Length; i++)
                {
                    string[] vehicleInfo = vehicles[i].Split('-');
                    if (!transportInfo[city].ContainsKey(vehicleInfo[0]))
                    {
                        transportInfo[city].Add(vehicleInfo[0], Convert.ToInt32(vehicleInfo[1]));
                    }
                    else
                    {
                        transportInfo[city][vehicleInfo[0]] = Convert.ToInt32(vehicleInfo[1]);
                    }
                }
            }

            while (!(input = Console.ReadLine()).Equals("travel time!"))
            {
                string[] command = input.Split(' ');
                string city = command[0];
                int peopleCount = int.Parse(command[1]);

                if(transportInfo.ContainsKey(city))
                {
                    int transportCapacities = GetTransportCapacities(transportInfo[city]);
                    if(transportCapacities >= peopleCount)
                    {
                        Console.WriteLine($"{city} -> all {peopleCount} accommodated");
                    }
                    else
                    {
                        Console.WriteLine($"{city} -> all except {peopleCount - transportCapacities} accommodated");
                    }
                }
            }
        }

        static private int GetTransportCapacities(Dictionary<string, int> vehicleInfo)
        {
            int transportCapacities = 0;

            foreach(KeyValuePair<string, int> vehicle in vehicleInfo)
            {
                transportCapacities += vehicle.Value;
            }

            return transportCapacities;
        }
    }
}
