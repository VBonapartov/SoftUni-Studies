namespace _09.RectangleIntersection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string[] inputArgs = Console.ReadLine().Split(' ');

            int numberOfRectangles = int.Parse(inputArgs[0]);
            int numberOfIntersectionChecks = int.Parse(inputArgs[1]);

            List<Rectangle> rectangles = GetRectangles(numberOfRectangles);
            CheckIntersections(rectangles, numberOfIntersectionChecks);
        }

        private static List<Rectangle> GetRectangles(int numberOfRectangles)
        {
            List<Rectangle> rectangles = new List<Rectangle>();

            for (int i = 0; i < numberOfRectangles; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ');
                string id = cmdArgs[0];
                double width = double.Parse(cmdArgs[1]);
                double height = double.Parse(cmdArgs[2]);
                double coordinateX = double.Parse(cmdArgs[3]);
                double coordinateY = double.Parse(cmdArgs[4]);

                rectangles.Add(new Rectangle(id, width, height, coordinateX, coordinateY));
            }

            return rectangles;
        }

        private static void CheckIntersections(List<Rectangle> rectangles, int numberOfIntersectionChecks)
        {
            for (int i = 0; i < numberOfIntersectionChecks; i++)
            {
                string[] pairIDs = Console.ReadLine().Split(' ');

                Rectangle firstRect = rectangles.Where(r => r.ID.Equals(pairIDs[0])).FirstOrDefault();
                Rectangle secondRect = rectangles.Where(r => r.ID.Equals(pairIDs[1])).FirstOrDefault();

                Console.WriteLine((firstRect.CheckForIntersection(secondRect)) ? "true" : "false");
            }
        }
    }
}