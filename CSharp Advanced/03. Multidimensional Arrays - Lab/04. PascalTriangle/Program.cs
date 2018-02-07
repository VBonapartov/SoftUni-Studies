namespace _04.PascalTriangle
{
    using System;

    class Program
    {
        private static long[][] triangle;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            InitializeTriangle(rows);
            CreateTriangle(rows);
            PrintTriangle();
        }

        private static void InitializeTriangle(int rows)
        {
            triangle = new long[rows][];

            for (int i = 1; i <= rows; i++)
            {
                triangle[i - 1] = new long[i];
                triangle[i - 1][0] = 1;
            }
        }

        private static void CreateTriangle(int rows)
        {
            triangle[0][0] = 1;

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col <= row - 1; col++)
                {
                    triangle[row][col] = triangle[row - 1][col - 1] + triangle[row - 1][col];
                }

                triangle[row][row] = 1;
            }
        }

        private static void PrintTriangle()
        {
            foreach (long[] row in triangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
