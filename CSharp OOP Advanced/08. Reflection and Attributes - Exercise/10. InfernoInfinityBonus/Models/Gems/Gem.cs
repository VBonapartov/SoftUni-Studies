public abstract class Gem
{
    protected Gem(GemClarity levelOfClarity, int strength, int agility, int vitality)
    {
        this.LevelOfClarity = levelOfClarity;
        this.Strength = strength;
        this.Agility = agility;
        this.Vitality = vitality;

        this.CalculateBaseStats();
    }

    public int Strength { get; private set; }

    public int Agility { get; private set; }

    public int Vitality { get; private set; }

    public GemClarity LevelOfClarity { get; private set; }

    private void CalculateBaseStats()
    {
        this.Strength += (int)this.LevelOfClarity;
        this.Agility += (int)this.LevelOfClarity;
        this.Vitality += (int)this.LevelOfClarity;
    }
}