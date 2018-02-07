namespace _04.BasicQueueOperations
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

            int n = input[0]; // representing the amount of elements to enqueue onto the queue
            int s = input[1]; // representing the amount of elements to dequeue from the queue
            int x = input[2]; // element that you should check whether is present in the queue

            int[] intNumbers = Console.ReadLine()
                                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            Queue<int> numbers = new Queue<int>(intNumbers);

            while (numbers.Count > 0 && s > 0)
            {
                numbers.Dequeue();
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
