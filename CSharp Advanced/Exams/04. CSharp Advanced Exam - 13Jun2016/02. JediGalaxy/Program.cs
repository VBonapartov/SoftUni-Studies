namespace _02.JediGalaxy
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = CreateMatrix();
            long allStarsSum = CollectStars(matrix);

            Console.WriteLine(allStarsSum);
        }

        private static int[][] CreateMatrix()
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            int[][] matrix = new int[rows][];

            int value = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[cols];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = value++;
                }
            }

            return matrix;
        }

        private static long CollectStars(int[][] matrix)
        {
            long allStarsSum = 0;

            string input = string.Empty;

            while(!(input = Console.ReadLine()).Equals("Let the Force be with you"))
            {
                int[] ivoStartRowAndCol = input.Split(' ').Select(int.Parse).ToArray();
                int ivoRow = ivoStartRowAndCol[0];
                int ivoCol = ivoStartRowAndCol[1];

                int[] evilStartRowAndCol = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int evilRow = evilStartRowAndCol[0];
                int evilCol = evilStartRowAndCol[1];

                EvilPower(matrix, evilRow, evilCol);
                allStarsSum += IvoCollectStars(matrix, ivoRow, ivoCol);
            }

            return allStarsSum;
        }

        private static void EvilPower(int[][] matrix, int evilRow, int evilCol)
        {
            int matrixColumns = matrix[0].Length;

            if (evilCol > matrixColumns - 1)
            {
                evilRow = evilRow - (evilCol - (matrixColumns - 1));
                evilCol = matrixColumns - 1;
            }

            while (evilRow < matrix.Length && evilRow >= 0 && evilCol >= 0)
            {
                matrix[evilRow][evilCol] = 0;

                evilRow--;
                evilCol--;
            }
        }

        private static long IvoCollectStars(int[][] matrix, int ivoRow, int ivoCol)
        {
            int matrixColumns = matrix[0].Length;

            long stars = 0L;

            while (ivoRow >= 0 && ivoCol < matrixColumns)
            {
                if (IsCellInMatrix(matrix, ivoRow, ivoCol))
                {
                    stars += matrix[ivoRow][ivoCol];
                }

                ivoRow--;
                ivoCol++;
            }

            return stars;
        }

        private static bool IsCellInMatrix(int[][] matrix, int row, int col)
        {
            return row >= 0 && col >= 0 &&
                   row < matrix.Length && col < matrix[row].Length;
        }
    }
}
