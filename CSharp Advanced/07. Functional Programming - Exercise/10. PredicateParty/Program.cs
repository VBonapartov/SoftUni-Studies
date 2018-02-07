namespace _10.PredicateParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split(' ').ToList();

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("Party!"))
            {
                string[] commandArgs = input.Split(' ');
                string command = commandArgs[0];
                string criteria = commandArgs[1];
                string attr = commandArgs[2];

                Func<string, bool> filter = CreateFilter(criteria, attr);
                ExecuteCommand(guests, command, filter);
            }

            PrintGuests(guests);
        }

        private static Func<string, bool> CreateFilter(string criteria, string attr)
        {
            switch (criteria)
            {
                case "StartsWith":
                    return n => n.StartsWith(attr);

                case "EndsWith":
                    return n => n.EndsWith(attr);

                case "Length":
                    return n => n.Length == int.Parse(attr);

                default:
                    return null;
            }
        }

        private static void ExecuteCommand(List<string> guests, string command, Func<string, bool> filter)
        {
            for (int i = guests.Count - 1; i >= 0; i--)
            {
                if (filter(guests[i]))
                {
                    switch (command)
                    {
                        case "Remove":
                            guests.RemoveAt(i);
                            break;

                        case "Double":
                            guests.Add(guests[i]);
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        private static void PrintGuests(List<string> guests)
        {
            if (guests.Any())
            {
                Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
