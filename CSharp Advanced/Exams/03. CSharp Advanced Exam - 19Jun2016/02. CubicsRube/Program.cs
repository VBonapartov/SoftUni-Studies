namespace _02.CubicsRube
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int dimenssions = int.Parse(Console.ReadLine());

            int cellsValueNotChanged = (int)Math.Pow(dimenssions, 3);
            long particlesSum = GetParticlesSum(dimenssions, ref cellsValueNotChanged);

            PrintResult(particlesSum, cellsValueNotChanged);
        }

        private static long GetParticlesSum(int dimenssions, ref int cellsValueNotChanged)
        {
            long particlesSum = 0;
            string input = string.Empty;

            while(!(input = Console.ReadLine()).Equals("Analyze"))
            {
                int[] cmdArgs = input
                                    .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

                if(cmdArgs[3] == 0 || !IsCellValid(dimenssions, cmdArgs[0], cmdArgs[1], cmdArgs[2]))
                {
                    continue;
                }

                particlesSum += cmdArgs[3];
                cellsValueNotChanged--;
            }

            return particlesSum;
        }

        private static bool IsCellValid (int dimenssions, int x, int y, int z)
        {
            return x >= 0 && y >= 0 && z >= 0 &&
                   x < dimenssions && y < dimenssions && z < dimenssions;
        }

        private static void PrintResult(long particlesSum, int cellsValueNotChanged)
        { 
            Console.WriteLine(particlesSum);
            Console.WriteLine(cellsValueNotChanged);
        }
    }
}
