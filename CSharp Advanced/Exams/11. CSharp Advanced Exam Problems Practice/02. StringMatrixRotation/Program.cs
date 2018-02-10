namespace _02.StringMatrixRotation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static List<string> textMatrix = new List<string>();

        static void Main(string[] args)
        {
            int degrees = GetDegrees();

            ReadInputText();
            RotateMatrix(degrees);
        }

        private static void ReadInputText()
        {
            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("END"))
            {
                textMatrix.Add(input);
            }
        }

        private static int GetDegrees()
        {
            string input = Console.ReadLine();

            input = input.Remove(0, input.IndexOf('(') + 1);
            return int.Parse(input.Substring(0, input.IndexOf(')'))) % 360;
        }

        private static void RotateMatrix(int degrees)
        {
            if (degrees == 0)
            {
                PrintMatrix();
            }
            else if (degrees == 90)
            {
                PrintMatrix90Degrees();
            }
            else if (degrees == 180)
            {
                PrintMatrix180Degrees();
            }
            else if (degrees == 270)
            {
                PrintMatrix270Degrees();
            }
            else
            {
                // invalid input
            }
        }

        private static void PrintMatrix()
        {
            foreach (string text in textMatrix)
            {
                Console.WriteLine(text);
            }
        }

        private static void PrintMatrix90Degrees()
        {
            textMatrix.Reverse();

            int numberOfElements = textMatrix.Count();
            int maxLength = textMatrix.OrderByDescending(s => s.Length).First().Length;

            for (int row = 0; row < maxLength; row++)
            {
                for (int col = 0; col < numberOfElements; col++)
                {
                    if (row < textMatrix[col].Length)
                    {
                        Console.Write(textMatrix[col][row]);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }
        }

        private static void PrintMatrix180Degrees()
        {
            textMatrix.Reverse();

            textMatrix = textMatrix
                                    .Select(s => {
                                                    char[] array = s.ToCharArray();
                                                    Array.Reverse(array);
                                                    return new String(array);
                                                 }
                                            )
                                    .ToList();

            int numberOfElements = textMatrix.Count();
            int maxLength = textMatrix.OrderByDescending(s => s.Length).First().Length;

            for (int row = 0; row < numberOfElements; row++)
            {
                for (int col = 0; col < maxLength; col++)
                {
                    int index = col - (maxLength - textMatrix[row].Length);

                    if (col >= maxLength - textMatrix[row].Length)
                    {
                        Console.Write(textMatrix[row][index]);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }
        }

        private static void PrintMatrix270Degrees()
        {
            textMatrix = textMatrix
                                    .Select(s => {
                                                    char[] array = s.ToCharArray();
                                                    Array.Reverse(array);
                                                    return new String(array);
                                                 }
                                            )
                                    .ToList();

            int numberOfElements = textMatrix.Count();
            int maxLength = textMatrix.OrderByDescending(s => s.Length).First().Length;

            for (int row = 0; row < maxLength; row++)
            {
                for (int col = 0; col < numberOfElements; col++)
                {
                    int index = row - (maxLength - textMatrix[col].Length);

                    if (row >= maxLength - textMatrix[col].Length)
                    {
                        Console.Write(textMatrix[col][index]);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
