namespace _07._TrafficLights
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            List<TrafficLight> trafficLights = GetTrafficLights();

            if (trafficLights != null)
            {
                ChangeTrafficLights(trafficLights);
            }
        }

        private static List<TrafficLight> GetTrafficLights()
        {
            List<TrafficLight> trafficLights = new List<TrafficLight>();

            try
            {
                trafficLights = Console.ReadLine()
                                             .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                             .Select(t => new TrafficLight(t))
                                             .ToList();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                trafficLights = null;
            }

            return trafficLights;
        }

        private static void ChangeTrafficLights(List<TrafficLight> trafficLights)
        {
            int numberOfChanges = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfChanges; i++)
            {
                trafficLights.ForEach(t => t.ChangeLight());

                Console.WriteLine(string.Join(" ", trafficLights));
            }
        }
    }
}
