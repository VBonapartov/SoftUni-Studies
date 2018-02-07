namespace _09.Crossfire
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static List<List<int>> matrix;

        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine()
                              .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(int.Parse)
                              .ToArray();

            InitializeMatrix(matrixSizes[0], matrixSizes[1]);
            ExecuteCommands();
        }

        private static void InitializeMatrix(int matrixRows, int matrixCols)
        {
            matrix = new List<List<int>>();

            int counter = 1;
            for (int rowIndex = 0; rowIndex < matrixRows; rowIndex++)
            {
                matrix.Add(new List<int>());
                for (int colIndex = 0; colIndex < matrixCols; colIndex++)
                {
                    matrix[rowIndex].Add(counter++);
                }
            }
        }

        private static void ExecuteCommands()
        {
            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("Nuke it from orbit"))
            {
                int[] commandArgs = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                         .Select(int.Parse)
                                         .ToArray();

                DestroyingCells(commandArgs[0], commandArgs[1], commandArgs[2]);
            }

            PrintResult();
        }

        private static void DestroyingCells(int targetCellRow, int targetCellCol, int radius)
        {
            if (targetCellRow >= 0 && targetCellRow < matrix.Count)
            {
                for (int colIndex = Math.Max(0, targetCellCol - radius); colIndex <= Math.Min(targetCellCol + radius, matrix[targetCellRow].Count - 1); colIndex++)
                {
                    matrix[targetCellRow][colIndex] = 0;
                }
            }

            if (targetCellCol >= 0 && targetCellCol < matrix[0].Count)
            {
                for (int rowIndex = Math.Max(0, targetCellRow - radius); rowIndex <= Math.Min(targetCellRow + radius, matrix.Count - 1); rowIndex++)
                {
                    if (targetCellCol < matrix[rowIndex].Count)
                    {
                        matrix[rowIndex][targetCellCol] = 0;
                    }
                }
            }

            FilterMatrix();
        }

        private static void FilterMatrix()
        {
            // Memory: 15.29 MB 
            //for (int rowIndex = matrix.Count - 1; rowIndex >= 0; rowIndex--)
            //{
            //    matrix[rowIndex] = matrix[rowIndex].Where(i => i != 0).ToList();
            //    if (matrix[rowIndex].Count == 0)
            //    {
            //        matrix.RemoveAt(rowIndex);
            //    }
            //}

            // Memory: 10.04 MB
            for (int rowIndex = matrix.Count - 1; rowIndex >= 0; rowIndex--)
            {
                for (int colIndex = matrix[rowIndex].Count - 1; colIndex >= 0; colIndex--)
                {
                    if (matrix[rowIndex][colIndex] == 0)
                    {
                        matrix[rowIndex].RemoveAt(colIndex);
                    }
                }

                if (matrix[rowIndex].Count == 0)
                {
                    matrix.RemoveAt(rowIndex);
                }
            }
        }

        private static void PrintResult()
        {
            foreach (List<int> row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
