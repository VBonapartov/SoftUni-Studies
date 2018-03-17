namespace Minedraft
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            DraftManager draftManager = new DraftManager();
            Engine engine = new Engine(draftManager, reader, writer);
            engine.Run();
        }
    }
}
