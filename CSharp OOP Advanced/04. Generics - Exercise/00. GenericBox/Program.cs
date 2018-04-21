namespace _00._GenericBox
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Box<string> box = new Box<string>(input);

            Console.WriteLine(box);
        }
    }
}
