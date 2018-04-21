namespace _01._EventImplementation
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            IWriter writer = new ConsoleWriter();

            Dispatcher dispatcher = new Dispatcher();
            Handler handler = new Handler(writer);

            dispatcher.NameChange += handler.OnDispatcherNameChange;

            string input = string.Empty;
            while (!(input = Console.ReadLine()).Equals("End"))
            {
                dispatcher.Name = input;
            }
        }
    }
}
