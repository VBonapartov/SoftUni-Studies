namespace _07.PredicateForNames
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());

            Predicate<string> filter = s => s.Length <= nameLength;
            Console.WriteLine(
                                string.Join(Environment.NewLine,
                                            Console.ReadLine().Split(' ').Where(s => filter(s))
                                            )
                              );
        }
    }
}
