namespace _13.TriFunction
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(' ').ToArray();

            Func<string, int, bool> isEqualOrLarger = IsEqualOrLarger();
            Func<string[], int, Func<string, int, bool>, string> firstName =
                (arr, num, func) => arr.FirstOrDefault(str => func(str, num));

            string name = firstName(names, number, isEqualOrLarger);
            Console.WriteLine(name);
        }

        private static Func<string, int, bool> IsEqualOrLarger()
        {
            return (s, i) =>
            {
                int charSum = 0;
                foreach (char ch in s)
                    charSum += ch;

                return (charSum >= i);
            };
        }
    }
}
