namespace _05._ComparingObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Person> people = GetPeople();
            PrintStatistics(people);
        }

        private static List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("END"))
            {
                string[] cmdArgs = input.Split();
                string name = cmdArgs[0];
                int age = int.Parse(cmdArgs[1]);
                string town = cmdArgs[2];

                Person person = new Person(name, age, town);
                people.Add(person);
            }

            return people;
        }

        private static void PrintStatistics(List<Person> people)
        {
            int personIndex = int.Parse(Console.ReadLine()) - 1;

            if (personIndex < 0 || personIndex >= people.Count)
            {
                Console.WriteLine("No matches");
                return;
            }

            Person person = people[personIndex];
            people.RemoveAt(personIndex);

            int numberOfEqualPeople = people.Count(p => p.CompareTo(person) == 0);
            int numberOfNotEqualPeople = people.Count(p => p.CompareTo(person) != 0);
            int totalNumberOfPeople = people.Count() + 1;

            if (numberOfEqualPeople == 0)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{numberOfEqualPeople + 1} {numberOfNotEqualPeople} {totalNumberOfPeople}");
            }
        }
    }
}
