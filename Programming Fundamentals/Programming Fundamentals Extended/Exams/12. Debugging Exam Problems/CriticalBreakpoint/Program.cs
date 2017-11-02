using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CriticalBreakpoint
{
    class Point
    {
        public long X { get; set; }
        public long Y { get; set; }
    }

    class Line
    {
        public Point FirstPoint { get; set; }
        public Point SecondPoint { get; set; }

        public long GetCriticalRatio()
        {
            return Math.Abs((this.SecondPoint.X + this.SecondPoint.Y) - (this.FirstPoint.X + this.FirstPoint.Y));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Line> lines = ReadLines();

            BigInteger criticalBreakpoint = 0;
            bool isFindCriticalBreakpoint = FindCriticalBreakpoint(lines, out criticalBreakpoint);
            if(isFindCriticalBreakpoint)
            {
                foreach(Line line in lines)
                {
                    Console.WriteLine($"Line: [{line.FirstPoint.X}, {line.FirstPoint.Y}, {line.SecondPoint.X}, {line.SecondPoint.Y}]");
                }

                Console.WriteLine($"Critical Breakpoint: {criticalBreakpoint}");
            }
            else
            {
                Console.WriteLine("Critical breakpoint does not exist.");
            }

        }

        private static List<Line> ReadLines()
        {
            List<Line> lines = new List<Line>();

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("Break it."))
            {
                int[] coordinates = input.Split(' ').Select(int.Parse).ToArray();

                Line line = new Line
                {
                    FirstPoint = new Point
                    {
                        X = coordinates[0],
                        Y = coordinates[1]
                    },
                    SecondPoint = new Point
                    {
                        X = coordinates[2],
                        Y = coordinates[3]
                    }
                };

                lines.Add(line);
            }

            return lines;
        }

        private static bool FindCriticalBreakpoint(List<Line> lines, out BigInteger criticalBreakpoint)
        {
            criticalBreakpoint = 0;

            List<long> criticalRatios = lines.Select(l => l.GetCriticalRatio()).ToList();

            bool isFindCriticalBreakpoint = false;
            if (criticalRatios.All(r => r == 0))
            {
                isFindCriticalBreakpoint = true;
            }
            else
            {
                isFindCriticalBreakpoint = criticalRatios
                                                .Where(r => r > 0)
                                                .Distinct()
                                                .Count() == 1;
            }

            if (isFindCriticalBreakpoint)
            {
                criticalBreakpoint = BigInteger.Pow(criticalRatios.Distinct().Where(r => r > 0).First(), lines.Count()) % lines.Count();
            }

            return isFindCriticalBreakpoint;
        }
    }
}
