public interface INinja
{
    string Name { get; }

    int Power { get; }

    int Stamina { get; set; }

    IPosition Position { get; set; }

    void CollectVegetable(IVegetable vegetable);

    void EatCollectedVegetables();
}
