namespace _21.ITVillage
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        private const int GameBoardSize = 4;
        
        private static char[][] gameBoard;
        private static int TotalNumberOfInns;
        private static int coins = 50;

        static void Main(string[] args)
        {
            InitializeGameBoard();
            PlayGame();
        }

        private static void InitializeGameBoard()
        {
            string[] cmdArgs = Console.ReadLine().Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries);

            gameBoard = new char[GameBoardSize][];

            for(int row = 0; row < GameBoardSize; row++)
            {
                gameBoard[row] = new char[GameBoardSize];
                gameBoard[row] = Regex.Replace(cmdArgs[row], @"\s+", "").ToCharArray();

                TotalNumberOfInns += gameBoard[row].Where(c => c.Equals('I')).Count();
            }
        }

        private static void PlayGame()
        {
            int[] position = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            position[0]--;
            position[1]--;

            int[] diceNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int numberOfInns = 0;
            int missMove = 0;

            for (int currentMove = 0; currentMove < diceNumbers.Length; currentMove++)
            {
                int moveStep = diceNumbers[currentMove];

                if(missMove > 0)
                {
                    missMove--;
                    continue;
                }

                coins += numberOfInns * 20;
                MoveToNexPosition(position, moveStep);

                if(!ReadCellContent(position, ref numberOfInns, out missMove))
                {
                    break;
                }

                if(IsGameFinished(numberOfInns, diceNumbers.Count(), currentMove))
                {
                    break;
                }
            }
        }

        private static void MoveToNexPosition(int[] position, int move)
        {
            while (move > 0)
            {
                if (position[0] == 0)
                {
                    position[1]++;
                    if (position[1] > GameBoardSize - 1)
                    {
                        position[0]++;
                        position[1] = GameBoardSize - 1;
                    }
                }
                else if (position[0] == GameBoardSize - 1)
                {
                    position[1]--;
                    if (position[1] < 0)
                    {
                        position[0]--;
                        position[1] = 0;
                    }
                }
                else if (position[1] == 0)
                {
                    position[0]--;
                }
                else
                {
                    position[0]++;
                }

                move--;
            }
        }

        private static bool ReadCellContent(int[] position, ref int numberOfInns, out int missMove)
        {
            missMove = 0;

            int row = position[0];
            int col = position[1];

            char cellValue = gameBoard[row][col];

            switch(cellValue)
            {
                case 'P':
                    coins -= 5;
                    break;

                case 'I':
                    if(coins > 100)
                    {
                        coins -= 100;
                        numberOfInns++;
                    }
                    else
                    {
                        coins -= 10;
                    }
                    break;

                case 'F':
                    coins += 20;
                    break;

                case 'S':
                    missMove = 2;
                    break;

                case 'V':
                    coins *= 10;
                    break;

                case 'N':
                    Console.WriteLine("<p>You won! Nakov's force was with you!<p>");
                    return false;
            }

            return true;
        }

        private static bool IsGameFinished(int numberOfInns, int totalMoves, int currentMove)
        {
            if (coins < 0)
            {
                Console.WriteLine("<p>You lost! You ran out of money!<p>");
                return true;
            }

            if (numberOfInns == TotalNumberOfInns)
            {
                Console.WriteLine($"<p>You won! You own the village now! You have {coins} coins!<p>");
                return true;
            }

            if (currentMove + 1 == totalMoves)
            {
                Console.WriteLine($"<p>You lost! No more moves! You have {coins} coins!<p>");
                return true;
            }

            return false;
        }
    }
}
