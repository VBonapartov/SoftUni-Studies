namespace _11.PartyReservFilterModule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split(' ').ToList();

            List<string> filters = new List<string>();

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("Print"))
            {
                string[] commandArgs = input.Split(';');
                AddRemoveFilter(filters, commandArgs);
            }

            ApplyFilters(guests, filters);
            PrintResultAfterFiltration(guests);
        }

        private static void AddRemoveFilter(List<string> filters, string[] commandArgs)
        {
            string command = commandArgs[0];
            string filterType = commandArgs[1];
            string filterParameter = commandArgs[2];

            string filter = filterType + ";" + filterParameter;

            if (command.Equals("Add filter"))
            {
                if (!filters.Contains(filter))
                {
                    filters.Add(filter);
                }
            }
            else if (command.Equals("Remove filter"))
            {
                if (filters.Contains(filter))
                {
                    filters.Remove(filter);
                }
            }
        }

        private static Predicate<string> CreateFilter(string filterType, string filterParameter)
        {
            switch (filterType)
            {
                case "Starts with":
                    return n => n.StartsWith(filterParameter);

                case "Ends with":
                    return n => n.EndsWith(filterParameter);

                case "Contains":
                    return n => n.Contains(filterParameter);

                case "Length":
                    return n => n.Length == int.Parse(filterParameter);

                default:
                    return null;
            }
        }

        private static void ApplyFilters(List<string> guests, List<string> filters)
        {
            foreach (string filterParams in filters)
            {
                string[] commandArgs = filterParams.Split(';');
                string filterType = commandArgs[0];
                string filterParameter = commandArgs[1];

                Predicate<string> filter = CreateFilter(filterType, filterParameter);
                guests.RemoveAll(filter);
            }
        }

        private static void PrintResultAfterFiltration(List<string> guests)
        {
            Console.WriteLine(string.Join(" ", guests));
        }
    }
}
