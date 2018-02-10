namespace _04.CubicAssault
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            List<Region> regions = GetRegionsStats();
            PrintStats(regions);
        }

        private static List<Region> GetRegionsStats()
        {
            List<Region> regions = new List<Region>();

            string input = string.Empty;

            while(!(input = Console.ReadLine()).Equals("Count em all"))
            {
                string[] cmdArgs = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string regionName = cmdArgs[0];
                string soldierType = cmdArgs[1];
                int count = int.Parse(cmdArgs[2]);

                Region region = regions.FirstOrDefault(r => r.Name.Equals(regionName));

                if(region == null)
                {
                    region = new Region(regionName);
                    regions.Add(region);
                }

                region.AddSoldier(soldierType, count);                
            }

            return regions;
        }

        private static void PrintStats(List<Region> regions)
        {
            regions = regions
                        .OrderByDescending(r => r.GetNumberOfBlackMeteors())
                        .ThenBy(r => r.Name.Length)
                        .ThenBy(r => r.Name)
                        .ToList();

            foreach(Region region in regions)
            {
                Console.WriteLine(region);
            }
        }
    }
}
