using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VehiclePark
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> availableVehicles = Console.ReadLine().Split(' ').ToList();

            int vehiclesSold = 0;
            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("End of customers!"))
            {
                string requestedVehicle = GetVehicle(input);
                if(availableVehicles.Contains(requestedVehicle))
                {
                    availableVehicles.Remove(requestedVehicle);
                    vehiclesSold++;

                    int price = (int)requestedVehicle[0] * Convert.ToInt32(requestedVehicle.Substring(1));
                    Console.WriteLine($"Yes, sold for {price}$");
                }
                else
                {
                    Console.WriteLine("No");
                }
            }

            Console.WriteLine("Vehicles left: " + string.Join(", ", availableVehicles));
            Console.WriteLine("Vehicles sold: " + vehiclesSold);
        }

        private static string GetVehicle(string inputRequest)
        {
            string pattern = @"^(?<carType>[C,B,V])\w+\swith\s(?<seats>\d+)\sseats$";
            Match match = Regex.Match(inputRequest, pattern);

            return match.Groups["carType"].Value.ToLower() + match.Groups["seats"].Value;
        }
    }
}
