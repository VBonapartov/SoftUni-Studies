namespace _03._Ferrari
{
    using System;

    public class Program
    {
        private const string Model = "488-Spider";

        public static void Main(string[] args)
        {
            string driver = Console.ReadLine();

            ICar car = new Ferrari(driver, Model);
            Console.WriteLine(car);
        }
    }
}
