namespace _15.DrawingTool
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            string figureShape = Console.ReadLine();

            Square sq = null;

            if (figureShape.Equals("Square"))
            {
                int squareSide = int.Parse(Console.ReadLine());
                sq = new Square(squareSide);
            }
            else if (figureShape.Equals("Rectangle"))
            {
                int length = int.Parse(Console.ReadLine());
                int width = int.Parse(Console.ReadLine());
                sq = new Rectangle(length, width);
            }

            CorDraw cd = new CorDraw(sq);
            Console.WriteLine(cd.Figure.Draw());
        }
    }
}