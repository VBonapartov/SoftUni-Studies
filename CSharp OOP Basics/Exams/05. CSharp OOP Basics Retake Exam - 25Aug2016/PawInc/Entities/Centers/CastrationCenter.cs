using System.Collections.Generic;

public class CastrationCenter : BaseCenter
{
    public CastrationCenter(string name)
        : base(name)
    {
    }

    public void RegisterAnimalsForCastration(List<IAnimal> animals)
    {
        this.Animals.AddRange(animals);
    }

    public List<IAnimal> Castrate()
    {
        this.Animals.ForEach(a => a.CastrationStatus = true);
        List<IAnimal> animals = new List<IAnimal>(this.Animals);
        this.Animals.Clear();

        return animals;
    }
}
