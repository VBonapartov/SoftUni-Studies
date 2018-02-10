namespace _16.Parachute
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static char[][] matrix;

        static void Main(string[] args)
        {
            InitializeMatrix();
            MovementOfTheJumper();
        }

        private static void InitializeMatrix()
        {
            List<string> inputData = new List<string>();

            string input = string.Empty;

            while (!(input = Console.ReadLine()).Equals("END"))
            {
                inputData.Add(input);
            }

            matrix = new char[inputData.Count][];

            for (int i = 0; i < inputData.Count; i++)
            {
                matrix[i] = inputData[i].ToCharArray();
            }
        }

        private static void MovementOfTheJumper()
        {
            int[] jumperPos = GetCurrentJumperPos();

            for (int row = jumperPos[0] + 1; row < matrix.Length; row++)
            {   
                int moveLeft = 0;
                int moveRight = 0;

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if(matrix[row][col].Equals('<'))
                    {
                        moveLeft++;
                    }
                    else if (matrix[row][col].Equals('>'))
                    {
                        moveRight++;
                    }
                }

                if(!MoveJumper(row, moveLeft, moveRight, jumperPos))
                {
                    break;
                }
            }
        }

        private static int[] GetCurrentJumperPos()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col].Equals('o'))
                    {
                        return new[] { row, col };
                    }
                }
            }

            return null;
        }

        private static bool MoveJumper(int currentRow, int moveLeft, int moveRight, int[] jumperPos)
        {
            int step = moveLeft - moveRight;
            jumperPos[1] = (step > 0) ? jumperPos[1] - step : jumperPos[1] + Math.Abs(step);

            int jumperColPos = jumperPos[1];

            if (matrix[currentRow][jumperColPos].Equals('/') || matrix[currentRow][jumperColPos].Equals('\\'))
            {
                PrintResult(currentRow, jumperColPos, "Got smacked on the rock like a dog!");
                return false;
            }

            if(matrix[currentRow][jumperColPos].Equals('_'))
            {
                PrintResult(currentRow, jumperColPos, "Landed on the ground like a boss!");
                return false;
            }

            if (matrix[currentRow][jumperColPos].Equals('~'))
            {
                PrintResult(currentRow, jumperColPos, "Drowned in the water like a cat!");
                return false;
            }

            return true;
        }

        private static void PrintResult(int currentRow, int jumperColPos, string msg)
        {
            Console.WriteLine(msg);
            Console.WriteLine($"{currentRow} {jumperColPos}");
        }
    }
}
