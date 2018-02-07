namespace _03.GroupNumbers
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine()
                                            .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToArray();

            int[][] result = new int[3][];

            result[0] = inputNumbers.Where(i => i % 3 == 0).ToArray();
            result[1] = inputNumbers.Where(i => i % 3 == 1 || i % 3 == -1).ToArray();
            result[2] = inputNumbers.Where(i => i % 3 == 2 || i % 3 == -2).ToArray();

            foreach (int[] row in result)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
