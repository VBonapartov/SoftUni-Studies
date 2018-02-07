namespace _03.MaximumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static Stack<int> numbers = new Stack<int>();
        private static Stack<int> maxNumbers = new Stack<int>();
        private static int max = int.MinValue;

        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                int[] commandArgs = Console.ReadLine()
                                        .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();

                ExecuteCommand(commandArgs);
            }
        }

        private static void ExecuteCommand(int[] commandArgs)
        {
            if (commandArgs[0] == 1)
            {
                numbers.Push(commandArgs[1]);

                if (commandArgs[1] > max)
                {
                    max = commandArgs[1];
                    maxNumbers.Push(max);
                }
            }
            else if (commandArgs[0] == 2)
            {
                if (numbers.Pop() == max)
                {
                    maxNumbers.Pop();
                    if (maxNumbers.Count != 0)
                    {
                        max = maxNumbers.Peek();
                    }
                    else
                    {
                        max = int.MinValue;
                    }
                }
            }
            else if (commandArgs[0] == 3)
            {
                Console.WriteLine(max);
            }
        }
    }
}
