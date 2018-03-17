namespace P06_Sneaking
{
    using System;

    public class Sneaking
    {
        private static char[][] room;

        public static void Main()
        {
            InitializeRoom();
            ExecuteCommands();
            PrintRoomState();
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
            int samRowPos = samPosition[0];
            int samColPos = samPosition[1];

            for (int i = 0; i < commands.Length; i++)
            {
                EnemyMove();

                if (IsEnemyKilledSam(samRowPos, samColPos))
                {                    
                    Console.WriteLine($"Sam died at {samRowPos}, {samColPos}");
                    break;
                }

                switch (commands[i])
                {
                    case 'U':
                        room[samRowPos--][samColPos] = '.';                        
                        room[samRowPos][samColPos] = 'S';
                        break;

                    case 'D':
                        room[samRowPos++][samColPos] = '.';
                        room[samRowPos][samColPos] = 'S';
                        break;

                    case 'L':
                        room[samRowPos][samColPos--] = '.';
                        room[samRowPos][samColPos] = 'S';
                        break;

                    case 'R':
                        room[samRowPos][samColPos++] = '.';
                        room[samRowPos][samColPos] = 'S';
                        break;

                    case 'W':
                        break;
                }

                if (IsNikoladzeKilled(samRowPos))
                {
                    Console.WriteLine($"Nikoladze killed!");
                    break;
                }
            }            
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

        private static bool IsEnemyKilledSam(int samRowPos, int samColPos)
        {
            for (int col = 0; col < room[samRowPos].Length; col++)
            {
                if (room[samRowPos][col].Equals('b'))
                {
                    if (col < samColPos)
                    {
                        room[samRowPos][samColPos] = 'X';
                        return true;
                    }

                    return false;
                }

                if (room[samRowPos][col].Equals('d'))
                {
                    if (col > samColPos)
                    {
                        room[samRowPos][samColPos] = 'X';
                        return true;
                    }

                    return false;
                }
            }

            return false;
        }

        private static bool IsNikoladzeKilled(int samRowPos)
        {
            for (int col = 0; col < room[samRowPos].Length; col++)
            {
                if (room[samRowPos][col].Equals('N'))
                {
                    room[samRowPos][col] = 'X';
                    return true;
                }
            }

            return false;
        }

        private static void PrintRoomState()
        {
            foreach (char[] row in room)
            {
                Console.WriteLine(string.Join(string.Empty, row));
            }
        }
    }
}
