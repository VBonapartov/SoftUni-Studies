using System.Collections.Generic;
using System.Linq;

public class CleansingCenter : BaseCenter
{
    public CleansingCenter(string name)
        : base(name)
    {        
    }

    public void RegisterUncleansedAnimals(List<IAnimal> animals)
    {
        this.Animals.AddRange(animals);
    }

    public List<IAnimal> Cleanse()
    {
        this.Animals.ForEach(a => a.CleansingStatus = true);
        List<IAnimal> animals = new List<IAnimal>(this.Animals);
        this.Animals.Clear();

        return animals;
    }

    public int CountAnimalsAwaitingCleansing()
    {
        return this.Animals.Count(a => a.CleansingStatus == false);
    }
}
