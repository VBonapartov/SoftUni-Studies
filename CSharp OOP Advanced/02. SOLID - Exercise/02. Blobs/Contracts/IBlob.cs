public interface IBlob : IAttacker, IDefender, IUpdateable
{
    event OnToggleBehaviorEventHandler OnToggleBehavior;

    event OnBlobDeathEventHandler OnBlobDeath;

    string Name { get; }

    string BehaviorType { get; }

    void ActivateBehavior();
}
