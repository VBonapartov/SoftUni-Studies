namespace _02.Monopoly
{
    using System;
    using System.Linq;

    class Program
    {
        private const int PlayerMoney = 50;

        private static char[][] gameField;
        private static int numberOfHotels = 0;

        static void Main(string[] args)
        {
            InitializeGameField();
            PlayGame();
        }

        private static void InitializeGameField()
        {
            int[] fieldDimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = fieldDimensions[0];
            int cols = fieldDimensions[1];

            gameField = new char[rows][];

            for(int row = 0; row < rows; row++)
            {
                gameField[row] = Console.ReadLine().ToCharArray();
            }
        }

        private static void PlayGame()
        {
            int turns = 0;
            int money = PlayerMoney;

            for(int row = 0; row < gameField.Length; row++)
            {
                if(row % 2 == 0)
                {
                    for(int col = 0; col < gameField[row].Length; col++)
                    {
                        ReadCell(row, col, ref money, ref turns);

                        money += 10 * numberOfHotels;
                        turns++;
                    }
                }
                else
                {
                    for (int col = gameField[row].Length - 1; col >= 0; col--)
                    {
                        ReadCell(row, col, ref money, ref turns);

                        money += 10 * numberOfHotels;
                        turns++;
                    }
                }
            }

            Console.WriteLine($"Turns {turns}");
            Console.WriteLine($"Money {money}");
        }

        private static void ReadCell(int row, int col, ref int money, ref int turns)
        {
            char cellValue = gameField[row][col];
            
            switch(cellValue)
            {
                case 'H':                   
                    Console.WriteLine($"Bought a hotel for {money}. Total hotels: {++numberOfHotels}.");
                    money = 0;

                    break;

                case 'J':
                    Console.WriteLine($"Gone to jail at turn {turns}.");
                    turns += 2;
                    money += 2 * 10 * numberOfHotels;

                    break;

                case 'S':
                    int moneySpent = (row + 1) * (col + 1);
                    moneySpent = moneySpent > money ? money : moneySpent;
                    money -= moneySpent;
                    Console.WriteLine($"Spent {moneySpent} money at the shop.");

                    break;

                case 'F':
                    break;
            }
        }
    }
}
