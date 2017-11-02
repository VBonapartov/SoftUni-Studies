using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrophonTheGrumpyCat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> priceRatings = Console.ReadLine().Split(' ').Select(long.Parse).ToList();
            int entryPoint = int.Parse(Console.ReadLine());
            string typeOfItems = Console.ReadLine();
            string typeOfPriceRatings = Console.ReadLine();

            long leftDamage = 0L;
            long rightDamage = 0L;
            if (typeOfItems.Equals("cheap"))
            {
                if(typeOfPriceRatings.Equals("positive"))
                {
                    leftDamage = priceRatings.Where((i, index) => index < entryPoint && i < priceRatings[entryPoint] && i > 0).Sum();
                    rightDamage = priceRatings.Where((i, index) => index > entryPoint && i < priceRatings[entryPoint] && i > 0).Sum();
                }
                else if(typeOfPriceRatings.Equals("negative"))
                {
                    leftDamage = priceRatings.Where((i, index) => index < entryPoint && i < priceRatings[entryPoint] && i < 0).Sum();
                    rightDamage = priceRatings.Where((i, index) => index > entryPoint && i < priceRatings[entryPoint] && i < 0).Sum();
                }
                else if(typeOfPriceRatings.Equals("all"))
                {
                    leftDamage = priceRatings.Where((i, index) => index < entryPoint && i < priceRatings[entryPoint]).Sum();
                    rightDamage = priceRatings.Where((i, index) => index > entryPoint && i < priceRatings[entryPoint]).Sum();
                }
            }
            else if(typeOfItems.Equals("expensive"))
            {
                if (typeOfPriceRatings.Equals("positive"))
                {
                    leftDamage = priceRatings.Where((i, index) => index < entryPoint && i >= priceRatings[entryPoint] && i > 0).Sum();
                    rightDamage = priceRatings.Where((i, index) => index > entryPoint && i >= priceRatings[entryPoint] && i > 0).Sum();
                }
                else if (typeOfPriceRatings.Equals("negative"))
                {
                    leftDamage = priceRatings.Where((i, index) => index < entryPoint && i >= priceRatings[entryPoint] && i < 0).Sum();
                    rightDamage = priceRatings.Where((i, index) => index > entryPoint && i >= priceRatings[entryPoint] && i < 0).Sum();
                }
                else if (typeOfPriceRatings.Equals("all"))
                {
                    leftDamage = priceRatings.Where((i, index) => index < entryPoint && i >= priceRatings[entryPoint]).Sum();
                    rightDamage = priceRatings.Where((i, index) => index > entryPoint && i >= priceRatings[entryPoint]).Sum();
                }
            }

            Console.WriteLine((leftDamage >= rightDamage) ? $"Left - {leftDamage}" : $"Right - {rightDamage}");
        }
    }
}
