using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrifonsQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            long healthPoints = long.Parse(Console.ReadLine());
            int[] mapDimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = mapDimensions[0];
            int cols = mapDimensions[1];

            char[,] map = new char[rows, cols];
            for(int row = 0; row < rows; row++)
            {
                string mapInfo = Console.ReadLine();
                for(int col = 0; col < mapInfo.Length; col++)
                {
                    map[row, col] = mapInfo[col];
                }
            }

            int numberOfTurns = 0;
            for(int col = 0; col < cols; col++)
            {
                int currentRow = (col % 2 == 0) ? 0 : rows - 1; 

                while(currentRow <= rows - 1 && currentRow >= 0)
                {                    
                    if (map[currentRow, col].Equals('F'))
                    {
                        healthPoints -= numberOfTurns / 2;
                    }
                    else if (map[currentRow, col].Equals('H'))
                    {
                        healthPoints += numberOfTurns / 3;
                    }
                    else if (map[currentRow, col].Equals('T'))
                    {
                        numberOfTurns += 2;
                    }
                    else if (map[currentRow, col].Equals('E'))
                    {
                        //
                    }

                    if (healthPoints <= 0)
                    {
                        Console.WriteLine($"Died at: [{currentRow}, {col}]");
                        break;
                    }

                    currentRow = (col % 2 == 0) ? currentRow + 1 : currentRow - 1;
                    numberOfTurns++;
                }

                if (healthPoints <= 0)
                    break;
            }

            if (healthPoints > 0)
            {
                Console.WriteLine($"Quest completed!");
                Console.WriteLine($"Health: {healthPoints}");
                Console.WriteLine($"Turns: {numberOfTurns}");
            }
        }
    }
}
