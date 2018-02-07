namespace _06.MathPotato
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int number = int.Parse(Console.ReadLine());

            Queue<string> names = new Queue<string>(input);
            int cycle = 1;
            while (names.Count > 1)
            {
                for (int i = 0; i < number - 1; i++)
                {
                    names.Enqueue(names.Dequeue());
                }

                if (PrimeTool.IsPrime(cycle))
                {
                    Console.WriteLine($"Prime {names.Peek()}");
                }
                else
                {
                    Console.WriteLine($"Removed {names.Dequeue()}");
                }

                cycle++;
            }

            Console.WriteLine($"Last is {names.Dequeue()}");
        }
    }

    public static class PrimeTool
    {
        public static bool IsPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            int boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}
