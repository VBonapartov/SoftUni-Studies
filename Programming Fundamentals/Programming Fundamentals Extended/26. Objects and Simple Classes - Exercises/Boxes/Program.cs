using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxes
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static double CalculateDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
    }

    class Box
    {
        public Point UpperLeft { get; set; }
        public Point UpperRight { get; set; }
        public Point BottomLeft { get; set; }
        public Point BottomRight { get; set; }

        public static int CalculatePerimeter(int width, int height)
        {
            return 2 * (width + height);
        }

        public static int CalculateArea(int width, int height)
        {
            return width * height;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = ReadBoxes();
            PrintBoxes(boxes);
        }

        private static List<Box> ReadBoxes()
        {
            List<Box> boxes = new List<Box>();

            string input = string.Empty;
            while (!(input = Console.ReadLine().Trim()).Equals("end"))
            {
                boxes.Add(ReadBox(input));
            }

            return boxes;
        }

        private static Box ReadBox(string input)
        {
            string[] command = input.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);

            string[] upperLeft = command[0].Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
            string[] upperRight = command[1].Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
            string[] bottomLeft = command[2].Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
            string[] bottomRight = command[3].Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);

            Box box = new Box
            {
                UpperLeft = new Point
                {
                    X = Convert.ToInt32(upperLeft[0]),
                    Y = Convert.ToInt32(upperLeft[1])
                },

                UpperRight = new Point
                {
                    X = Convert.ToInt32(upperRight[0]),
                    Y = Convert.ToInt32(upperRight[1])
                },

                BottomLeft = new Point
                {
                    X = Convert.ToInt32(bottomLeft[0]),
                    Y = Convert.ToInt32(bottomLeft[1])
                },

                BottomRight = new Point
                {
                    X = Convert.ToInt32(bottomRight[0]),
                    Y = Convert.ToInt32(bottomRight[1])
                }
            };

            return box;
        }

        private static void PrintBoxes(List<Box> boxes)
        {
            foreach(Box box in boxes)
            {
                int width = (int)Point.CalculateDistance(box.UpperLeft, box.UpperRight);
                int height = (int)Point.CalculateDistance(box.UpperLeft, box.BottomLeft);
                int perimeter = Box.CalculatePerimeter(width, height);
                int area = Box.CalculateArea(width, height);

                Console.WriteLine($"Box: {width}, {height}");
                Console.WriteLine($"Perimeter: {perimeter}");
                Console.WriteLine($"Area: {area}");
            }
        }
    }
}
