namespace _01._GenericBoxOfString
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Box<string>> strings = GetInputStrings();
            PrintResult(strings);
        }

        private static List<Box<string>> GetInputStrings()
        {
            List<Box<string>> strings = new List<Box<string>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Box<string> box = new Box<string>(Console.ReadLine());
                strings.Add(box);
            }

            return strings;
        }

        private static void PrintResult(List<Box<string>> strings)
        {
            foreach (Box<string> box in strings)
            {
                Console.WriteLine(box);
            }
        }
    }
}
