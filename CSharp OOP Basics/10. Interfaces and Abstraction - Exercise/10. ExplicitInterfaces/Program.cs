namespace _10._ExplicitInterfaces
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            IList<Citizen> citizens = GetCitizens();
            PrintNames(citizens);
        }

        private static IList<Citizen> GetCitizens()
        {
            IList<Citizen> citizens = new List<Citizen>();

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("End"))
            {
                string[] cmdArgs = input.Split(' ');
                string name = cmdArgs[0];
                string country = cmdArgs[1];
                int age = int.Parse(cmdArgs[2]);

                Citizen citizen = new Citizen(name, country, age);
                citizens.Add(citizen);
            }

            return citizens;
        }

        private static void PrintNames(IList<Citizen> citizens)
        {
            foreach (Citizen citizen in citizens)
            {
                IPerson person = (IPerson)citizen;
                IResident resident = (IResident)citizen;

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
