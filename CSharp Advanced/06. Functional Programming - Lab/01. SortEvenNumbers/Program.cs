namespace _01.SortEvenNumbers
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Console.ReadLine()
                                                            .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                                                            .Select(int.Parse)
                                                            .Where(n => n % 2 == 0)
                                                            .OrderBy(n => n)
                                                            .ToList()

                                          )
                             );
        }
    }
}
