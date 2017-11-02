using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplyTargetedCell
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] matrix = new int[rows, cols];
            matrix = InitializeMatrix(rows, cols);

            int[] targetPosition = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int targetRow = targetPosition[0];
            int targetCol = targetPosition[1];

            MatrixCalculations(matrix, targetRow, targetCol);
            PrintMatrix(matrix);
        }

        private static int[,] InitializeMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] callsValues = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = callsValues[col];
                }
            }

            return matrix;
        }

        private static void MatrixCalculations(int[,] matrix, int targetRow, int targetCol)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int startRow = targetRow - 1;
            int endRow = targetRow + 1;
            startRow = (startRow < 0) ? 0 : startRow;
            endRow = (endRow > rows - 1) ? rows - 1 : endRow;

            int startCol = targetCol - 1;
            int endCol = targetCol + 1;
            startCol = (startCol < 0) ? 0 : startCol;
            endCol = (endCol > cols - 1) ? cols - 1 : endCol;

            int allNeighboringCellsSum = 0;
            for (int row = startRow; row <= endRow; row++)
            {
                for (int col = startCol; col <= endCol; col++)
                {
                    if (row == targetRow && col == targetCol)
                        continue;
                    
                    allNeighboringCellsSum += matrix[row, col];
                    matrix[row, col] *= matrix[targetRow, targetCol];
                }
            }

            matrix[targetRow, targetCol] *= allNeighboringCellsSum;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
