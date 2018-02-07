namespace _03.CountUppercaseWords
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> isUpper = s => Char.IsUpper(s[0]);

            Console.WriteLine(
                                string.Join(Environment.NewLine,
                                            Console.ReadLine()
                                                        .Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                                                        .Where(s => isUpper(s))
                                           )
                             );
        }
    }
}
