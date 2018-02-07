namespace _01.ActionPrint
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = s => Console.WriteLine(s);
            Console.ReadLine().Split(' ').ToList().ForEach(s => print(s));
        }
    }
}
