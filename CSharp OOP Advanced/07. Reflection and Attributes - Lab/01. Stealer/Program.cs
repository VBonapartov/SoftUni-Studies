namespace _01._Stealer
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Spy spy = new Spy();

            string result = spy.StealFieldInfo(typeof(Hacker).FullName, "username", "password");

            Console.WriteLine(result);
        }
    }
}
