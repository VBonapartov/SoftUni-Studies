public class Program
{
    static void Main(string[] args)
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();

        CarManager carManager = new CarManager();
        Engine engine = new Engine(carManager, reader, writer);
        engine.Run();
    }
}
