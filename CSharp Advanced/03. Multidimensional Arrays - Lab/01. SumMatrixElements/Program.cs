namespace _01.SumMatrixElements
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
            int[][] matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                                          .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToArray();
            }

            Console.WriteLine(matrix.Length);
            Console.WriteLine(matrix[0].Length);

            int totalSum = 0;
            foreach (int[] row in matrix)
            {
                totalSum += row.Sum();
            }

            Console.WriteLine(totalSum);
        }
    }
}
