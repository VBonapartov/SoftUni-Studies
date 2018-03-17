public abstract class Bird : Animal
{
    private double wingSize;

    protected Bird(string animalName, double animalWeight, double wingSize)
        : base(animalName, animalWeight)
    {
        this.WingSize = wingSize;
    }    

    protected double WingSize
    {
        get => this.wingSize;
        private set { this.wingSize = value; }
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.AnimalName}, {this.WingSize}, {this.AnimalWeight}, {this.FoodEaten}]";
    }
}
