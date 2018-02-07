namespace _09.StackFibonacci
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static Stack<long> fibonacci;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            fibonacci = new Stack<long>();
            fibonacci.Push(0);
            fibonacci.Push(1);

            Console.WriteLine(GetFibonacci(n));
        }

        private static long GetFibonacci(int n)
        {
            for (int i = 1; i < n; i++)
            {
                long fibPrevious = fibonacci.Pop();
                long fibNext = fibonacci.Peek() + fibPrevious;

                fibonacci.Push(fibPrevious);
                fibonacci.Push(fibNext);
            }

            return fibonacci.Peek();
        }
    }
}
