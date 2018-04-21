namespace _05._GenericCountMethodString
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Box<string>> strings = GetInputStrings();
            ComparingByValue(strings);
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

        private static void ComparingByValue(List<Box<string>> strings)
        {
            string element = Console.ReadLine();

            int count = Box<string>.CompareByValue(strings, element);
            Console.WriteLine(count);
        }
    }
}
