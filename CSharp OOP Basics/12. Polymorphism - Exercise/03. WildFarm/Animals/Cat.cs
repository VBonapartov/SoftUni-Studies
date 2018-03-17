using System;

public class Cat : Feline
{   
    public Cat(string animalName, double animalWeight, string animalLivingRegion, string breed)
        : base(animalName, animalWeight, animalLivingRegion, breed)
    {        
    }

    protected override double WeightIncreaseMultiplier => 0.30;

    protected override Type[] PreferredFoods => new Type[] { typeof(Meat), typeof(Vegetable) };

    public override string MakeSound()
    {
        return "Meow";
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.AnimalName}, {this.Breed}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}