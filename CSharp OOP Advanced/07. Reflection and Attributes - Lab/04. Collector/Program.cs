namespace _04._Collector
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Spy spy = new Spy();

            string result = spy.CollectGettersAndSetters("Hacker");

            Console.WriteLine(result);
        }
    }
}
