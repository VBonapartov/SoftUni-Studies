namespace _01.ReverseNumbersWithStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().Trim();

            try
            {
                int[] intNumbers = input
                                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

                Stack<int> numbers = new Stack<int>(intNumbers);

                while (numbers.Count != 0)
                {
                    Console.Write(numbers.Pop() + " ");
                }

                Console.WriteLine();
            }
            catch (FormatException)
            {
                //Console.WriteLine(input);
            }
        }
    }
}
