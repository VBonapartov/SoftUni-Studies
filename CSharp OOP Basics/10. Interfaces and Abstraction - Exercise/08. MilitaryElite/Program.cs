namespace _08._MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        private static StringBuilder sb = new StringBuilder();
        private static IList<IPrivate> privates = new List<IPrivate>();

        public static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            string command = string.Empty;
            while (!(command = Console.ReadLine()).Equals("End"))
            {
                try
                {
                    ExecuteCommand(command);
                }
                catch (ArgumentException)
                {
                    // Invalid Corps
                    continue;
                }
            }

            Console.WriteLine(sb);
        }

        private static void ExecuteCommand(string command)
        {
            string[] cmdArgs = command.Split(' ');
            string type = cmdArgs[0];

            string id = cmdArgs[1];
            string firstName = cmdArgs[2];
            string lastName = cmdArgs[3];
            double salary;
            string corps;

            switch (type)
            {
                case "Private":
                    salary = double.Parse(cmdArgs[4]);
                    RegisterPrivate(id, firstName, lastName, salary);
                    break;

                case "LeutenantGeneral":
                    salary = double.Parse(cmdArgs[4]);
                    RegisterLeutenantGeneral(id, firstName, lastName, salary, cmdArgs);
                    break;

                case "Engineer":
                    salary = double.Parse(cmdArgs[4]);
                    corps = cmdArgs[5];
                    string[] repairsData = cmdArgs.Skip(6).ToArray();

                    RegisterEngineer(id, firstName, lastName, salary, corps, repairsData);
                    break;

                case "Commando":
                    salary = double.Parse(cmdArgs[4]);
                    corps = cmdArgs[5];
                    string[] missionsData = cmdArgs.Skip(6).ToArray();

                    RegisterCommando(id, firstName, lastName, salary, corps, missionsData);
                    break;

                case "Spy":
                    int codeNumber = int.Parse(cmdArgs[4]);
                    RegisterSpy(id, firstName, lastName, codeNumber);
                    break;
            }
        }

        private static void RegisterPrivate(string id, string firstName, string lastName, double salary)
        {
            Private currPrivate = new Private(id, firstName, lastName, salary);
            privates.Add(currPrivate);

            sb.AppendLine(currPrivate.ToString());
        }

        private static void RegisterLeutenantGeneral(string id, string firstName, string lastName, double salary, string[] cmdArgs)
        {
            IList<IPrivate> lethenantGeneralsPrivates = new List<IPrivate>();

            foreach (var privateId in cmdArgs.Skip(5))
            {
                IPrivate currentPrivate = privates.FirstOrDefault(p => p.Id == privateId);

                if (currentPrivate != null)
                {
                    lethenantGeneralsPrivates.Add(currentPrivate);
                }
            }

            LeutenantGeneral soldier = new LeutenantGeneral(id, firstName, lastName, salary, lethenantGeneralsPrivates);
            sb.AppendLine(soldier.ToString());
        }

        private static void RegisterEngineer(string id, string firstName, string lastName, double salary, string corps, string[] repairsData)
        {
            IList<IRepair> repairs = new List<IRepair>();

            for (int i = 0; i < repairsData.Length; i += 2)
            {
                string partName = repairsData[i];
                int hoursWorked = int.Parse(repairsData[i + 1]);

                repairs.Add(new Repair(partName, hoursWorked));
            }

            Engineer soldier = new Engineer(id, firstName, lastName, salary, corps, repairs);
            sb.AppendLine(soldier.ToString());
        }

        private static void RegisterCommando(string id, string firstName, string lastName, double salary, string corps, string[] missionsData)
        {
            IList<IMission> missions = new List<IMission>();

            for (int i = 0; i < missionsData.Length; i += 2)
            {
                string codeName = missionsData[i];
                string state = missionsData[i + 1];

                try
                {
                    missions.Add(new Mission(codeName, state));
                }
                catch (ArgumentException)
                {
                    // skip mission
                    continue;
                }
            }

            Commando soldier = new Commando(id, firstName, lastName, salary, corps, missions);
            sb.AppendLine(soldier.ToString());
        }

        private static void RegisterSpy(string id, string firstName, string lastName, int codeNumber)
        {
            Spy soldier = new Spy(id, firstName, lastName, codeNumber);
            sb.AppendLine(soldier.ToString());
        }
    }
}
