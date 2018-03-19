namespace DungeonsAndCodeWizards
{
    using DungeonsAndCodeWizards.Core;
    using DungeonsAndCodeWizards.IO;

    public class StartUp
    {
		public static void Main(string[] args)
		{
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            DungeonMaster dungeonMaster = new DungeonMaster();
            Engine engine = new Engine(dungeonMaster, reader, writer);
            engine.Run();
        }
	}
}