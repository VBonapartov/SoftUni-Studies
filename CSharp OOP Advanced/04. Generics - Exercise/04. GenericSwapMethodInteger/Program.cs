namespace _04._GenericSwapMethodInteger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Box<int>> integers = GetInputIntegers();
            SwapAndPrintResult(integers);
        }

        private static List<Box<int>> GetInputIntegers()
        {
            List<Box<int>> integers = new List<Box<int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));
                integers.Add(box);
            }

            return integers;
        }

        private static void SwapAndPrintResult(List<Box<int>> integers)
        {
            int[] indecies = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Box<int>.Swap(integers, indecies[0], indecies[1]);

            foreach (Box<int> box in integers)
            {
                Console.WriteLine(box);
            }
        }
    }
}
