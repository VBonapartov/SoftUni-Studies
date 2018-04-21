namespace _02._GenericBoxOfInteger
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Box<int>> integers = GetInputIntegers();
            PrintResult(integers);
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

        private static void PrintResult(List<Box<int>> integers)
        {
            foreach (Box<int> box in integers)
            {
                Console.WriteLine(box);
            }
        }
    }
}
