namespace _02._BlackBoxInteger
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            BlackBoxIntegerTests test = new BlackBoxIntegerTests();
            Console.WriteLine(test.Run());
        }
    }
}
