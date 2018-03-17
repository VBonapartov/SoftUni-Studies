namespace _02._PointInRectangle
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Rectangle rect = new Rectangle(Console.ReadLine());
            ExecuteCommands(rect);
        }

        private static void ExecuteCommands(Rectangle rect)
        {
            int numberOfPoints = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPoints; i++)
            {
                Point point = new Point(Console.ReadLine);
                IsRectangleContainsPoint(rect, point);
            }
        }

        private static void IsRectangleContainsPoint(Rectangle rect, Point point)
        {
            Console.WriteLine(rect.Contains(point));
        }
    }
}
