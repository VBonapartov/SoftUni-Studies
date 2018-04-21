namespace _07._EqualityLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static SortedSet<Person> firstSortedSet;
        private static HashSet<Person> secondSortedSet;

        public static void Main(string[] args)
        {
            GetInput();

            PrintSize(firstSortedSet);
            PrintSize(secondSortedSet);
        }

        private static void GetInput()
        {
            firstSortedSet = new SortedSet<Person>();
            secondSortedSet = new HashSet<Person>(new PersonEqualityComparer());

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

        private static void PrintSize(IEnumerable<Person> set)
        {
            Console.WriteLine(set.Count());
        }
    }
}
