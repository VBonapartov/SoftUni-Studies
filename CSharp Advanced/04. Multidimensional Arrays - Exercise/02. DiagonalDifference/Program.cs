namespace _02.DiagonalDifference
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int sizeSquareMatrix = int.Parse(Console.ReadLine());

            int[][] matrix = new int[sizeSquareMatrix][];

            for (int row = 0; row < sizeSquareMatrix; row++)
            {
                matrix[row] = Console.ReadLine()
                                        .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();
            }

            long sumFirstDiagonal = 0;
            for (int row = 0; row < sizeSquareMatrix; row++)
            {
                sumFirstDiagonal += matrix[row][row];
            }

            long sumSecondDiagonal = 0;
            for (int row = sizeSquareMatrix - 1; row >= 0; row--)
            {
                sumSecondDiagonal += matrix[row][sizeSquareMatrix - row - 1];
            }

            Console.WriteLine(Math.Abs(sumFirstDiagonal - sumSecondDiagonal));
        }
    }
}
