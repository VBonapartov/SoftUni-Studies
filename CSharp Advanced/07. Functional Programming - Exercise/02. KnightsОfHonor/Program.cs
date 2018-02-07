namespace _02.KnightsОfHonor
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = s => Console.WriteLine("Sir " + s);
            Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(s => print(s));
        }
    }
}
