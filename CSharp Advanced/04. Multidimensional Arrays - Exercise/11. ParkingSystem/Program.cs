namespace _11.ParkingSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static HashSet<int[]> usedCells = new HashSet<int[]>();
        private static int parkingLotRows;
        private static int parkingLotCols;

        static void Main(string[] args)
        {
            int[] parkingLotDim = Console.ReadLine()
                                        .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();

            parkingLotRows = parkingLotDim[0];
            parkingLotCols = parkingLotDim[1];

            ExecuteCommands();
        }

        private static void ExecuteCommands()
        {
            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("stop"))
            {
                string[] commandArgs = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                int entryRow = int.Parse(commandArgs[0]);
                int desiredRow = int.Parse(commandArgs[1]);
                int desiredCol = int.Parse(commandArgs[2]);

                int[] desiredRowCol = new int[2] { desiredRow, desiredCol };

                bool isCarParked = IsCarParked(desiredRowCol);
                if (isCarParked)
                {
                    usedCells.Add(desiredRowCol);
                }

                int distance = Math.Abs((entryRow + 1) - (desiredRowCol[0] + 1)) + desiredRowCol[1] + 1;
                PrintDistance(isCarParked, desiredRow, distance);
            }
        }

        private static bool IsCarParked(int[] desiredRowCol)
        {
            // Try park
            if (usedCells
                    .Where(arr => arr[0] == desiredRowCol[0] && arr[1] == desiredRowCol[1])
                    .FirstOrDefault() == null)
            {
                return true;
            }

            int testCol = 1;

            // Loop around the row to find free cell to park
            while (true)
            {
                int leftCol = desiredRowCol[1] - testCol;
                int rightCol = desiredRowCol[1] + testCol;

                if (leftCol <= 0 && rightCol >= parkingLotCols)
                {
                    break;
                }

                // Try park left
                if (leftCol > 0 &&
                    usedCells.Where(arr => arr[0] == desiredRowCol[0] && arr[1] == leftCol)
                        .FirstOrDefault() == null)
                {
                    desiredRowCol[1] = leftCol;
                    return true;
                }

                // Try park right
                if (rightCol < parkingLotCols &&
                    usedCells.Where(arr => arr[0] == desiredRowCol[0] && arr[1] == rightCol)
                        .FirstOrDefault() == null)
                {
                    desiredRowCol[1] = rightCol;
                    return true;
                }

                testCol++;
            }

            return false;
        }

        private static void PrintDistance(bool isCarParked, int desiredRow, int distance)
        {
            Console.WriteLine(isCarParked ? $"{distance}" : $"Row {desiredRow} full");
        }
    }
}
