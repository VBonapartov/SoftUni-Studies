namespace _05.FilterByAge
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> people = ReadInput();

            string olderOrYounger = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<int, bool> tester = CreateTester(olderOrYounger, age);
            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);

            InvokePrinter(people, tester, printer);
        }

        private static Dictionary<string, int> ReadInput()
        {
            Dictionary<string, int> people = new Dictionary<string, int>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                if (!people.ContainsKey(input[0]))
                {
                    people.Add(input[0], 0);
                }

                people[input[0]] = int.Parse(input[1]);
            }

            return people;
        }

        private static Func<int, bool> CreateTester(string olderOrYounger, int age)
        {
            switch (olderOrYounger)
            {
                case "older":
                    return n => n >= age;

                case "younger":
                    return n => n < age;

                default:
                    return null;
            }
        }

        private static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name age":
                    return kvp => Console.WriteLine($"{kvp.Key} - {kvp.Value}");

                case "name":
                    return kvp => Console.WriteLine($"{kvp.Key}");

                case "age":
                    return kvp => Console.WriteLine($"{kvp.Value}");

                default:
                    return null;
            }
        }

        private static void InvokePrinter(Dictionary<string, int> people, Func<int, bool> tester, Action<KeyValuePair<string, int>> printer)
        {
            foreach (KeyValuePair<string, int> person in people)
            {
                if (tester(person.Value))
                {
                    printer(person);
                }
            }
        }
    }
}
