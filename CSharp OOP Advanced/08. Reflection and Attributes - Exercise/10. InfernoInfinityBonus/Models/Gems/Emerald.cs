public class Emerald : Gem
{
    private const int EmeraldStrength = 1;
    private const int EmeraldAgility = 4;
    private const int EmeraldVitality = 9;

    public Emerald(GemClarity levelOfClarity)
        : base(levelOfClarity, EmeraldStrength, EmeraldAgility, EmeraldVitality)
    {
    }
}