namespace _01.BunkerBuster
{
    using System;
    using System.Linq;

    class Program
    {
        private static long[][] field;

        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            InitializeField(rows, cols);
            ExecuteCommands();
            PrintResult();
        }

        private static void InitializeField(int rows, int cols)
        {
            field = new long[rows][];

            for(int row = 0; row < rows; row++)
            {
                field[row] = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            }
        }

        private static void ExecuteCommands()
        {
            string input = string.Empty;

            while(!(input = Console.ReadLine()).Equals("cease fire!"))
            {
                string[] cmdArgs = input.Split(' ');
                int bombRow = int.Parse(cmdArgs[0]);
                int bombCol = int.Parse(cmdArgs[1]);
                int bombPower = Convert.ToChar(cmdArgs[2]);

                ReduceCellsSrength(bombRow, bombCol, bombPower);
            }
        }

        private static void ReduceCellsSrength(int bombRow, int bombCol, int bombPower)
        {
            field[bombRow][bombCol] -= bombPower;
            int halfDamage = (int)Math.Ceiling((double)bombPower / 2);

            // up
            if(bombRow - 1 >= 0)
            {
                field[bombRow - 1][bombCol] -= halfDamage;
            }

            // down
            if (bombRow + 1 < field.Length)
            {
                field[bombRow + 1][bombCol] -= halfDamage;
            }

            // left
            if (bombCol - 1 >= 0)
            {
                field[bombRow][bombCol - 1] -= halfDamage;
            }

            // right
            if (bombCol + 1 < field[bombRow].Length)
            {
                field[bombRow][bombCol + 1] -= halfDamage;
            }

            // left - up diagonal
            if (bombRow - 1 >= 0 && bombCol - 1 >= 0)
            {
                field[bombRow - 1][bombCol - 1] -= halfDamage;
            }

            // right - up diagonal
            if (bombRow - 1 >= 0 && bombCol + 1 < field[bombRow].Length)
            {
                field[bombRow - 1][bombCol + 1] -= halfDamage;
            }

            // right - down diagonal
            if (bombRow + 1 < field.Length && bombCol + 1 < field[bombRow].Length)
            {
                field[bombRow + 1][bombCol + 1] -= halfDamage;
            }

            // right - down diagonal
            if (bombRow + 1 < field.Length && bombCol - 1 >= 0)
            {
                field[bombRow + 1][bombCol - 1] -= halfDamage;
            }
        }

        private static void PrintResult()
        {
            int totalDestroyedCells = 0;

            for(int row = 0; row < field.Length; row++)
            {
                totalDestroyedCells += field[row].Count(i => i <= 0);
            }

            Console.WriteLine($"Destroyed bunkers: {totalDestroyedCells}");
            Console.WriteLine($"Damage done: {((double)totalDestroyedCells / (field.Length * field[0].Length)) * 100:F1} %");
        }
    }
}
