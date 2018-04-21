public class BlobFactory : IBlobFactory
{
    public IBlob CreateBlob(
        string name,
        int health,
        int damage,
        string attackType,
        string behaviourType,
        IAttackFactory attackFactory,
        IBehaviorFactory behaviorFactory)
    {
        IBlob blob = new Blob(name, damage, health, attackType, behaviourType, attackFactory, behaviorFactory);

        return blob;
    }
}
