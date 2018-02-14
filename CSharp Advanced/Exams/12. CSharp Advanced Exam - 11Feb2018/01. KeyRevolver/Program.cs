using System;

namespace _01._KeyRevolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int sizeOfTheGunBarrel = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            List<int> locks = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int intelligenceValue = int.Parse(Console.ReadLine());

            int currentSizeOfTheGunBarrel = sizeOfTheGunBarrel;
            int numberOfBullets = 0;

            while (locks.Count > 0 && bullets.Count > 0)
            {
                numberOfBullets++;
                int currentBullet = bullets.Pop();
                int currentLock = locks[0];

                if (currentBullet <= currentLock)
                {
                    locks.RemoveAt(0);
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                currentSizeOfTheGunBarrel--;

                if (bullets.Count > 0 && currentSizeOfTheGunBarrel == 0)
                {
                    Console.WriteLine("Reloading!");
                    currentSizeOfTheGunBarrel = sizeOfTheGunBarrel;
                }
            }

            if (locks.Count == 0)
            {
                int bulletCost = numberOfBullets * bulletPrice;
                int earned = intelligenceValue - bulletCost;

                Console.WriteLine($"{bullets.Count} bullets left. Earned ${earned}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
