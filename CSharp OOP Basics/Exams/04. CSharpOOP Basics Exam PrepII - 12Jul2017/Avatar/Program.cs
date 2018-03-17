namespace Avatar
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            NationsBuilder nationsBuilder = new NationsBuilder();
            Engine engine = new Engine(nationsBuilder, reader, writer);
            engine.Run();
        }
    }
}