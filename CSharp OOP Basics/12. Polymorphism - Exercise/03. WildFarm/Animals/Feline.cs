public abstract class Feline : Mammal
{
    private string breed;

    protected Feline(string animalName, double animalWeight, string animalLivingRegion, string breed)
        : base(animalName, animalWeight, animalLivingRegion)
    {
        this.Breed = breed;
    }

    protected string Breed
    {
        get { return this.breed; }
        private set { this.breed = value; }
    }
}