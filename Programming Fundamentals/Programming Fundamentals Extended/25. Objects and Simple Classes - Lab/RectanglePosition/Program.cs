using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectanglePosition
{
    class Rectangle
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int Bottom
        {
            get
            {
                return Top + Height;
            }
        }

        public int Right
        {
            get
            {
                return Left + Width;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Rectangle> rectangles = ReadRectangles();

            bool isInside = IsInside(rectangles[0], rectangles[1]);
            Console.WriteLine(isInside ? "Inside" : "Not inside");
        }

        static private List<Rectangle> ReadRectangles()
        {
            List<Rectangle> rectangles = new List<Rectangle>();
            for(int i = 0; i < 2; i++)
                rectangles.Add(ReadRectangle());

            return rectangles;
        }

        static private Rectangle ReadRectangle()
        {
            int[] inputLine = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Rectangle rec = new Rectangle();
            rec.Left = inputLine[0];
            rec.Top = inputLine[1];
            rec.Width = inputLine[2];
            rec.Height = inputLine[3];

            return rec;
        }

        static private bool IsInside(Rectangle rec1, Rectangle rec2)
        {
            return rec1.Left >= rec2.Left && rec1.Top >= rec2.Top &&
                   rec1.Right <= rec2.Right && rec1.Bottom <= rec2.Bottom;
        }
    }
}
