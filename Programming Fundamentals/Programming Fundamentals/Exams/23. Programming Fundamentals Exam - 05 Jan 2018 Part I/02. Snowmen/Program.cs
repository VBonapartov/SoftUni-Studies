namespace _02.Snowmen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            List<int> snowmen = Console.ReadLine()
                                        .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToList();

            while (snowmen.Count > 1)
            {
                HashSet<int> losers = new HashSet<int>();

                for (int i = 0; i < snowmen.Count; i++)
                {
                    if (losers.Contains(i))
                        continue;

                    int attackerIndex = i;
                    int targetIndex = (snowmen[i] >= snowmen.Count) ? snowmen[i] % snowmen.Count : snowmen[i];

                    if (attackerIndex == targetIndex)
                    {
                        Console.WriteLine($"{attackerIndex} performed harakiri");
                        losers.Add(i);
                    }
                    else if (Math.Abs(attackerIndex - targetIndex) % 2 == 0)
                    {
                        Console.WriteLine($"{attackerIndex} x {targetIndex} -> {attackerIndex} wins");
                        losers.Add(targetIndex);
                    }
                    else
                    {
                        Console.WriteLine($"{attackerIndex} x {targetIndex} -> {targetIndex} wins");
                        losers.Add(attackerIndex);
                    }

                    if (snowmen.Count - losers.Count <= 1)
                        return;
                }

                snowmen = snowmen.Where((x, i) => !losers.Contains(i)).ToList();
            }
        }
    }
}
