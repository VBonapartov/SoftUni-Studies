using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nameOfProducts = Console.ReadLine().Split(' ');
            long[] quantitiesOfTheProducts = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            decimal[] priceOfTheProducts = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();

            string product = string.Empty;
            while(!(product = Console.ReadLine()).Equals("done"))
            {
                int index = Array.IndexOf(nameOfProducts, product);
                Console.WriteLine($"{product} costs: {priceOfTheProducts[index]}; Available quantity: {quantitiesOfTheProducts[index]}");
            }
        }
    }
}
