using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDim = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[,] matrix = new int[matrixDim[0], matrixDim[1]];
            InitizeMatrix(matrix);
            Calculations(matrix);
            PrintMatrix(matrix);
        }

        private static void InitizeMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                int[] cellValues = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = cellValues[col];
                }
            }
        }

        private static void Calculations(int[,] matrix)
        {
            int[] posTargetCell = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int targetCellRow = posTargetCell[0];
            int targetCellCol = posTargetCell[1];

            int sumNeighboringCells = 0;
            for (int row = targetCellRow - 1; row <= targetCellRow + 1; row++)
            {
                for (int col = targetCellCol - 1; col <= targetCellCol + 1; col++)
                {
                    if (row == targetCellRow && col == targetCellCol)
                        continue;

                    sumNeighboringCells += matrix[row, col];
                    matrix[row, col] *= matrix[targetCellRow, targetCellCol];
                }
            }

            matrix[targetCellRow, targetCellCol] *= sumNeighboringCells;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
