namespace _05._BarrackWarsReturnOfTheDepend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            ICommandInterpreter interpreter = new CommandInterpreter(repository, unitFactory);

            IRunnable engine = new Engine(interpreter);
            engine.Run();
        }
    }
}
