namespace _12.InfernoIII
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static List<int> gems;

        static void Main(string[] args)
        {
            gems = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            Dictionary<string, Dictionary<int, Predicate<int>>> filters = ReadFilters();
            PrintGems(Filter(filters));
        }

        private static Dictionary<string, Dictionary<int, Predicate<int>>> ReadFilters()
        {
            Dictionary<string, Dictionary<int, Predicate<int>>> filters = new Dictionary<string, Dictionary<int, Predicate<int>>>();

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("Forge"))
            {
                string[] tokens = input.Split(';');
                string action = tokens[0];
                string filterType = tokens[1];
                int filterParam = int.Parse(tokens[2]);

                if (action.Equals("Exclude"))
                {
                    Predicate<int> filterPred = GetPredicate(filterType, filterParam);

                    if (!filters.ContainsKey(filterType))
                    {
                        filters[filterType] = new Dictionary<int, Predicate<int>>();
                    }

                    filters[filterType].Add(filterParam, filterPred);
                }
                else
                {
                    filters[filterType].Remove(filterParam);
                }
            }

            return filters;
        }

        private static Predicate<int> GetPredicate(string filterType, int filterParam)
        {
            switch (filterType)
            {
                case "Sum Left":
                    return i => (i <= 0 ? 0 : gems[i - 1]) + gems[i] == filterParam;

                case "Sum Right":
                    return i => gems[i] + (i >= gems.Count - 1 ? 0 : gems[i + 1]) == filterParam;

                case "Sum Left Right":
                    return i => (i <= 0 ? 0 : gems[i - 1]) + gems[i] + (i >= gems.Count - 1 ? 0 : gems[i + 1]) == filterParam;
            }

            return null;
        }

        private static List<int> Filter(Dictionary<string, Dictionary<int, Predicate<int>>> filters)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < gems.Count; i++)
            {
                bool isFiltered = false;

                foreach (KeyValuePair<string, Dictionary<int, Predicate<int>>> filter in filters)
                {
                    foreach (KeyValuePair<int, Predicate<int>> predicate in filter.Value)
                    {
                        if (predicate.Value(i))
                        {
                            isFiltered = true;
                            break;
                        }
                    }
                }

                if (!isFiltered)
                {
                    result.Add(gems[i]);
                }
            }

            return result;
        }

        private static void PrintGems(List<int> gems)
        {
            Console.WriteLine(string.Join(" ", gems));
        }
    }
}
