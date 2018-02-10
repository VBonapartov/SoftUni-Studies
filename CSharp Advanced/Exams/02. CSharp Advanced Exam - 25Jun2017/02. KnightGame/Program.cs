namespace _02.KnightGame
{
    using System;

    class Program
    {
        private static char[][] board;

        static void Main(string[] args)
        {
            int boardSize = int.Parse(Console.ReadLine());

            InitializeBoard(boardSize);
            RemoveKnights();
        }

        private static void InitializeBoard(int boardSize)
        {
            board = new char[boardSize][];

            for(int row = 0; row < boardSize; row++)
            {
                board[row] = Console.ReadLine().ToCharArray();
            }
        }

        private static void RemoveKnights()
        {
            int currentKnightsInDanger = 0;
            int maxKnightsInDanger = -1;

            int mostDangerousKnightRow = 0;
            int mostDangerousKnightCol = 0;

            int countRemoveKnights = 0;

            while (true)
            {
                for (int rowIndex = 0; rowIndex < board.Length; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < board[rowIndex].Length; colIndex++)
                    {
                        if (board[rowIndex][colIndex].Equals('K'))
                        {
                            currentKnightsInDanger = GetCurrentKnightsInDanger(rowIndex, colIndex);
                        }

                        if (currentKnightsInDanger > maxKnightsInDanger)
                        {
                            maxKnightsInDanger = currentKnightsInDanger;
                            mostDangerousKnightRow = rowIndex;
                            mostDangerousKnightCol = colIndex;
                        }

                        currentKnightsInDanger = 0;
                    }
                }
                                
                if (maxKnightsInDanger != 0)
                {
                    // remove most dangerous knight
                    board[mostDangerousKnightRow][mostDangerousKnightCol] = 'O';

                    countRemoveKnights++;
                    maxKnightsInDanger = 0;
                }
                else
                {
                    Console.WriteLine(countRemoveKnights);
                    break;
                }
            }
        }

        private static int GetCurrentKnightsInDanger(int rowIndex, int colIndex)
        {
            int currentKnightsInDanger = 0;

            // vertical and left
            if (IsCellInMatrix(rowIndex - 2, colIndex - 1))
            {
                if (board[rowIndex - 2][colIndex - 1].Equals('K'))
                {
                    currentKnightsInDanger++;
                }
            }

            // vertical and right
            if (IsCellInMatrix(rowIndex - 2, colIndex + 1))
            {
                if (board[rowIndex - 2][colIndex + 1].Equals('K'))
                {
                    currentKnightsInDanger++;
                }
            }

            // vertical and left
            if (IsCellInMatrix(rowIndex + 2, colIndex - 1))
            {
                if (board[rowIndex + 2][colIndex - 1].Equals('K'))
                {
                    currentKnightsInDanger++;
                }
            }

            // vertical and right
            if (IsCellInMatrix(rowIndex + 2, colIndex + 1))
            {
                if (board[rowIndex + 2][colIndex + 1].Equals('K'))
                {
                    currentKnightsInDanger++;
                }
            }

            // horizontal up and left
            if (IsCellInMatrix(rowIndex - 1, colIndex - 2))
            {
                if (board[rowIndex - 1][colIndex - 2].Equals('K'))
                {
                    currentKnightsInDanger++;
                }
            }

            // horizontal up and right
            if (IsCellInMatrix(rowIndex - 1, colIndex + 2))
            {
                if (board[rowIndex - 1][colIndex + 2].Equals('K'))
                {
                    currentKnightsInDanger++;
                }
            }

            // horizontal down and left
            if (IsCellInMatrix(rowIndex + 1, colIndex - 2))
            {
                if (board[rowIndex + 1][colIndex - 2].Equals('K'))
                {
                    currentKnightsInDanger++;
                }
            }

            // horizontal down and right
            if (IsCellInMatrix(rowIndex + 1, colIndex + 2))
            {
                if (board[rowIndex + 1][colIndex + 2].Equals('K'))
                {
                    currentKnightsInDanger++;
                }
            }

            return currentKnightsInDanger;
        }

        private static bool IsCellInMatrix(int row, int col)
        {
            return  row >= 0 &&
                    row < board.Length &&
                    col >= 0 &&
                    col < board[row].Length;
        }
    }
}
