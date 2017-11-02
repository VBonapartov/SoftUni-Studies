using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CottageScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> treeInfo = new Dictionary<string, List<int>>();

            string input = string.Empty;
            while (!(input = Console.ReadLine().Trim()).Equals("chop chop"))
            {
                string[] command = input.Trim().Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string type = command[0];
                int height = int.Parse(command[1]);

                if(treeInfo.ContainsKey(type))
                {
                    treeInfo[type].Add(height);
                }
                else
                {
                    treeInfo.Add(type, new List<int> { height });
                }
            }

            string treeForCottageScraper = Console.ReadLine().Trim();
            int minimumLengthPerTree = int.Parse(Console.ReadLine());

            long sumOfAllLogs = treeInfo.Select(s => s.Value.Sum()).Sum();
            int countAllLogs = treeInfo.Select(s => s.Value.Count()).Sum();
            double pricePerMeter = Math.Round((double)sumOfAllLogs / countAllLogs, 2);

            long unusedFromTheSameType = 0;
            double usedLogsPrice = 0.00d;
            if (treeInfo.ContainsKey(treeForCottageScraper))
            {              
                usedLogsPrice = treeInfo[treeForCottageScraper]
                    .Where(i => i >= minimumLengthPerTree)
                    .ToList()
                    .Sum() * pricePerMeter;

                unusedFromTheSameType = treeInfo[treeForCottageScraper]
                    .Where(i => i < minimumLengthPerTree)
                    .ToList()
                    .Sum();
            }
            usedLogsPrice = Math.Round(usedLogsPrice, 2);

            long unusedTreeHeight = treeInfo
                .Where(s => !s.Key.Equals(treeForCottageScraper))
                .Select(s => s.Value)
                .ToList()
                .Select(s => s.Sum())
                .Sum();

            unusedTreeHeight += unusedFromTheSameType;
            double unusedLogsPrice = Math.Round(unusedTreeHeight * pricePerMeter * 0.25, 2);

            double subtotalCottageScraper = (usedLogsPrice + unusedLogsPrice);

            Console.WriteLine($"Price per meter: ${pricePerMeter:F2}");
            Console.WriteLine($"Used logs price: ${usedLogsPrice:F2}");
            Console.WriteLine($"Unused logs price: ${unusedLogsPrice:F2}");
            Console.WriteLine($"CottageScraper subtotal: ${subtotalCottageScraper:F2}");
        }
    }
}
