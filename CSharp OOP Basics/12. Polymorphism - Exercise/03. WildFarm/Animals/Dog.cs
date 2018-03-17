using System;

public class Dog : Mammal
{
    public Dog(string animalName, double animalWeight, string livingRegion)
        : base(animalName, animalWeight, livingRegion)
    {
    }

    protected override double WeightIncreaseMultiplier => 0.40;

    protected override Type[] PreferredFoods => new Type[] { typeof(Meat) };

    public override string MakeSound()
    {
        return "Woof!";
    }
}
