using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniCoffeeOrders
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfOrders = int.Parse(Console.ReadLine());

            decimal totalPrice = 0.00m;
            for (int i = 0; i < numberOfOrders; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                DateTime orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                int capsulesCount = int.Parse(Console.ReadLine());

                int daysInMonth = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);

                decimal coffeePrice = (daysInMonth * (decimal)capsulesCount * pricePerCapsule);
                totalPrice += coffeePrice;

                Console.WriteLine($"The price for the coffee is: ${coffeePrice:F2}");
            }

            Console.WriteLine($"Total: ${totalPrice:F2}");
        }
    }
}
