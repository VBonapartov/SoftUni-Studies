namespace _02._HighQualityMistakes
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Spy spy = new Spy();

            string result = spy.AnalyzeAcessModifiers("Hacker");

            Console.WriteLine(result);
        }
    }
}
