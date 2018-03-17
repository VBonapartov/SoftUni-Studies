using System.Collections.Generic;
using System.Linq;

public class AdoptionCenter : BaseCenter
{
    public AdoptionCenter(string name)
        : base(name)
    {
    }

    public void RegisterAnimal(IAnimal animal)
    {
        this.Animals.Add(animal);
    }

    public List<IAnimal> GetUncleansedAnimals()
    {
        return this.Animals.Where(a => a.CleansingStatus == false).ToList();
    }

    public void RemoveUncleansedAnimals()
    {
        this.Animals.RemoveAll(a => a.CleansingStatus == false);
    }

    public List<string> Adopt()
    {
        List<string> adoptedAnimalNames = this.Animals
                                                    .Where(a => a.CleansingStatus == true)
                                                    .Select(a => a.Name)
                                                    .ToList();

        this.Animals.RemoveAll(a => a.CleansingStatus == true);

        return adoptedAnimalNames;
    }

    public int CountAnimalsAwaitingAdoption()
    {
        return this.Animals.Count(a => a.CleansingStatus == true);
    }

    public List<IAnimal> GetAnimalsForCastration()
    {
        return this.Animals.Where(a => a.CastrationStatus == false).ToList();
    }

    public void RemoveAnimalsForCastration()
    {
        this.Animals.RemoveAll(a => a.CastrationStatus == false);
    }
}
