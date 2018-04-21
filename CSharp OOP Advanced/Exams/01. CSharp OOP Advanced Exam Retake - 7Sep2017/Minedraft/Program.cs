using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();

        IHarvesterFactory harvesterFactory = new HarvesterFactory();
        IList<IHarvester> harvesters = new List<IHarvester>();
        IEnergyRepository energyRepository = new EnergyRepository();

        IHarvesterController harvesterController = new HarvesterController(harvesterFactory, harvesters, energyRepository);
        IProviderController providerController = new ProviderController(energyRepository);

        ICommandInterpreter commandInterpreter = new CommandInterpreter(harvesterController, providerController);

        IEngine engine = new Engine(reader, writer, commandInterpreter);
        engine.Run();
    }
}
