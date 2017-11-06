using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace AnonymousDownsite
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWebsites = int.Parse(Console.ReadLine());
            int securityKey = int.Parse(Console.ReadLine());

            List<string> webSites = new List<string>();
            decimal totalMoneyLoss = 0.0m;
            for (int i = 0; i < numberOfWebsites; i++)
            {
                string[] commandArgs = Console.ReadLine().Split(' ');
                string siteName = commandArgs[0];
                long siteVisits = long.Parse(commandArgs[1]);
                decimal siteCommercialPricePerVisit = decimal.Parse(commandArgs[2]);

                totalMoneyLoss += siteVisits * siteCommercialPricePerVisit;
                webSites.Add(siteName);
            }

            BigInteger securityToken = BigInteger.Pow(securityKey, numberOfWebsites);

            Console.WriteLine(string.Join(Environment.NewLine, webSites));
            Console.WriteLine($"Total Loss: {totalMoneyLoss:F20}");
            Console.WriteLine($"Security Token: {securityToken}");
        }
    }
}
