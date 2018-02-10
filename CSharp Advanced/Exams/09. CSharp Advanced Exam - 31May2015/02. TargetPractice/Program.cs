namespace _02.TargetPractice
{
    using System;
    using System.Linq;
    using System.Text;

    class Program
    {
        private static char[,] matrix;

        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            string snake = Console.ReadLine();

            InitializeMatrix(rows, cols, snake);
            Fire();
            ReArrangeMatrix();
            PrintResult();
        }

        private static void InitializeMatrix(int rows, int cols, string snake)
        {
            matrix = new char[rows, cols];

            int rowCount = 0;
            int snakeIndex = 0;

            for(int row = rows - 1; row >= 0; row--)
            {                
                if(rowCount++ % 2 == 0)
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        snakeIndex = (snakeIndex > snake.Length - 1) ? 0 : snakeIndex;
                        matrix[row, col] = snake[snakeIndex++];
                    }
                }
                else
                {
                    for (int col = 0; col < cols; col++)
                    {
                        snakeIndex = (snakeIndex > snake.Length - 1) ? 0 : snakeIndex;
                        matrix[row, col] = snake[snakeIndex++];
                    }
                }
            }
        }

        private static void Fire()
        {
            int[] shotParameters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int impactRow = shotParameters[0];
            int impactCol = shotParameters[1];
            int radius = shotParameters[2];

            if (impactRow < 0 || impactRow > matrix.GetLength(0) - 1 ||
                impactCol < 0 || impactCol > matrix.GetLength(1) - 1)
            {
                return;
            }

            for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix.GetLength(1); colIndex++)
                {
                    int ditance = (colIndex - impactCol) * (colIndex - impactCol) +
                                  (rowIndex - impactRow) * (rowIndex - impactRow);

                    if (ditance <= radius * radius)
                    {
                        matrix[rowIndex, colIndex] = ' ';
                    }
                }
            }
        }

        private static void ReArrangeMatrix()
        {
            bool isChanged = true;

            while (isChanged)
            {
                isChanged = false;

                for (int rowIndex = matrix.GetLength(0) - 2; rowIndex >= 0; rowIndex--)
                {
                    for (int colIndex = 0; colIndex < matrix.GetLength(1); colIndex++)
                    {
                        if (!matrix[rowIndex, colIndex].Equals(' ') && matrix[rowIndex + 1, colIndex].Equals(' '))
                        {
                            matrix[rowIndex + 1, colIndex] = matrix[rowIndex, colIndex];
                            matrix[rowIndex, colIndex] = ' ';

                            isChanged = true;
                        }
                    }
                }
            }           
        }

        private static void PrintResult()
        {
            StringBuilder sb = new StringBuilder();

            for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix.GetLength(1); colIndex++)
                {
                    sb.Append(matrix[rowIndex, colIndex]);
                }

                sb.Append(Environment.NewLine);
            }

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
