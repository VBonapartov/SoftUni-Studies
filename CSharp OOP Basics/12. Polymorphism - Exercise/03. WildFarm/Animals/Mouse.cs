using System;

public class Mouse : Mammal
{
    public Mouse(string animalName, double animalWeight, string livingRegion)
        : base(animalName, animalWeight, livingRegion)
    {
    }

    protected override double WeightIncreaseMultiplier => 0.10;

    protected override Type[] PreferredFoods => new Type[] { typeof(Fruit), typeof(Vegetable) };

    public override string MakeSound()
    {
        return "Squeak";
    }
}