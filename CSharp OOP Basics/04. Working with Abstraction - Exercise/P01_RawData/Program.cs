namespace P01_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RawData
    {
        private static List<Car> cars;

        public static void Main(string[] args)
        {
            ReadCarsInfo();
            PrintCars();
        }

        private static void ReadCarsInfo()
        {
            cars = new List<Car>();

            int numberOfCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCars; i++)
            {
                cars.Add(new Car(Console.ReadLine));
            }
        }

        private static void PrintCars()
        {
            List<Car> filteredCars = GetFilteredCars();

            foreach (Car car in filteredCars)
            {
                Console.WriteLine(car.Model);
            }
        }

        private static List<Car> GetFilteredCars()
        {
            string command = Console.ReadLine();
            if (command.Equals("fragile"))
            {
                return cars
                          .Where(c => c.Cargo.CargoType.Equals("fragile") &&
                                 c.Tires.Where(t => t.TirePressure < 1).Count() > 0)
                          .ToList();
            }
            else if (command.Equals("flamable"))
            {
                return cars
                           .Where(c => c.Cargo.CargoType.Equals("flamable") &&
                                  c.Engine.EnginePower > 250)
                           .ToList();
            }

            return null;
        }
    }
}
