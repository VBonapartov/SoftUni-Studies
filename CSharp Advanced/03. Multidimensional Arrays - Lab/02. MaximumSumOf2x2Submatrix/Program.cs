namespace _02.MaximumSumOf2x2Submatrix
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine()
                              .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(int.Parse)
                              .ToArray();

            int rows = matrixSizes[0];
            int cols = matrixSizes[1];

            int[][] matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                                          .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToArray();
            }

            int resultRow = 0;
            int resultCol = 0;
            int totalSum = int.MinValue;
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    int currentSquareSum = matrix[row][col] + matrix[row][col + 1] + matrix[row + 1][col] + matrix[row + 1][col + 1];

                    if (currentSquareSum > totalSum)
                    {
                        totalSum = currentSquareSum;
                        resultRow = row;
                        resultCol = col;
                    }
                }
            }

            Console.WriteLine("{0} {1}", matrix[resultRow][resultCol], matrix[resultRow][resultCol + 1]);
            Console.WriteLine("{0} {1}", matrix[resultRow + 1][resultCol], matrix[resultRow + 1][resultCol + 1]);
            Console.WriteLine(totalSum);
        }
    }
}
