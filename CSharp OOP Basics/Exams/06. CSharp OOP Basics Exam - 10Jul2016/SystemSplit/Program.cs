namespace SystemSplit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            SystemManager systemManager = new SystemManager();
            Engine engine = new Engine(systemManager, reader, writer);
            engine.Run();
        }
    }
}
