namespace _02._VehiclesExtension
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Vehicle car = ReadVehicleInfo();
            Vehicle truck = ReadVehicleInfo();
            Vehicle bus = ReadVehicleInfo();

            ExecuteCommands(car, truck, bus);
            PrintrRemainingFuel(car, truck, bus);
        }

        private static Vehicle ReadVehicleInfo()
        {
            string[] cmdArgs = Console.ReadLine().Split(' ');
            string type = cmdArgs[0];
            double fuelQuantity = double.Parse(cmdArgs[1]);
            double fuelConsumptionPerKm = double.Parse(cmdArgs[2]);
            double tankCapacity = double.Parse(cmdArgs[3]);

            switch (type)
            {
                case "Car":
                    return new Car(fuelQuantity, fuelConsumptionPerKm, tankCapacity);

                case "Truck":
                    return new Truck(fuelQuantity, fuelConsumptionPerKm, tankCapacity);

                case "Bus":
                    return new Bus(fuelQuantity, fuelConsumptionPerKm, tankCapacity);

                default:
                    return null;
            }
        }

        private static void ExecuteCommands(Vehicle car, Vehicle truck, Vehicle bus)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ');
                string command = cmdArgs[0];
                string vehicleType = cmdArgs[1];

                try
                {
                    switch (vehicleType.ToLower())
                    {
                        case "car":
                            ExecuteAction(car, command, double.Parse(cmdArgs[2]));
                            break;

                        case "truck":
                            ExecuteAction(truck, command, double.Parse(cmdArgs[2]));
                            break;

                        case "bus":
                            ExecuteAction(bus, command, double.Parse(cmdArgs[2]));
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
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

                case "DriveEmpty":
                    Console.WriteLine(vehicle.TryTravelDistance(parameter, false));
                    break;
            }
        }

        private static void PrintrRemainingFuel(Vehicle car, Vehicle truck, Vehicle bus)
        {
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
