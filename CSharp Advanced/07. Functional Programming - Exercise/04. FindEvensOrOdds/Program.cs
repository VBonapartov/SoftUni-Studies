namespace _04.FindEvensOrOdds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Predicate<int> filter = EvenOrOdd(Console.ReadLine());
            PrintResult(input[0], input[1], filter);
        }

        private static Predicate<int> EvenOrOdd(string command)
        {
            switch (command)
            {
                case "even":
                    return (int num) => { return num % 2 == 0; };

                case "odd":
                    return (int num) => { return num % 2 != 0; };

                default:
                    return null;
            }
        }

        public static void PrintResult(int start, int end, Predicate<int> filter)
        {
            List<int> result = new List<int>();

            for (int i = start; i <= end; i++)
            {
                if (filter(i))
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
