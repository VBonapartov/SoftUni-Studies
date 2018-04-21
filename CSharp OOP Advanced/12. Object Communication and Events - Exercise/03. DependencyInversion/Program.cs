namespace _03._DependencyInversion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IPrimitiveCalculator calculator = new PrimitiveCalculator();
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Engine engine = new Engine(calculator, reader, writer);
            engine.Run();
        }
    }
}
