namespace _06.TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static int petrolPumps;
        private static Queue<int[]> pumps;

        static void Main(string[] args)
        {
            petrolPumps = int.Parse(Console.ReadLine());

            pumps = new Queue<int[]>();

            for (int currentPetrolPump = 0; currentPetrolPump < petrolPumps; currentPetrolPump++)
            {
                int[] commandArgs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                pumps.Enqueue(commandArgs);
            }

            for (int currentPetrolPump = 0; currentPetrolPump < petrolPumps; currentPetrolPump++)
            {
                if (CheckCurrentPetrolPump())
                {
                    Console.WriteLine(currentPetrolPump);
                    break;
                }

                pumps.Enqueue(pumps.Dequeue());
            }
        }

        private static bool CheckCurrentPetrolPump()
        {
            int totalFuel = 0;
            bool isFind = true;

            for (int currentPetrolPump = 0; currentPetrolPump < petrolPumps; currentPetrolPump++)
            {
                int[] pumpParams = pumps.Dequeue();
                pumps.Enqueue(pumpParams);

                int pumpFuel = pumpParams[0];
                int nextPumpDistance = pumpParams[1];

                totalFuel += pumpFuel - nextPumpDistance;

                if (totalFuel < 0)
                {
                    isFind = false;
                }
            }

            return isFind;
        }
    }
}
