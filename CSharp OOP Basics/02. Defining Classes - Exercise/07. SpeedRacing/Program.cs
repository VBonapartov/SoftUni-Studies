namespace _07.SpeedRacing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = ReadCarInfo();
            ExecuteCommands(cars);
            PrintCars(cars);
        }

        private static List<Car> ReadCarInfo()
        {
            List<Car> cars = new List<Car>();

            int numberOfCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(' ');
                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumption = double.Parse(carInfo[2]);

                cars.Add(new Car(model, fuelAmount, fuelConsumption));
            }

            return cars;
        }

        private static void ExecuteCommands(List<Car> cars)
        {
            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("End"))
            {
                string[] cmdArgs = input.Split(' ');
                string command = cmdArgs[0];
                string carModel = cmdArgs[1];
                double amountOfKm = double.Parse(cmdArgs[2]);

                if (!command.Equals("Drive"))
                    continue;

                if (cars.Exists(c => c.Model.Equals(carModel)))
                {
                    Car car = cars.Where(c => c.Model.Equals(carModel)).First();
                    bool isCarMove = car.MoveCar(amountOfKm);

                    if (!isCarMove)
                    {
                        Console.WriteLine($"Insufficient fuel for the drive");
                    }
                }
            }
        }

        private static void PrintCars(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}