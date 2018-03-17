namespace P02_CarsSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            List<Engine> engines = GetEngines();
            List<Car> cars = GetCars(engines);

            PrintCars(cars);
        }

        private static List<Engine> GetEngines()
        {
            List<Engine> engines = new List<Engine>();

            int numberOfEngines = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);

                int displacement;
                string efficiency = string.Empty;

                if (engineInfo.Length == 4)
                {
                    displacement = int.Parse(engineInfo[2]);
                    efficiency = engineInfo[3];

                    engines.Add(new Engine(model, power, displacement, efficiency));
                }
                else if (engineInfo.Length == 3)
                {
                    bool isDisplacement = int.TryParse(engineInfo[2], out displacement);
                    if (isDisplacement)
                    {
                        engines.Add(new Engine(model, power, displacement));
                    }
                    else
                    {
                        engines.Add(new Engine(model, power, engineInfo[2]));
                    }
                }
                else
                {
                    engines.Add(new Engine(model, power));
                }
            }

            return engines;
        }

        private static List<Car> GetCars(List<Engine> engines)
        {
            List<Car> cars = new List<Car>();

            int numberOfCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];
                string engineModel = carInfo[1];

                Engine engine = engines.Where(eng => eng.Model.Equals(engineModel)).FirstOrDefault();

                int weight;
                string color = string.Empty;

                if (carInfo.Length == 4)
                {
                    weight = int.Parse(carInfo[2]);
                    color = carInfo[3];

                    cars.Add(new Car(model, engine, weight, color));
                }
                else if (carInfo.Length == 3)
                {
                    bool isWeight = int.TryParse(carInfo[2], out weight);
                    if (isWeight)
                    {
                        cars.Add(new Car(model, engine, weight));
                    }
                    else
                    {
                        cars.Add(new Car(model, engine, carInfo[2]));
                    }
                }
                else
                {
                    cars.Add(new Car(model, engine));
                }
            }

            return cars;
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
