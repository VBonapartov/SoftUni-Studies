namespace _01.PlusRemove
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static char[][] matrix;

        static void Main(string[] args)
        {
            InitializeMatrix();
            List<int[]> removedCells = PlusRemove();
            ReArrangeMatrix(removedCells);
        }

        private static void InitializeMatrix()
        {
            List<string> inputData = new List<string>();

            string input = string.Empty;

            while(!(input = Console.ReadLine()).Equals("END"))
            {
                inputData.Add(input);
            }

            matrix = new char[inputData.Count][];

            for(int i = 0; i < inputData.Count; i++)
            {
                matrix[i] = inputData[i].ToCharArray();
            }
        }

        private static List<int[]> PlusRemove()
        {
            List<int[]> removedCells = new List<int[]>();

            for(int row = 0; row < matrix.Length; row++)
            {
                for(int col = 0; col < matrix[row].Length; col++)
                {
                    if(IsPlusCenter(row, col))
                    {
                        removedCells.Add(new[] { row, col });
                        removedCells.Add(new[] { row + 1, col });
                        removedCells.Add(new[] { row - 1, col });
                        removedCells.Add(new[] { row, col + 1 });
                        removedCells.Add(new[] { row, col - 1 });
                    }
                }
            }

            return removedCells;
        }

        private static bool IsPlusCenter(int row, int col)
        {
            char symbol = Char.ToLower(matrix[row][col]);

            if(row - 1 < 0 || col > matrix[row - 1].Length - 1 ||
               row + 1 > matrix.Length - 1 || col > matrix[row + 1].Length - 1 ||
               col - 1 < 0 || col + 1 > matrix[row].Length - 1)
            {
                return false;
            }

            return Char.ToLower(matrix[row - 1][col]).Equals(symbol) &&
                   Char.ToLower(matrix[row + 1][col]).Equals(symbol) &&
                   Char.ToLower(matrix[row][col - 1]).Equals(symbol) &&
                   Char.ToLower(matrix[row][col + 1]).Equals(symbol);
        }

        private static void ReArrangeMatrix(List<int[]> removedCells)
        {
            char[][] result = new char[matrix.Length][];

            for(int row = 0; row < matrix.Length; row++)
            {
                string line = string.Empty;

                for(int col = 0; col < matrix[row].Length; col++)
                {
                    if(!removedCells.Any(c => c[0] == row && c[1] == col))
                    {
                        line += matrix[row][col];
                    }
                }

                result[row] = new char[line.Length];
                result[row] = line.ToCharArray();
            }

            PrintResult(result);
        }

        private static void PrintResult(char[][] result)
        {
            foreach(char[] line in result)
            {
                Console.WriteLine(string.Join("", line));
            }
        }
    }
}
