namespace _06.TargetPractice
{
    using System;
    using System.Linq;

    class Program
    {
        private static char[][] matrix;

        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine()
                  .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToArray();

            int rows = matrixSizes[0];
            int cols = matrixSizes[1];

            string snake = Console.ReadLine();

            int[] shotParams = Console.ReadLine()
                  .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToArray();

            int impactRow = shotParams[0];
            int impactCol = shotParams[1];
            int radius = shotParams[2];

            InitializeMatrix(rows, cols, snake);
            ShotTheMatrix(impactRow, impactCol, radius);
            ReArrengeMatrix();
            PrintMatrix();
        }

        private static void InitializeMatrix(int rows, int cols, string snake)
        {
            int index = 0;

            matrix = new char[rows][];

            for (int row = rows - 1; row >= 0; row--)
            {
                matrix[row] = new char[cols];

                if ((rows - row - 1) % 2 == 0)
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        index = (index >= snake.Length) ? 0 : index;
                        matrix[row][col] = snake[index++];
                    }
                }
                else
                {
                    for (int col = 0; col < cols; col++)
                    {
                        index = (index >= snake.Length) ? 0 : index;
                        matrix[row][col] = snake[index++];
                    }
                }
            }
        }

        private static void ShotTheMatrix(int impactRow, int impactCol, int radius)
        {
            if (impactRow < 0 || impactRow > matrix.Length - 1)
                return;

            if (impactCol < 0 || impactCol > matrix[0].Length)
                return;

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                {
                    int ditance = (colIndex - impactCol) * (colIndex - impactCol) +
                                  (rowIndex - impactRow) * (rowIndex - impactRow);

                    if (ditance <= radius * radius)
                    {
                        matrix[rowIndex][colIndex] = ' ';
                    }
                }
            }
        }

        private static void ReArrengeMatrix()
        {
            for (int row = matrix.Length - 2; row >= 0; row--)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    for (int i = row + 1; i < matrix.Length; i++)
                    {
                        if (matrix[i][col].Equals(' '))
                        {
                            matrix[i][col] = matrix[i - 1][col];
                            matrix[i - 1][col] = ' ';
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        private static void PrintMatrix()
        {
            foreach (char[] row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
