using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlurFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            int blurAmount = int.Parse(Console.ReadLine());
            int[] rowsAndCols = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            long[,] matrix = new long[rows, cols];
            for(int row = 0; row < rows; row++)
            {
                long[] valCol = Console.ReadLine().Split(' ').Select(long.Parse).ToArray(); 
                for(int col = 0; col < cols; col++)
                {
                    matrix[row, col] = valCol[col];
                }
            }

            int[] coordinatesOfTheBlur = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int blurRow = coordinatesOfTheBlur[0];
            int blurCol = coordinatesOfTheBlur[1];

            int startRow = blurRow - 1;
            int startCol = blurCol - 1;
            startRow = (startRow < 0) ? 0 : startRow;
            startCol = (startCol < 0) ? 0 : startCol;

            int endRow = blurRow + 1;
            int endCol = blurCol + 1;
            endRow = (endRow > rows - 1) ? rows - 1 : endRow;
            endCol = (endCol > cols - 1) ? cols - 1 : endCol;

            for(int row = startRow; row <= endRow; row++)
            {
                for (int col = startCol; col <= endCol; col++)
                {
                    matrix[row, col] += blurAmount;
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(long[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
