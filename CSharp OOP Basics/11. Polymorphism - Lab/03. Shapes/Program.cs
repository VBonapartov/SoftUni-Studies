namespace _03._Shapes
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Circle circle = new Circle(5);

            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.Draw());
        }
    }
}
