namespace _07.TrafficJam
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ExecuteCommands());
        }

        private static string ExecuteCommands()
        {
            StringBuilder sb = new StringBuilder();

            // the number of cars that can pass during a green light
            int carsPerGreenLight = int.Parse(Console.ReadLine());

            Queue<string> carsQueue = new Queue<string>();

            int totalPassedCars = 0;

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("end"))
            {
                if (input.Equals("green"))
                {
                    int passedCars = 0;
                    while (passedCars < carsPerGreenLight && carsQueue.Count > 0)
                    {
                        sb.AppendLine($"{carsQueue.Dequeue()} passed!");

                        passedCars++;
                        totalPassedCars++;
                    }
                }
                else
                {
                    carsQueue.Enqueue(input);
                }
            }

            sb.Append($"{totalPassedCars} cars passed the crossroads.");

            return sb.ToString();
        }
    }
}
