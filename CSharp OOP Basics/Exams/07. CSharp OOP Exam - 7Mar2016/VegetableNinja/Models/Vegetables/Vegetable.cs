public abstract class Vegetable : IVegetable
{
    protected Vegetable(char identifier, int powerEffect, int staminaEffect, int regrowPeriod)
    {
        this.Identifier = identifier;
        this.PowerEffect = powerEffect;
        this.StaminaEffect = staminaEffect;
        this.RegrowPeriod = regrowPeriod;        
        this.GrowthTimer = regrowPeriod;
    }

    public char Identifier { get; private set; }

    public int PowerEffect { get; private set; }

    public int StaminaEffect { get; private set; }

    public int RegrowPeriod { get; private set; }    

    public bool HasBeenCollected { get; set; }

    private int GrowthTimer { get; set; }

    public void TickGrowth()
    {
        if (this.GrowthTimer <= 1)
        {
            this.GrowthTimer = this.RegrowPeriod;
            this.HasBeenCollected = false;
        }
        else
        {
            if (this.HasBeenCollected)
            {
                this.GrowthTimer--;
            }
        }
    }   
}
