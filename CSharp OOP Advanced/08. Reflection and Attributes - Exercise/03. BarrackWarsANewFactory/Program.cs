namespace _03._BarrackWarsANewFactory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();

            IRunnable engine = new Engine(repository, unitFactory);
            engine.Run();
        }
    }
}
