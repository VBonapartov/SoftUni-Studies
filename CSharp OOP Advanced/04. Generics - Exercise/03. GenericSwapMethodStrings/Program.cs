namespace _03._GenericSwapMethodStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Box<string>> strings = GetInputStrings();
            SwapAndPrintResult(strings);
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

        private static void SwapAndPrintResult(List<Box<string>> strings)
        {
            int[] indecies = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Box<string>.Swap(strings, indecies[0], indecies[1]);

            foreach (Box<string> box in strings)
            {
                Console.WriteLine(box);
            }
        }
    }
}
