namespace GrandPrix
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IRaceTower race = new RaceTower();
            Engine engine = new Engine(race, reader, writer);
            engine.Run();
        }
    }
}
