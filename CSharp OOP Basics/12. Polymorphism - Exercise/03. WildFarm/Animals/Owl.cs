using System;

public class Owl : Bird
{
    public Owl(string animalName, double animalWeight, double wingSize)
        : base(animalName, animalWeight, wingSize)
    {
    }

    protected override double WeightIncreaseMultiplier => 0.25;

    protected override Type[] PreferredFoods => new Type[] { typeof(Meat) };

    public override string MakeSound()
    {
        return "Hoot Hoot";
    }
}
