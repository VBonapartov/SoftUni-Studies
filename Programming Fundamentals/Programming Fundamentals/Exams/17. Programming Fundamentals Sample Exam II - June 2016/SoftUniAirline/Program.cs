using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniAirline
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfFlights = int.Parse(Console.ReadLine());

            decimal overallProfit = 0.00m;
            for (int i = 1; i <= numberOfFlights; i++)
            {
                int adultPassengers = int.Parse(Console.ReadLine());
                decimal adultTicketPrice = decimal.Parse(Console.ReadLine());
                int youthPassengers = int.Parse(Console.ReadLine());
                decimal youthTicketPrice = decimal.Parse(Console.ReadLine());
                decimal fuelPricePerHour = decimal.Parse(Console.ReadLine());
                decimal fuelConsumptionPerHour = decimal.Parse(Console.ReadLine());
                int flightDuration = int.Parse(Console.ReadLine());

                decimal income = ((decimal)adultPassengers * adultTicketPrice) + ((decimal)youthPassengers * youthTicketPrice);
                decimal expense = (decimal)flightDuration * fuelConsumptionPerHour * fuelPricePerHour;

                decimal profit = Math.Abs(income - expense);
                if(income >= expense)
                {
                    Console.WriteLine($"You are ahead with {profit:F3}$.");
                    overallProfit += profit;
                }
                else
                {
                    Console.WriteLine($"We've got to sell more tickets! We've lost -{profit:F3}$.");
                    overallProfit -= profit;
                }
            }

            Console.WriteLine($"Overall profit -> {overallProfit:F3}$.");
            Console.WriteLine($"Average profit -> {(overallProfit / numberOfFlights):F3}$.");
        }
    }
}
