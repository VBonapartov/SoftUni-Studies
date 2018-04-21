namespace _02._Blobs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IBlobFactory blobFactory = new BlobFactory();
            IAttackFactory attackFactory = new AttackFactory();
            IBehaviorFactory behaviorFactory = new BehaviorFactory();
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(blobFactory, attackFactory, behaviorFactory, reader, writer);
            engine.Run();
        }
    }
}
