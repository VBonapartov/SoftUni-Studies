using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heists
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] prices = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            long totalEarnings = 0;
            long totalExpenses = 0;

            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("Jail Time"))
            {
                string[] information = input.Split(' ');
                string loot = information[0];
                totalExpenses += Convert.ToInt32(information[1]);

                for(int i = 0; i < loot.Length; i++)
                {
                    if(loot[i].Equals('%'))
                    {
                        totalEarnings += prices[0];
                    }
                    else if(loot[i].Equals('$'))
                    {
                        totalEarnings += prices[1];
                    }
                }
            }

            long diff = Math.Abs(totalEarnings - totalExpenses);
            if(totalEarnings >= totalExpenses)
            {
                Console.WriteLine($"Heists will continue. Total earnings: {diff}.");
            }
            else
            {
                Console.WriteLine($"Have to find another job. Lost: {diff}.");
            }
        }
    }
}
