namespace _04._Froggy
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            int[] stones = Console.ReadLine()
                                         .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                         .Select(int.Parse)
                                         .ToArray();

            Lake<int> lake = new Lake<int>(stones);
            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
