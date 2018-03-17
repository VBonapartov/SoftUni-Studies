public abstract class Mammal : Animal
{
    private string livingRegion;

    protected Mammal(string animalName, double animalWeight, string livingRegion)
        : base(animalName, animalWeight)
    {
        this.LivingRegion = livingRegion;
    }

    protected string LivingRegion
    {
        get { return this.livingRegion; }
        private set { this.livingRegion = value; }
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.AnimalName}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}