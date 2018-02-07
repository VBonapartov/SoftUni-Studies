namespace _06.ReverseAndExclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int divisor = int.Parse(Console.ReadLine());

            Func<List<int>, List<int>> reverse = CreateReverseFunc();
            numbers = reverse(numbers);

            Predicate<int> filter = num => num % divisor != 0;
            Console.WriteLine(string.Join(" ", numbers.Where(i => filter(i))));
        }

        private static Func<List<int>, List<int>> CreateReverseFunc()
        {
            List<int> numbers = new List<int>();
            return (List<int> tmp) =>
            {
                for (int i = tmp.Count - 1; i >= 0; i--)
                    numbers.Add(tmp[i]);

                return numbers;
            };
        }
    }
}
