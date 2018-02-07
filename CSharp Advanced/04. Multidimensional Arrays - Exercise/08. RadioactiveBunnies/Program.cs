namespace _08.RadioactiveBunnies
{
    using System;
    using System.Linq;

    class Program
    {
        private static char[][] lair;
        private static int[] playerPosition = new int[2];

        static void Main(string[] args)
        {
            int[] lairSizes = Console.ReadLine()
                                          .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToArray();

            int lairRows = lairSizes[0];
            int lairCols = lairSizes[1];

            InitializeLiar(lairRows, lairCols);

            string commands = Console.ReadLine();
            ExecuteCommands(commands);
        }

        private static void InitializeLiar(int lairRows, int lairCols)
        {
            lair = new char[lairRows][];
            for (int row = 0; row < lairRows; row++)
            {
                lair[row] = Console.ReadLine().Select(ch => ch).ToArray();
            }
        }

        private static void ExecuteCommands(string commands)
        {
            for (int i = 0; i < commands.Length; i++)
            {
                (int startRow, int startCol) = FindPlayerPosition();

                switch (commands[i])
                {
                    case 'U':
                        Up();
                        break;

                    case 'D':
                        Down();
                        break;

                    case 'L':
                        Left();
                        break;

                    case 'R':
                        Right();
                        break;
                }

                SpreadBunnies();

                if (IsPlayerDie(startRow, startCol) || IsPlayerWin(startRow, startCol))
                {
                    break;
                }
            }
        }

        private static void Up()
        {
            (int row, int col) = FindPlayerPosition();

            if (row != -1)
            {
                lair[row][col] = '.';

                if (row - 1 >= 0)
                {
                    if (!lair[row - 1][col].Equals('B'))
                    {
                        lair[row - 1][col] = 'P';
                    }

                    playerPosition[0] = row - 1;
                    playerPosition[1] = col;
                }
                else
                {
                    playerPosition[0] = row;
                    playerPosition[1] = col;
                }
            }
        }

        private static void Down()
        {
            (int row, int col) = FindPlayerPosition();

            if (row != -1)
            {
                lair[row][col] = '.';

                if (row + 1 < lair.Length)
                {
                    if (!lair[row + 1][col].Equals('B'))
                    {
                        lair[row + 1][col] = 'P';
                    }

                    playerPosition[0] = row + 1;
                    playerPosition[1] = col;
                }
                else
                {
                    playerPosition[0] = row;
                    playerPosition[1] = col;
                }
            }
        }

        private static void Left()
        {
            (int row, int col) = FindPlayerPosition();

            if (row != -1)
            {
                lair[row][col] = '.';

                if (col - 1 >= 0)
                {
                    if (!lair[row][col - 1].Equals('B'))
                    {
                        lair[row][col - 1] = 'P';
                    }

                    playerPosition[0] = row;
                    playerPosition[1] = col - 1;
                }
                else
                {
                    playerPosition[0] = row;
                    playerPosition[1] = col;
                }
            }
        }

        private static void Right()
        {
            (int row, int col) = FindPlayerPosition();

            if (row != -1)
            {
                lair[row][col] = '.';

                if (col + 1 < lair[row].Length)
                {
                    if (!lair[row][col + 1].Equals('B'))
                    {
                        lair[row][col + 1] = 'P';
                    }

                    playerPosition[0] = row;
                    playerPosition[1] = col + 1;
                }
                else
                {
                    playerPosition[0] = row;
                    playerPosition[1] = col;
                }
            }
        }

        private static void SpreadBunnies()
        {
            char[][] tempMatrix = new char[lair.Length][];
            for (int row = 0; row < lair.Length; row++)
            {
                tempMatrix[row] = (char[])lair[row].Clone();
            }

            for (int row = 0; row < lair.Length; row++)
            {
                for (int col = 0; col < lair[row].Length; col++)
                {
                    if (lair[row][col].Equals('B'))
                    {
                        if (row - 1 >= 0) tempMatrix[row - 1][col] = 'B';

                        if (row + 1 < lair.Length) tempMatrix[row + 1][col] = 'B';

                        if (col - 1 >= 0) tempMatrix[row][col - 1] = 'B';

                        if (col + 1 < lair[row].Length) tempMatrix[row][col + 1] = 'B';
                    }
                }
            }

            lair = tempMatrix;
        }

        private static (int row, int col) FindPlayerPosition()
        {
            for (int row = 0; row < lair.Length; row++)
            {
                for (int col = 0; col < lair[row].Length; col++)
                {
                    if (lair[row][col].Equals('P'))
                    {
                        return (row, col);
                    }
                }
            }

            return (-1, -1);
        }

        private static bool IsPlayerDie(int startRow, int startCol)
        {
            foreach (char[] row in lair)
            {
                if (row.Any(ch => ch.Equals('P')))
                {
                    return false;
                }
            }

            if (startRow == playerPosition[0] && startCol == playerPosition[1])
            {
                return false;
            }

            PrintResult("dead");
            return true;
        }

        private static bool IsPlayerWin(int startRow, int startCol)
        {
            if (startRow == playerPosition[0] && startCol == playerPosition[1])
            {
                playerPosition[0] = startRow;
                playerPosition[1] = startCol;

                PrintResult("won");
                return true;
            }

            return false;
        }

        private static void PrintResult(string message)
        {
            foreach (char[] row in lair)
            {
                Console.WriteLine(string.Join("", row));
            }

            Console.WriteLine($"{message}: {playerPosition[0]} {playerPosition[1]}");
        }
    }
}
