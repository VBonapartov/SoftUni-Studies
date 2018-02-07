namespace _03._2x2SquaresInMatrix
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine()
                                          .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(int.Parse)
                                          .ToArray();

            int rows = matrixSizes[0];
            int cols = matrixSizes[1];

            string[][] matrix = new string[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                                          .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                          .ToArray();
            }

            int countSquaresOfEqualChars = 0;
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (matrix[row][col].Equals(matrix[row][col + 1]) &&
                       matrix[row][col].Equals(matrix[row + 1][col]) &&
                       matrix[row][col].Equals(matrix[row + 1][col + 1]))
                    {
                        countSquaresOfEqualChars++;
                    }
                }
            }

            Console.WriteLine(countSquaresOfEqualChars);
        }
    }
}
