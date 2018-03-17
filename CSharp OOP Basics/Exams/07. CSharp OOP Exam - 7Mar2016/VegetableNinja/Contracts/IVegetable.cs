public interface IVegetable
{
    char Identifier { get; }

    int PowerEffect { get; }

    int StaminaEffect { get; }

    int RegrowPeriod { get; }

    bool HasBeenCollected { get; set; }

    void TickGrowth();
}
