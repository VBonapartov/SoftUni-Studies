namespace _06._StrategyPattern
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static SortedSet<Person> firstSortedSet;
        private static SortedSet<Person> secondSortedSet;

        public static void Main(string[] args)
        {
            GetInput();

            PrintSet(firstSortedSet);
            PrintSet(secondSortedSet);
        }

        private static void GetInput()
        {
            firstSortedSet = new SortedSet<Person>(new PersonNameComparator());
            secondSortedSet = new SortedSet<Person>(new PersonAgeComparator());

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ');
                string name = cmdArgs[0];
                int age = int.Parse(cmdArgs[1]);

                Person person = new Person(name, age);

                firstSortedSet.Add(person);
                secondSortedSet.Add(person);
            }
        }

        private static void PrintSet(SortedSet<Person> set)
        {
            foreach (Person person in set)
            {
                Console.WriteLine($"{person.Name} {person.Age}");
            }
        }
    }
}
