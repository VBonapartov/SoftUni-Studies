namespace _02.SumNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                          .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToList();

            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Sum());
        }
    }
}
