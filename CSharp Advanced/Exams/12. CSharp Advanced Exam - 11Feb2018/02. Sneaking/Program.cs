namespace _02._Sneaking
{
    using System;

    class Program
    {
        private static char[][] room;

        static void Main(string[] args)
        {
            InitializeRoom();
            ExecuteCommands();
        }

        private static void InitializeRoom()
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            room = new char[numberOfRows][];

            string firstRow = Console.ReadLine();
            room[0] = new char[firstRow.Length];
            room[0] = firstRow.ToCharArray();

            for (int row = 1; row < numberOfRows; row++)
            {
                room[row] = new char[firstRow.Length];
                room[row] = Console.ReadLine().ToCharArray();
            }
        }

        private static void ExecuteCommands()
        {
            string commands = Console.ReadLine();

            int[] samPosition = GetSamPosition();

            for (int i = 0; i < commands.Length; i++)
            {
                EnemyMove();
                if (IsEnemyKillSam(samPosition))
                {
                    room[samPosition[0]][samPosition[1]] = 'X';
                    Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                    break;
                }

                switch (commands[i])
                {
                    case 'U':
                        MoveSamUp(samPosition);
                        break;

                    case 'D':
                        MoveSamDown(samPosition);
                        break;

                    case 'L':
                        MoveSamLeft(samPosition);
                        break;

                    case 'R':
                        MoveSamRight(samPosition);
                        break;

                    case 'W':
                        break;
                }

                if (IsNikoladzeKilled(samPosition))
                {
                    Console.WriteLine($"Nikoladze killed!");
                    break;
                }
            }

            PrintRoom();
        }

        private static int[] GetSamPosition()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col].Equals('S'))
                    {
                        return new[] { row, col };
                    }
                }
            }

            return null;
        }

        private static void EnemyMove()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    // move right
                    if (room[row][col].Equals('b'))
                    {
                        // Enemy turns around - left
                        if (col == room[row].Length - 1)
                        {
                            room[row][col] = 'd';
                        }
                        else
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                        }

                        break;
                    }

                    // move left
                    if (room[row][col].Equals('d'))
                    {
                        // Enemy turns around - right
                        if (col == 0)
                        {
                            room[row][col] = 'b';
                        }
                        else
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }

                        break;
                    }
                }
            }
        }

        private static bool IsEnemyKillSam(int[] samPosition)
        {
            int samRow = samPosition[0];
            int samCol = samPosition[1];

            for (int col = 0; col < room[samRow].Length; col++)
            {
                if (room[samRow][col].Equals('b'))
                {
                    if (col < samCol)
                    {
                        return true;
                    }

                    return false;
                }

                if (room[samRow][col].Equals('d'))
                {
                    if (col > samCol)
                    {
                        return true;
                    }

                    return false;
                }
            }

            return false;
        }

        private static bool IsNikoladzeKilled(int[] samPosition)
        {
            int samRow = samPosition[0];

            for (int col = 0; col < room[samRow].Length; col++)
            {
                if (room[samRow][col].Equals('N'))
                {
                    room[samRow][col] = 'X';
                    return true;
                }
            }

            return false;
        }

        private static void MoveSamUp(int[] samPosition)
        {
            int samRowPos = samPosition[0];
            int samColPos = samPosition[1];

            int nextSamRowPos = samRowPos - 1;

            room[samRowPos][samColPos] = '.';
            room[nextSamRowPos][samColPos] = 'S';
            samPosition[0] = nextSamRowPos;
        }

        private static void MoveSamDown(int[] samPosition)
        {
            int samRowPos = samPosition[0];
            int samColPos = samPosition[1];

            int nextSamRowPos = samRowPos + 1;

            room[samRowPos][samColPos] = '.';
            room[nextSamRowPos][samColPos] = 'S';
            samPosition[0] = nextSamRowPos;
        }

        private static void MoveSamRight(int[] samPosition)
        {
            int samRowPos = samPosition[0];
            int samColPos = samPosition[1];

            int nextSamColPos = samColPos + 1;

            room[samRowPos][samColPos] = '.';
            room[samRowPos][nextSamColPos] = 'S';
            samPosition[1] = nextSamColPos;
        }

        private static void MoveSamLeft(int[] samPosition)
        {
            int samRowPos = samPosition[0];
            int samColPos = samPosition[1];

            int nextSamColPos = samColPos - 1;

            room[samRowPos][samColPos] = '.';
            room[samRowPos][nextSamColPos] = 'S';
            samPosition[1] = nextSamColPos;
        }

        private static void PrintRoom()
        {
            foreach (char[] row in room)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
