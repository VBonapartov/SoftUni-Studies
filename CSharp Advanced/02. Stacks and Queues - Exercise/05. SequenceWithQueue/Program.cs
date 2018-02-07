namespace _05.SequenceWithQueue
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());

            Queue<long> numbers = new Queue<long>();
            numbers.Enqueue(number);

            Queue<long> result = new Queue<long>();

            while (result.Count < 50)
            {
                long currentNumber = numbers.Dequeue();

                numbers.Enqueue(currentNumber + 1);
                numbers.Enqueue(2 * currentNumber + 1);
                numbers.Enqueue(currentNumber + 2);

                result.Enqueue(currentNumber);
            }

            while (result.Count > 0)
            {
                Console.Write(result.Dequeue() + " ");
            }

            Console.WriteLine();
        }
    }
}