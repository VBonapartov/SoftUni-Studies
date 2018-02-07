namespace _11.PoisonousPlants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] plants = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[] days = new int[n];
            Stack<int> indexes = new Stack<int>();
            indexes.Push(0);

            for (int i = 1; i < plants.Length; i++)
            {
                int maxDays = 0;

                while (indexes.Count > 0 && plants[indexes.Peek()] >= plants[i])
                {
                    maxDays = Math.Max(maxDays, days[indexes.Pop()]);
                }

                if (indexes.Count > 0)
                {
                    days[i] = maxDays + 1;
                }

                indexes.Push(i);
            }

            Console.WriteLine(days.Max());
        }
    }
}
