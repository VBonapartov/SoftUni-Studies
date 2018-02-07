namespace _08.CustomComparator
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Func<int, int, int> comparator = (x, y) =>
            (x % 2 == 0 && y % 2 != 0) ? -1 :
            (x % 2 != 0 && y % 2 == 0) ? 1 :
            x.CompareTo(y);

            Array.Sort(numbers, new Comparison<int>(comparator));
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
