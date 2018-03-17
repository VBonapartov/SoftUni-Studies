namespace _01._Vehicles
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Vehicle car = ReadVehicleInfo();
            Vehicle truck = ReadVehicleInfo();

            ExecuteCommands(car, truck);
        }

        private static Vehicle ReadVehicleInfo()
        {
            string[] cmdArgs = Console.ReadLine().Split(' ');
            string type = cmdArgs[0];
            double fuelQuantity = double.Parse(cmdArgs[1]);
            double fuelConsumptionPerKm = double.Parse(cmdArgs[2]);

            if (type.Equals("Car"))
            {
                return new Car(fuelQuantity, fuelConsumptionPerKm);
            }
            else
            {
                return new Truck(fuelQuantity, fuelConsumptionPerKm);
            }
        }

        private static void ExecuteCommands(Vehicle car, Vehicle truck)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ');
                string command = cmdArgs[0];
                string vehicleType = cmdArgs[1];

                if (vehicleType.ToLower().Equals("car"))
                {
                    ExecuteAction(car, command, double.Parse(cmdArgs[2]));
                }
                else if (vehicleType.ToLower().Equals("truck"))
                {
                    ExecuteAction(truck, command, double.Parse(cmdArgs[2]));
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static void ExecuteAction(Vehicle vehicle, string command, double parameter)
        {
            switch (command)
            {
                case "Drive":
                    Console.WriteLine(vehicle.TryTravelDistance(parameter));
                    break;

                case "Refuel":
                    vehicle.Refuel(parameter);
                    break;
            }
        }
    }
}
