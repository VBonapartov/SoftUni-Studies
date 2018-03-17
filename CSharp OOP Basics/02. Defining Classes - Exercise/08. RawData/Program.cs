namespace _08.RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = ReadCarInfo();
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
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];
                double tire1Pressure = double.Parse(carInfo[5]);
                int tire1Age = int.Parse(carInfo[6]);
                double tire2Pressure = double.Parse(carInfo[7]);
                int tire2Age = int.Parse(carInfo[8]);
                double tire3Pressure = double.Parse(carInfo[9]);
                int tire3Age = int.Parse(carInfo[10]);
                double tire4Pressure = double.Parse(carInfo[11]);
                int tire4Age = int.Parse(carInfo[12]);

                List<Tire> tires = new List<Tire>
                {
                    new Tire(tire1Pressure, tire1Age),
                    new Tire(tire2Pressure, tire2Age),
                    new Tire(tire3Pressure, tire3Age),
                    new Tire(tire4Pressure, tire4Age)
                };

                cars.Add(new Car(model,
                         new Engine(engineSpeed, enginePower),
                         new Cargo(cargoWeight, cargoType),
                         tires));
            }

            return cars;
        }

        private static void PrintCars(List<Car> cars)
        {
            string command = Console.ReadLine();
            if (command.Equals("fragile"))
            {
                PrintAllCarsWithCargoTypeFragile(cars);
            }
            else if (command.Equals("flamable"))
            {
                PrintAllCarsWithCargoTypeFlamable(cars);
            }
        }

        private static void PrintAllCarsWithCargoTypeFragile(List<Car> cars)
        {
            List<Car> filteredCars = cars
                                        .Where(c => c.Cargo.CargoType.Equals("fragile") &&
                                                c.Tires.Where(t => t.TirePressure < 1).Count() > 0
                                              )
                                        .ToList();

            foreach (Car car in filteredCars)
            {
                Console.WriteLine(car.Model);
            }
        }

        private static void PrintAllCarsWithCargoTypeFlamable(List<Car> cars)
        {
            List<Car> filteredCars = cars
                                        .Where(c => c.Cargo.CargoType.Equals("flamable") &&
                                                c.Engine.EnginePower > 250
                                              )
                                        .ToList();

            foreach (Car car in filteredCars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}