namespace _05.RubiksMatrix
{
    using System;
    using System.Linq;

    class Program
    {
        private static int[][] rubiksMatrix;

        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine()
                              .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(int.Parse)
                              .ToArray();

            InitializeRubiksMatrix(matrixSizes[0], matrixSizes[1]);

            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandArgs = Console.ReadLine().Split(' ');
                ExecuteCommand(commandArgs);
            }

            RearrangeRubiksMatrix();
        }

        private static void InitializeRubiksMatrix(int rows, int cols)
        {
            rubiksMatrix = new int[rows][];

            int num = 1;
            for (int row = 0; row < rows; row++)
            {
                rubiksMatrix[row] = new int[cols];

                for (int col = 0; col < cols; col++)
                {
                    rubiksMatrix[row][col] = num++;
                }
            }
        }

        private static void ExecuteCommand(string[] commandArgs)
        {
            switch (commandArgs[1])
            {
                case "up":
                    Up(int.Parse(commandArgs[0]), int.Parse(commandArgs[2]));
                    break;

                case "down":
                    Down(int.Parse(commandArgs[0]), int.Parse(commandArgs[2]));
                    break;

                case "left":
                    Left(int.Parse(commandArgs[0]), int.Parse(commandArgs[2]));
                    break;

                case "right":
                    Right(int.Parse(commandArgs[0]), int.Parse(commandArgs[2]));
                    break;
            }
        }

        private static void Up(int column, int moves)
        {
            if (column < 0 || column > rubiksMatrix[0].Length)
            {
                return;
            }

            moves %= rubiksMatrix.Length;
            while (moves > 0)
            {
                int firstElement = rubiksMatrix[0][column];

                for (int row = 0; row < rubiksMatrix.Length - 1; row++)
                {
                    rubiksMatrix[row][column] = rubiksMatrix[row + 1][column];
                }

                rubiksMatrix[rubiksMatrix.Length - 1][column] = firstElement;

                moves--;
            }
        }

        private static void Down(int column, int moves)
        {
            if (column < 0 || column > rubiksMatrix[0].Length)
            {
                return;
            }

            moves %= rubiksMatrix.Length;
            while (moves > 0)
            {
                int lastElement = rubiksMatrix[rubiksMatrix.Length - 1][column];

                for (int row = rubiksMatrix.Length - 1; row > 0; row--)
                {
                    rubiksMatrix[row][column] = rubiksMatrix[row - 1][column];
                }

                rubiksMatrix[0][column] = lastElement;

                moves--;
            }
        }

        private static void Left(int row, int moves)
        {
            if (row < 0 || row > rubiksMatrix.Length)
            {
                return;
            }

            moves %= rubiksMatrix[0].Length;
            while (moves > 0)
            {
                int firstElement = rubiksMatrix[row][0];

                for (int col = 0; col < rubiksMatrix[0].Length - 1; col++)
                {
                    rubiksMatrix[row][col] = rubiksMatrix[row][col + 1];
                }

                rubiksMatrix[row][rubiksMatrix[0].Length - 1] = firstElement;

                moves--;
            }
        }

        private static void Right(int row, int moves)
        {
            if (row < 0 || row > rubiksMatrix.Length)
            {
                return;
            }

            moves %= rubiksMatrix[0].Length;
            while (moves > 0)
            {
                int lastElement = rubiksMatrix[row][rubiksMatrix[0].Length - 1];

                for (int col = rubiksMatrix[0].Length - 1; col > 0; col--)
                {
                    rubiksMatrix[row][col] = rubiksMatrix[row][col - 1];
                }

                rubiksMatrix[row][0] = lastElement;

                moves--;
            }
        }

        private static void RearrangeRubiksMatrix()
        {
            for (int row = 0; row < rubiksMatrix.Length; row++)
            {
                int firstRowNumber = rubiksMatrix[0].Length * row + 1;

                for (int col = 0; col < rubiksMatrix[0].Length; col++)
                {
                    int currentNumber = firstRowNumber + col;

                    if (rubiksMatrix[row][col] != currentNumber)
                    {
                        (int rowNumber, int colNumber) = SearchNumberInMatrix(currentNumber);

                        rubiksMatrix[rowNumber][colNumber] = rubiksMatrix[row][col];
                        rubiksMatrix[row][col] = currentNumber;

                        Console.WriteLine($"Swap ({row}, {col}) with ({rowNumber}, {colNumber})");
                    }
                    else
                    {
                        Console.WriteLine($"No swap required");
                    }
                }
            }
        }

        private static (int rowNumber, int colNumber) SearchNumberInMatrix(int number)
        {
            for (int row = 0; row < rubiksMatrix.Length; row++)
            {
                for (int col = 0; col < rubiksMatrix[0].Length; col++)
                {
                    if (rubiksMatrix[row][col] == number)
                    {
                        return (row, col);
                    }
                }
            }

            return (0, 0);
        }
    }
}
