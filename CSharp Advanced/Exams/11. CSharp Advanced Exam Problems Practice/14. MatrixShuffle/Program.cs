namespace _14.MatrixShuffle
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        private static char[][] matrix;

        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int rows = matrixSize;
            int cols = matrixSize;

            InitializeMatrix(rows, cols);
            string text = ExtractLetters();
            PrintResult(text);
        }

        private static void InitializeMatrix(int rows, int cols)
        {
            string text = Console.ReadLine();

            matrix = new char[rows][];
            for (int row = 0; row < rows; row++)
                matrix[row] = new char[cols];

            int totalCells = rows * cols;
            text = text.PadRight(totalCells, ' ');

            int leftColumn = 0;
            int rightColumn = cols - 1;
            int upperRow = 0;
            int bottomRow = rows - 1;
            int count = 0;

            do
            {
                for (int i = leftColumn; i <= rightColumn; i++) // filling the upper row
                {
                    matrix[upperRow][i] = text[count++];
                }

                // we go one row down
                upperRow++; 

                for (int i = upperRow; i <= bottomRow; i++) // filling the right column
                {
                    matrix[i][rightColumn] = text[count++];
                }

                // we go to the next column
                rightColumn--; 

                for (int i = rightColumn; i >= leftColumn; i--) // filling bottom row
                {
                    matrix[bottomRow][i] = text[count++];
                }

                // one row up
                bottomRow--;  

                for (int i = bottomRow; i >= upperRow; i--) // filling the leftmost column
                {
                    matrix[i][leftColumn] = text[count++];
                }

                leftColumn++;

            } while (count < totalCells); // and continuing the spiral to the end of the text string
        }

        private static string ExtractLetters()
        {
            StringBuilder sbWhiteSquares = new StringBuilder();
            StringBuilder sbBlackSquares = new StringBuilder();

            for (int row = 0; row < matrix.Length; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix[row].Length; col += 2)
                    {
                        sbWhiteSquares.Append(matrix[row][col]);
                    }

                    for (int col = 1; col < matrix[row].Length; col += 2)
                    {
                        sbBlackSquares.Append(matrix[row][col]);
                    }
                }
                else
                {
                    for (int col = 1; col < matrix[row].Length; col += 2)
                    {
                        sbWhiteSquares.Append(matrix[row][col]);
                    }

                    for (int col = 0; col < matrix[row].Length; col += 2)
                    {
                        sbBlackSquares.Append(matrix[row][col]);
                    }
                }
            }

            sbWhiteSquares.Append(sbBlackSquares);
            return sbWhiteSquares.ToString();
        }

        private static bool IsPalindrome(string str)
        {
            if (str.Length == 1)
            {
                return true;
            }

            int len = str.Length;

            for (int i = 0; i < len / 2; i++)
            {
                if (str[i] != str[len - i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        private static void PrintResult(string text)
        {
            string str = Regex.Replace(text, @"[^a-zA-Z]+", "");

            if(IsPalindrome(str.ToLower()))
            {
                Console.WriteLine($"<div style='background-color:#4FE000'>{text}</div>");
            }
            else
            {
                Console.WriteLine($"<div style='background-color:#E0000F'>{text}</div>");
            }
        }
    }
}
