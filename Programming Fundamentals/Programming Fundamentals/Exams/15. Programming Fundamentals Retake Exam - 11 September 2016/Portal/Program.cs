using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[][] matrix = new char[matrixSize][];
            for(int i = 0; i < matrixSize; i++)
            {
                char[] actualMatrix = Console.ReadLine().ToCharArray();
                matrix[i] = actualMatrix;
            }

            (int row, int pos) currentPosition = GetStartPosition(matrix);
            List<ValueTuple<int, int>> exitPositions = GetExitPositions(matrix);

            bool isFindExit = false;
            int numberOfTurns = 0;
            char[] commands = Console.ReadLine().ToCharArray();
            for(int i = 0; i < commands.Length; i++)
            {
                char command = commands[i];
                switch(command)
                {
                    case 'U':
                        currentPosition = UpInMatrix(matrix, currentPosition);
                        break;

                    case 'D':
                        currentPosition = DownInMatrix(matrix, currentPosition);
                        break;

                    case 'L':
                        currentPosition = LeftInMatrix(matrix, currentPosition);
                        break;

                    case 'R':
                        currentPosition = RightInMatrix(matrix, currentPosition);
                        break;
                }
                numberOfTurns++;

                if (exitPositions.Contains(currentPosition))
                {
                    isFindExit = true;
                    break;
                }
            }

            if(isFindExit)
            {
                Console.WriteLine($"Experiment successful. {numberOfTurns} turns required.");
            }
            else
            {
                Console.WriteLine($"Robot stuck at {currentPosition.row} {currentPosition.pos}. Experiment failed.");
            }
        }

        private static (int row, int pos) GetStartPosition(char[][] matrix)
        {
            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int pos = 0; pos < matrix[row].Length; pos++)
                {
                    if (matrix[row][pos].Equals('S'))
                        return (row, pos);
                }
            }

            return (0, 0);
        }

        private static List<ValueTuple<int, int>> GetExitPositions(char[][] matrix)
        {
            List<ValueTuple<int, int>> exitPositions = new List<ValueTuple<int, int>>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int pos = 0; pos < matrix[row].Length; pos++)
                {
                    if (matrix[row][pos].Equals('E'))
                        exitPositions.Add((row, pos));
                }
            }

            return exitPositions;
        }

        private static (int row, int pos) UpInMatrix(char[][] matrix, ValueTuple<int, int> currentPosition)
        {
            // Item 1 - row; Item 2 - pos
            int startRowPos = currentPosition.Item1;
            while (true)
            {
                if (--currentPosition.Item1 < 0)
                { 
                    currentPosition.Item1 = matrix.GetLength(0) - 1;
                }

                if(currentPosition.Item2 < matrix[currentPosition.Item1].Length)
                    return (currentPosition.Item1, currentPosition.Item2);

                if(currentPosition.Item1 == startRowPos)
                    return (currentPosition.Item1, currentPosition.Item2);
            }
        }

        private static (int row, int pos) DownInMatrix(char[][] matrix, ValueTuple<int, int> currentPosition)
        {
            // Item 1 - row; Item 2 - pos
            int startRowPos = currentPosition.Item1;
            while (true)
            {
                if (++currentPosition.Item1 > matrix.GetLength(0) - 1)
                {
                    currentPosition.Item1 = 0;
                }

                if (currentPosition.Item2 < matrix[currentPosition.Item1].Length)
                    return (currentPosition.Item1, currentPosition.Item2);

                if (currentPosition.Item1 == startRowPos)
                    return (currentPosition.Item1, currentPosition.Item2);
            }
        }

        private static (int row, int pos) LeftInMatrix(char[][] matrix, ValueTuple<int, int> currentPosition)
        {
            // Item 1 - row; Item 2 - pos
            if (--currentPosition.Item2 < 0)
            {
                currentPosition.Item2 = matrix[currentPosition.Item1].Length - 1;
            }

            return (currentPosition.Item1, currentPosition.Item2);
        }

        private static (int row, int pos) RightInMatrix(char[][] matrix, ValueTuple<int, int> currentPosition)
        {
            // Item 1 - row; Item 2 - pos
            if (++currentPosition.Item2 > matrix[currentPosition.Item1].Length - 1)
            {
                currentPosition.Item2 = 0;
            }

            return (currentPosition.Item1, currentPosition.Item2);
        }
    }
}
