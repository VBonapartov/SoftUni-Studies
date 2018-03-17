using System.Collections.Generic;

public abstract class BaseCenter : ICenter
{
    private string name;
    private List<IAnimal> animals;

    protected BaseCenter(string name)
    {
        this.CenterName = name;
        this.Animals = new List<IAnimal>();
    }

    public string CenterName
    {
        get => this.name;
        protected set { this.name = value; }
    }

    protected List<IAnimal> Animals
    {
        get => this.animals;
        set { this.animals = value; }
    }
}
