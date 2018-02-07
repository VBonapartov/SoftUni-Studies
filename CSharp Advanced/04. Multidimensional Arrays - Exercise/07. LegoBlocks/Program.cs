namespace _07.LegoBlocks
{
    using System;
    using System.Linq;

    class Program
    {
        private static int[][] firstJaggedArr;
        private static int[][] secondJaggedArr;

        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());

            InitializeJaggedArrays(numberOfRows);
            ReverseSecondJaggedArray(numberOfRows);

            if (IsFit(numberOfRows))
            {
                PrintRectangularMatrix(numberOfRows);
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {CountCellsInArrays()}");
            }
        }

        private static void InitializeJaggedArrays(int numberOfRows)
        {
            firstJaggedArr = new int[numberOfRows][];
            secondJaggedArr = new int[numberOfRows][];

            for (int row = 0; row < numberOfRows; row++)
            {
                firstJaggedArr[row] = Console.ReadLine()
                                            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToArray();
            }

            for (int row = 0; row < numberOfRows; row++)
            {
                secondJaggedArr[row] = Console.ReadLine()
                                            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToArray();
            }
        }

        private static void ReverseSecondJaggedArray(int numberOfRows)
        {
            for (int row = 0; row < numberOfRows; row++)
            {
                secondJaggedArr[row] = secondJaggedArr[row].Reverse().ToArray();
            }
        }

        private static bool IsFit(int numberOfRows)
        {
            int rowLength = firstJaggedArr[0].Length + secondJaggedArr[0].Length;

            for (int row = 1; row < numberOfRows; row++)
            {
                if (firstJaggedArr[row].Length + secondJaggedArr[row].Length != rowLength)
                {
                    return false;
                }
            }

            return true;
        }

        private static void PrintRectangularMatrix(int numberOfRows)
        {
            for (int row = 0; row < numberOfRows; row++)
            {
                Console.WriteLine($"[{string.Join(", ", firstJaggedArr[row])}, {string.Join(", ", secondJaggedArr[row])}]");
            }
        }

        private static int CountCellsInArrays()
        {
            int totalCells = 0;

            foreach (int[] row in firstJaggedArr)
                totalCells += row.Count();

            foreach (int[] row in secondJaggedArr)
                totalCells += row.Count();

            return totalCells;
        }
    }
}
