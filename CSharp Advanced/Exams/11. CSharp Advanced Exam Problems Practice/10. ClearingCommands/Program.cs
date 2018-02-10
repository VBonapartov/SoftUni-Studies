namespace _10.ClearingCommands
{
    using System;
    using System.Collections.Generic;
    using System.Security;
    using System.Text;

    class Program
    {
        private static char[][] matrix;

        static void Main(string[] args)
        {
            InitializeMatrix();
            RemoveGarbage();
            PrintMatrix();
        }

        private static void InitializeMatrix()
        {
            List<string> inputData = new List<string>();

            string input = string.Empty;

            while (!(input = Console.ReadLine()).Equals("END"))
            {
                inputData.Add(input.Trim());
            }

            matrix = new char[inputData.Count][];

            for (int i = 0; i < inputData.Count; i++)
            {
                matrix[i] = inputData[i].ToCharArray();
            }
        }

        private static void RemoveGarbage()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for(int col = 0; col < matrix[row].Length; col++)
                {
                    switch(matrix[row][col])
                    {
                        case '>':
                            Right(row, col + 1);
                            break;

                        case '<':
                            Left(row, col - 1);
                            break;

                        case '^':
                            Up(row - 1, col);
                            break;

                        case 'v':
                            Down(row + 1, col);
                            break;
                    }
                }
            }
        }

        private static void Right(int row, int col)
        {
            for(int currentCol = col; currentCol < matrix[row].Length; currentCol++)
            {
                if(!matrix[row][currentCol].Equals('<') && 
                    !matrix[row][currentCol].Equals('>') &&
                    !matrix[row][currentCol].Equals('^') &&
                    !matrix[row][currentCol].Equals('v'))
                {
                    matrix[row][currentCol] = ' ';
                }
                else
                {
                    break;
                }
            }
        }

        private static void Left(int row, int col)
        {
            for (int currentCol = col; currentCol >= 0; currentCol--)
            {
                if (!matrix[row][currentCol].Equals('<') &&
                    !matrix[row][currentCol].Equals('>') &&
                    !matrix[row][currentCol].Equals('^') &&
                    !matrix[row][currentCol].Equals('v'))
                {
                    matrix[row][currentCol] = ' ';
                }
                else
                {
                    break;
                }
            }
        }

        private static void Up(int row, int col)
        {
            for (int currentRow = row; currentRow >= 0; currentRow--)
            {
                if (!matrix[currentRow][col].Equals('<') &&
                    !matrix[currentRow][col].Equals('>') &&
                    !matrix[currentRow][col].Equals('^') &&
                    !matrix[currentRow][col].Equals('v'))
                {
                    matrix[currentRow][col] = ' ';
                }
                else
                {
                    break;
                }
            }
        }

        private static void Down(int row, int col)
        {
            for (int currentRow = row; currentRow < matrix.Length; currentRow++)
            {
                if (!matrix[currentRow][col].Equals('<') &&
                    !matrix[currentRow][col].Equals('>') &&
                    !matrix[currentRow][col].Equals('^') &&
                    !matrix[currentRow][col].Equals('v'))
                {
                    matrix[currentRow][col] = ' ';
                }
                else
                {
                    break;
                }
            }
        }

        private static void PrintMatrix()
        {
            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < matrix.Length; row++)
            {
                sb.Append("<p>");

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    sb.Append(SecurityElement.Escape(matrix[row][col].ToString()));
                }

                sb.AppendLine("</p>");
            }

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
