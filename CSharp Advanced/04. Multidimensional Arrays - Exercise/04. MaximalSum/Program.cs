namespace _04.MaximalSum
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine()
                                          .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToArray();

            int rows = matrixSizes[0];
            int cols = matrixSizes[1];

            int[][] matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                                          .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToArray();
            }

            int resultRow = 0;
            int resultCol = 0;
            int maxSum = int.MinValue;

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int sum = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2] +
                              matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2] +
                              matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        resultRow = row;
                        resultCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine("{0} {1} {2}", matrix[resultRow][resultCol], matrix[resultRow][resultCol + 1], matrix[resultRow][resultCol + 2]);
            Console.WriteLine("{0} {1} {2}", matrix[resultRow + 1][resultCol], matrix[resultRow + 1][resultCol + 1], matrix[resultRow + 1][resultCol + 2]);
            Console.WriteLine("{0} {1} {2}", matrix[resultRow + 2][resultCol], matrix[resultRow + 2][resultCol + 1], matrix[resultRow + 2][resultCol + 2]);
        }
    }
}
