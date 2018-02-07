namespace _02.BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            int n = input[0]; // representing the amount of elements to push onto the stack
            int s = input[1]; // representing the amount of elements to pop from the stack
            int x = input[2]; // element that you should check whether is present in the stack

            int[] intNumbers = Console.ReadLine()
                                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            Stack<int> numbers = new Stack<int>(intNumbers);

            while (numbers.Count > 0 && s > 0)
            {
                numbers.Pop();
                s--;
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (numbers.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                int minElement = numbers.Min();
                Console.WriteLine(minElement);
            }
        }
    }
}
