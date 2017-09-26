using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingHallEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            // On the first line, you will receive your budget – a floating-point value in the range [0…1000000]
            // On the second line, you will receive the number of items you need to buy – an integer in the range[0…10]
            // On the next count*3 lines, you will receive the item data as such:
            // 1.The item name – string    
            // 2.The item price – floating - point value in the range[0.50…1000.00]
            // 3.The item count – integer in the range[0…1000]

            decimal budget = decimal.Parse(Console.ReadLine());
            int numberOfItems = int.Parse(Console.ReadLine());

            decimal subtotal = 0.0m;
            StringBuilder output = new StringBuilder();
            for (int i = 1; i <= numberOfItems; i++)
            {               
                string itemName = Console.ReadLine();
                decimal itemPrice = decimal.Parse(Console.ReadLine());
                int itemCount = int.Parse(Console.ReadLine());

                subtotal += itemCount * itemPrice;

                itemName += (itemCount > 1) ? "s" : "";
                output.AppendFormat($"Adding {itemCount} {itemName} to cart.\n");
            }

            Console.Write(output);
            Console.WriteLine($"Subtotal: ${subtotal:F2}");

            decimal diff = Math.Abs(budget - subtotal);
            if(budget >= subtotal)
            {
                Console.WriteLine($"Money left: ${diff:F2}");
            }
            else
            {
                Console.WriteLine($"Not enough. We need ${diff:F2} more.");
            }
        }
    }
}
