using System.Collections.Generic;

public class Ninja : INinja
{
    private const int DefaultPower = 1;
    private const int DefaultStamina = 1;

    private readonly List<IVegetable> collectedVegetables;

    private int power;
    private int stamina; 

    public Ninja(string name, int posX, int posY)
    {
        this.Name = name;
        this.Power = DefaultPower;
        this.Stamina = DefaultStamina;
        this.Position = new Position(posX, posY);
        this.collectedVegetables = new List<IVegetable>();
    }

    public string Name { get; private set; }

    public int Power
    {
        get
        {
            return this.power;
        }

        private set
        {
            if (value < 0)
            {
                value = 0;
            }

            this.power = value;
        }
    }

    public int Stamina
    {
        get
        {
            return this.stamina;
        }

        set
        {
            if (value < 0)
            {
                value = 0;
            }

            this.stamina = value;
        }
    }

    public IPosition Position { get; set; }

    public void CollectVegetable(IVegetable vegetable)
    {
        this.collectedVegetables.Add(vegetable);
        vegetable.HasBeenCollected = true;
    }

    public void EatCollectedVegetables()
    {
        foreach (IVegetable vegetable in this.collectedVegetables)
        {
            this.Eat(vegetable);
        }
                
        this.collectedVegetables.Clear();
    }

    private void Eat(IVegetable vegetable)
    {
        this.Power += vegetable.PowerEffect;
        this.Stamina += vegetable.StaminaEffect;
    }
}
