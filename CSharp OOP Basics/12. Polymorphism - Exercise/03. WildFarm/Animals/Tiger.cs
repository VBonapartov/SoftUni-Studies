using System;

public class Tiger : Feline
{
    public Tiger(string animalName, double animalWeight, string animalLivingRegion, string breed)
        : base(animalName, animalWeight, animalLivingRegion, breed)
    {
    }

    protected override Type[] PreferredFoods => new Type[] { typeof(Meat) };

    public override string MakeSound()
    {
        return "ROAR!!!";
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.AnimalName}, {this.Breed}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}