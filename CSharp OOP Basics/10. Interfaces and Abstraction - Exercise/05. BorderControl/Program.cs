namespace _05._BorderControl
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static List<IPerson> citizens = new List<IPerson>();
        private static List<IRobot> robots = new List<IRobot>();

        public static void Main(string[] args)
        {
            GetCitizensAndRobots();
            PrintDetainedIds();
        }

        private static void GetCitizensAndRobots()
        {
            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("End"))
            {
                string[] cmdArgs = input.Split(' ');

                // citizens 
                if (cmdArgs.Length == 3)
                {
                    string name = cmdArgs[0];
                    int age = int.Parse(cmdArgs[1]);
                    string id = cmdArgs[2];

                    citizens.Add(new Citizen(name, age, id));
                }
                // robots
                else if (cmdArgs.Length == 2)
                {
                    string model = cmdArgs[0];
                    string id = cmdArgs[1];

                    robots.Add(new Robot(model, id));
                }
            }
        }

        private static void PrintDetainedIds()
        {
            string fakeIdsEndsWith = Console.ReadLine();

            foreach (Robot robot in robots)
            {
                if (robot.Id.EndsWith(fakeIdsEndsWith))
                {
                    Console.WriteLine(robot.Id);
                }
            }

            foreach (Citizen citizen in citizens)
            {
                if (citizen.Id.EndsWith(fakeIdsEndsWith))
                {
                    Console.WriteLine(citizen.Id);
                }
            }
        }
    }
}
