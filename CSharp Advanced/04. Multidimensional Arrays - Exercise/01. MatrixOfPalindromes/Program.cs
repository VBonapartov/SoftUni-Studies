namespace _01.MatrixOfPalindromes
{
    using System;
    using System.Linq;

    class Program
    {
        private static char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        static void Main(string[] args)
        {
            int[] inputArgs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int rows = inputArgs[0];
            int cols = inputArgs[1];

            string[][] palindromes = new string[rows][];

            for (int row = 0; row < rows; row++)
            {
                palindromes[row] = new string[cols];

                for (int col = 0; col < cols; col++)
                {
                    palindromes[row][col] = string.Format($"{alphabet[row]}{alphabet[row + col]}{alphabet[row]}");
                }
            }

            foreach (string[] row in palindromes)
                Console.WriteLine(string.Join(" ", row));
        }
    }
}
