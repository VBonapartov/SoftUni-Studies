using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            List<List<int>> matrix = new List<List<int>>();
            for(int row = 0; row < rows; row++)
            {                
                matrix.Add(Console.ReadLine().Split(' ').Select(int.Parse).ToList());
            }

            string input = string.Empty;
            while(!(input = Console.ReadLine()).Equals("end"))
            {
                string[] command = input.Split(' ');

                switch(command[0])
                {
                    case "remove":
                        Remove(matrix, command[1], command[2], Convert.ToInt32(command[3]));
                        break;

                    case "swap":
                        Swap(matrix, Convert.ToInt32(command[1]), Convert.ToInt32(command[2]));
                        break;

                    case "insert":
                        Insert(matrix, Convert.ToInt32(command[1]), Convert.ToInt32(command[2]));
                        break;
                }
            }

            PrintMatrix(matrix);
        }

        private static void Remove(List<List<int>> matrix, string type, string rowOrCol, int index)
        {
            switch(type)
            {
                case "positive":
                    RemoveAllPositive(matrix, rowOrCol, index);
                    break;

                case "negative":
                    RemoveAllNegative(matrix, rowOrCol, index);
                    break;

                case "odd":
                    RemoveAllOdd(matrix, rowOrCol, index);
                    break;

                case "even":
                    RemoveAllEven(matrix, rowOrCol, index);
                    break;
            }
        }

        private static void RemoveAllOdd(List<List<int>> matrix, string rowOrCol, int index)
        {
            switch (rowOrCol)
            {
                case "row":
                    matrix[index] = matrix[index].Where(i => i % 2 == 0).ToList();
                    break;

                case "col":

                    for(int row = 0; row < matrix.Count; row++)
                    {
                        if(matrix[row].Count > index && matrix[row][index] % 2 != 0)
                        {
                            matrix[row].RemoveAt(index);
                        }
                    }

                    break;
            }
        }

        private static void RemoveAllEven(List<List<int>> matrix, string rowOrCol, int index)
        {
            switch (rowOrCol)
            {
                case "row":
                    matrix[index] = matrix[index].Where(i => i % 2 != 0).ToList();
                    break;

                case "col":

                    for (int row = 0; row < matrix.Count; row++)
                    {
                        if (matrix[row].Count > index && matrix[row][index] % 2 == 0)
                        {
                            matrix[row].RemoveAt(index);
                        }
                    }

                    break;
            }
        }

        private static void RemoveAllPositive(List<List<int>> matrix, string rowOrCol, int index)
        {
            switch (rowOrCol)
            {
                case "row":
                    matrix[index] = matrix[index].Where(i => i < 0).ToList();
                    break;

                case "col":

                    for (int row = 0; row < matrix.Count; row++)
                    {
                        if (matrix[row].Count > index && matrix[row][index] >= 0)
                        {
                            matrix[row].RemoveAt(index);
                        }
                    }

                    break;
            }
        }

        private static void RemoveAllNegative(List<List<int>> matrix, string rowOrCol, int index)
        {
            switch (rowOrCol)
            {
                case "row":
                    matrix[index] = matrix[index].Where(i => i >= 0).ToList();
                    break;

                case "col":

                    for (int row = 0; row < matrix.Count; row++)
                    {
                        if (matrix[row].Count > index && matrix[row][index] < 0)
                        {
                            matrix[row].RemoveAt(index);
                        }
                    }

                    break;
            }
        }

        private static void Insert(List<List<int>> matrix, int row, int element)
        {
            matrix[row].Insert(0, element);
        }

        private static void Swap(List<List<int>> matrix, int firstRow, int secondRow)
        {
            List<int> temp = matrix[firstRow];
            matrix[firstRow] = matrix[secondRow];
            matrix[secondRow] = temp;
        }

        private static void PrintMatrix(List<List<int>> matrix)
        {
            foreach(List<int> row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
