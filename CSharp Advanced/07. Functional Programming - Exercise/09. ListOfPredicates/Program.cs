namespace _09.ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Func<int[], int, bool> isValid = IsValid();
            PrintResult(dividers, end, isValid);
        }

        private static Func<int[], int, bool> IsValid()
        {
            return (int[] dividers, int i) =>
            {
                for (int p = 0; p < dividers.Count(); p++)
                {
                    if (i % dividers[p] != 0)
                        return false;
                }

                return true;
            };
        }

        public static void PrintResult(int[] dividers, int end, Func<int[], int, bool> isValid)
        {
            List<int> result = new List<int>();

            for (int i = 1; i <= end; i++)
            {
                if (isValid(dividers, i))
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
