public class Hen : Bird
{
    public Hen(string animalName, double animalWeight, double wingSize)
        : base(animalName, animalWeight, wingSize)
    {
    }

    protected override double WeightIncreaseMultiplier => 0.35;

    public override string MakeSound()
    {
        return "Cluck";
    }
}
