namespace _08.TextGravity
{
    using System;
    using System.Security;
    using System.Text;

    class Program
    {
        private static char[][] matrix;

        static void Main(string[] args)
        {
            int lineLength = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();

            int rows = (int)Math.Ceiling((double)text.Length / lineLength);
            int cols = lineLength;
            
            InitializeMatrix(rows, cols, text);
            ReArrangeMatrix();
            PrintResult();
        }

        private static void InitializeMatrix(int rows, int cols, string text)
        {
            matrix = new char[rows][];

            text += new string(' ', (rows * cols - text.Length));

            int index = 0;

            for(int row = 0; row < rows; row++)
            {
                matrix[row] = new char[cols];

                for(int col = 0; col < cols; col++)
                {
                    matrix[row][col] = text[index++];
                }
            }
        }

        private static void ReArrangeMatrix()
        {
            bool isChange = true;

            while (isChange)
            {
                isChange = false;

                for (int row = matrix.Length - 2; row >= 0; row--)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        bool twr = !matrix[row][col].Equals("");
                        var tre = matrix[row + 1][col];
                        if (!matrix[row][col].Equals(' ') && matrix[row + 1][col].Equals(' '))
                        {
                            matrix[row + 1][col] = matrix[row][col];
                            matrix[row][col] = ' ';
                            isChange = true;
                        }
                    }
                }
            }
        }

        private static void PrintResult()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<table>");

            for (int row = 0; row < matrix.Length; row++)
            {
                sb.Append("<tr>");

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    sb.Append($"<td>{SecurityElement.Escape(matrix[row][col].ToString())}</td>");
                }

                sb.Append("</tr>");
            }

            sb.Append("</table>");

            Console.WriteLine(sb.ToString());
        }
    }
}
