namespace _03._MissionPrivateImpossible
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Spy spy = new Spy();

            string result = spy.RevealPrivateMethods("Hacker");

            Console.WriteLine(result);
        }
    }
}
