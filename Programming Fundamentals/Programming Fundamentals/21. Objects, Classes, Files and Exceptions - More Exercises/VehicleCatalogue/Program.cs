using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleCatalogue
{
    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = ReadVehicles();

            string input = string.Empty;
            while (!(input = Console.ReadLine().Trim()).Equals("Close the Catalogue"))
            {
                PrintVehicleINfoByModel(vehicles, input);
            }

            PrintAverageHorsepower(vehicles);
        }

        private static List<Vehicle> ReadVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            string input = string.Empty;
            while(!(input = Console.ReadLine().Trim()).Equals("End"))
            {
                string[] command = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string vehicleType = command[0].ToLower();
                string vehicleModel = command[1];
                string vehicleColor = command[2];
                int vehicleHorsepower = int.Parse(command[3]);

                Vehicle vehicle = new Vehicle
                {
                    Type = char.ToUpper(vehicleType[0]) + vehicleType.Substring(1),
                    Model = vehicleModel,
                    Color = vehicleColor,
                    Horsepower = vehicleHorsepower
                };

                vehicles.Add(vehicle);
            }

            return vehicles;
        }

        private static void PrintVehicleINfoByModel(List<Vehicle> vehicles, string input)
        {
            vehicles = vehicles.Where(v => v.Model.Equals(input)).ToList();

            foreach(Vehicle vehicle in vehicles)
            {
                Console.WriteLine($"Type: {vehicle.Type}");
                Console.WriteLine($"Model: {vehicle.Model}");
                Console.WriteLine($"Color: {vehicle.Color}");
                Console.WriteLine($"Horsepower: {vehicle.Horsepower}");
            }
        }

        private static void PrintAverageHorsepower(List<Vehicle> vehicles)
        {
            double carsAvgHorsepower = 0.00d;
            if (vehicles.Count(v => v.Type.Equals("Car")) > 0)
            {
                carsAvgHorsepower = vehicles
                                            .Where(v => v.Type.Equals("Car"))
                                            .Average(v => v.Horsepower);
            }
            Console.WriteLine($"Cars have average horsepower of: {carsAvgHorsepower:F2}.");


            double trucksAvgHorsepower = 0.00d;
            if (vehicles.Count(v => v.Type.Equals("Truck")) > 0)
            {
                trucksAvgHorsepower  = vehicles
                                            .Where(v => v.Type.Equals("Truck"))
                                            .Average(v => v.Horsepower);                
            }
            Console.WriteLine($"Trucks have average horsepower of: {trucksAvgHorsepower:F2}.");        
            
        }
    }
}
