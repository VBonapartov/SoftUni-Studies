namespace PawInc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            CenterManager centerManager = new CenterManager();
            Engine engine = new Engine(centerManager, reader, writer);
            engine.Run();
        }
    }
}
